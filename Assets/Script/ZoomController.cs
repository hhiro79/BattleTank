using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    private Camera cam;
    private float zoom;
    private float view;

    //public float speed;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera> ();
        view = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //float wheelView = cam.fieldOfView - (scroll * speed);    

        cam.fieldOfView = view + zoom;

        //最小値と最大値を決める（自由に変更可能）
        if(cam.fieldOfView < 10f){
            cam.fieldOfView = 10f;
        }

        //自分の主観カメラを基準に数値を決める
        if(cam.fieldOfView > 60f){
            cam.fieldOfView = 60f;
        }

        //リターンキーを押すとzoomの数値が減少（ボタン変更可能）
        if(Input.GetKey (KeyCode.Return)) {

            //どれくらいの速度でzoomを変更させるかも自由
            zoom -= 0.3f;

            //右シフトキーでzoomの数値が増加
        } else if(Input.GetKey (KeyCode.RightShift)) {
            zoom += 0.3f;
        }
    }
}
