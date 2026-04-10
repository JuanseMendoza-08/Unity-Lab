using UnityEngine;

public class CameraViewByButtons : MonoBehaviour
{
    public Camera mainCamera;
    public Transform view1;
    public Transform view2;
    public Transform view3;
    public Transform view4;

    private void OnEnable()
    {
        SerialTransmitter.OnButtonPressed += ChangeView;
    }

    private void OnDisable()
    {
        SerialTransmitter.OnButtonPressed -= ChangeView;
    }

    void ChangeView(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1:
                MoveCamera(view1);
                break;
            case 2:
                MoveCamera(view2);
                break;
            case 3:
                MoveCamera(view3);
                break;
            case 4:
                MoveCamera(view4);
                break;
        }
    }

    void MoveCamera(Transform viewPoint)
    {
        if (mainCamera != null && viewPoint != null)
        {
            mainCamera.transform.position = viewPoint.position;
            mainCamera.transform.rotation = viewPoint.rotation;
        }
    }
}