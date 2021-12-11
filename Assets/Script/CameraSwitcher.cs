using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public int cameraIndex;
    public Camera[] cameras;

    void Start()
    {
        cameraIndex = 0;

        cameras = new Camera[Camera.allCameras.Length];
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera.allCameras[i].enabled = false;
        }
        cameras[cameraIndex].enabled = true;
    }
    public void ChangeCam(int CamNum)
    {

    }
}
