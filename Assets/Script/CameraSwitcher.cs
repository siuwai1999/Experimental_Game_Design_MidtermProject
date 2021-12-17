using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera PlayerCamera;
    private Camera[] cameras;

    void DisbleAllCam()
    {
        cameras = new Camera[Camera.allCameras.Length];
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera.allCameras[i].enabled = false;
        }
    }
    void Start()
    {
        PlayerCamera = GetComponent<Camera>();
        DisbleAllCam();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DisbleAllCam();
            PlayerCamera.enabled = true;
        }
    }
}
