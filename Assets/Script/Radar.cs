using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public Transform target;

    //「OnTriggferStay」はトリガーが他のコライダーに触れている間中実行されるメソッド
    void OnTriggerStay(Collider Col){

        //もしも他のオブジェクトに「Player」というTagが付いていたならば
        if(Col.CompareTag("Player")){

            //「root」を使うと「親（最上位の親）」の情報を得ることができる
            //LookAt()メソッドは指定した方向にオブジェクトの向きを回転させる
            transform.root.LookAt(target);
        }
    }
}
