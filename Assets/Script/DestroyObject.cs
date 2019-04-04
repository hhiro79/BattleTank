using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //エフェクトプレハブのデータを入れるための箱
    public GameObject effectPrefab;

    //2種類目のエフェクトを入れるための箱
    public GameObject effectPrefab2;

    public int objectHP;

    //このメソッドはぶつかった瞬間に呼び出される
    void OnTriggerEnter(Collider col){

        //もしもぶつかった相手のTagにShellという名前が書いてあったならば
        if(col.CompareTag("Shell")){

            //オブジェクトのHPを1ずつ減らす
            objectHP -= 1;

            //もしもHPが0より大きい場合には
            if(objectHP > 0){

                //ぶつかってきたオブジェクトを破壊する
                Destroy(col.gameObject);

                //エフェクトを実体化する
                GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);

                //エフェクトを2秒後に画面から消す
                Destroy(effect, 2.0f);
                
            } else { //そうでない場合（HPが0以下になったら）
                Destroy(col.gameObject);

                //もう1種類のエフェクトを発生させる
                GameObject effect2 = (GameObject)Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);

                //このスクリプトがついているオブジェクトを破壊する（thisは省略可）
                Destroy(this.gameObject);

            }
        }
    }
}
