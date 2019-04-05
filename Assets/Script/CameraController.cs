using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && subCamera){
            mainCamera.enabled = !mainCamera.enabled;
            subCamera.enabled = !subCamera.enabled;
        }
        if(!subCamera){
            mainCamera.enabled = true;
        }
    }
}
