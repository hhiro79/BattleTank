using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public GameObject effectPrefab1;
    public GameObject effectPrefab2;
    public int tankHP;

    void OnTriggerEnter(Collider col){

        //もしもぶつかってきた相手のTagがEnemyShellであったなら
        if(col.gameObject.tag == "EnemyShell"){
            
            //HPを1ずつ減少させる
            tankHP -= 1;

            //ぶつかってきた相手方(敵の砲弾)を破壊
            Destroy(col.gameObject);

            if(tankHP > 0){
                GameObject effect1 = (GameObject)Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            } else {

                GameObject effect2 = (GameObject)Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                //プレーヤーを破壊
                Destroy(gameObject);
            }
        }
    }
}
