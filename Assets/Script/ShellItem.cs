using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellItem : MonoBehaviour
{
    public AudioClip getSound;
    public GameObject effectPrefab;
    private ShotShell ss;
    public int reward = 5; //弾数をいくつ回復させるか

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){

            //Findメソッドは「名前」でオブジェクトを探し特定する
            //「ShotShell」オブジェクトを探し出して、それに付いているShotShellスクリプト（component）のデータを取得
            //取得したデータをSSの箱の中に入れる
            ss = GameObject.Find ("ShotShell").GetComponent<ShotShell>();

            //ShotShellスクリプトの中のAddShellメソッドを呼び出す
            //rewardで設定した数値分だけ弾数が回復
            ss.AddShell(reward);
  
            //アイテムを画面から削除
            Destroy(gameObject);

            //アイテムゲット音を出す
            //MainCameraタグが付いているカメラの側で音を発生させる
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            //アイテムゲット時にエフェクト発生
            GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //エフェクトを0.5秒後に消す
            Destroy(effect, 0.5f);

        }
    }
}
