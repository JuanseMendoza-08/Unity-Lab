using UnityEngine;
using System;
using System.IO.Ports;
using System.Threading.Tasks;

public class SerialTransmitter : MonoBehaviour
{
    SerialPort serialPort;

    public static event Action<int> OnButtonPressed;
    public static event Action<int> OnPotValueChanged;

    void Start()
    {
        serialPort = new SerialPort("COM4", 9600);
        serialPort.DtrEnable = true;

        try
        {
            serialPort.Open();
            Debug.Log("Serial port opened successfully.");
            _ = ReceiveLoop();
        }
        catch (Exception ex)
        {
            Debug.LogError("Could not open the serial port: " + ex.Message);
        }
    }

    private async Task ReceiveLoop()
    {
        string buffer = "";

        try
        {
            while (serialPort != null && serialPort.IsOpen)
            {
                buffer += serialPort.ReadExisting();

                while (buffer.Contains("\n"))
                {
                    int lineBreak = buffer.IndexOf('\n');
                    string fullMessage = buffer.Substring(0, lineBreak).Trim();
                    buffer = buffer.Substring(lineBreak + 1);

                    Debug.Log("Received: " + fullMessage);
                    ProcessMessage(fullMessage);
                }

                await Task.Delay(50);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Serial port error: " + ex.Message);
        }
    }

    void ProcessMessage(string message)
    {
        if (message.StartsWith("BTN:"))
        {
            string valueText = message.Substring(4);

            if (int.TryParse(valueText, out int buttonNumber))
            {
                OnButtonPressed?.Invoke(buttonNumber);
            }
        }
        else if (message.StartsWith("POT:"))
        {
            string valueText = message.Substring(4);

            if (int.TryParse(valueText, out int potValue))
            {
                OnPotValueChanged?.Invoke(potValue);
            }
        }
    }

    public void TestData()
    {
        SendData("hello");
    }

    public void SendData(string data)
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                serialPort.WriteLine(data);
                Debug.Log("Sent: " + data);
            }
            catch (Exception ex)
            {
                Debug.LogError("Failed to send data: " + ex.Message);
            }
        }
        else
        {
            Debug.LogWarning("Serial port is not open.");
        }
    }

    private void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}