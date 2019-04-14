using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public Image aimImage;

    // Update is called once per frame
    void Update()
    {
        //レーザー(ray)を飛ばす起点と方向
        Ray ray = new Ray (transform.position, transform.forward);

        //レーザー光を可視化
        Debug.DrawRay (transform.position, transform.forward * 30, Color.green);

        //rayの当たり判定の情報を入れる箱
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 60)){

            string hitName = hit.transform.gameObject.tag;

            if(hitName == "Enemy"){

                //照準器の色を赤に変える
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            } else {
                
                //照準器の色を水色に
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }
        } else {

            //照準器の色を水色に
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
