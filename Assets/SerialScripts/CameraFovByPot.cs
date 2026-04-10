using UnityEngine;

public class CameraFovByPot : MonoBehaviour
{
    public Camera mainCamera;
    public float fovMin = 20f;
    public float fovMax = 100f;

    private void OnEnable()
    {
        SerialTransmitter.OnPotValueChanged += ChangeFov;
    }

    private void OnDisable()
    {
        SerialTransmitter.OnPotValueChanged -= ChangeFov;
    }

    void ChangeFov(int potValue)
    {
        if (mainCamera != null)
        {
            float t = potValue / 100f;
            mainCamera.fieldOfView = Mathf.Lerp(fovMin, fovMax, t);
        }
    }
}