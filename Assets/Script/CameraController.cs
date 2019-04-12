using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;
    public TankHealth tankHealth;

	// private bool mainCameraON = true;

	// void Start () {
	// 	mainCamera.enabled = true;
	// 	subCamera.enabled = false;
	// }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.C) && mainCameraON == true){
		// 	mainCamera.enabled = false;
		// 	subCamera.enabled = true;

		// 	mainCameraON = false;

		// // もしも「Cボタン」を押した時、「かつ」、「mainCameraON」のステータスが「false」の時（条件）
		// } else if(Input.GetKeyDown(KeyCode.C) && mainCameraON == false){
		// 	mainCamera.enabled = true;
		// 	subCamera.enabled = false;

		// 	mainCameraON = true;
        // }
        
        if(Input.GetKeyDown(KeyCode.C) && subCamera){
            mainCamera.enabled = !mainCamera.enabled;
            subCamera.enabled = !subCamera.enabled;
        }
        if(tankHealth.tankCamera.enabled == false){
            mainCamera.enabled = true;
        }
    }
}
