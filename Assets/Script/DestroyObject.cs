using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //エフェクトプレハブのデータを入れるための箱
    public GameObject effectPrefab;

    //2種類目のエフェクトを入れるための箱
    public GameObject effectPrefab2;

    public GameObject[] itemsPrefab;
    private GameObject item;

    public int objectHP;

    public int scoreValue;
    private ScoreManager sm;

    void Start(){

        //ScoreManagerオブジェクトに付いているScoreManagerスクリプトの情報を取得し、smに入れる
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }


    //このメソッドはぶつかった瞬間に呼び出される
    void OnTriggerEnter(Collider col){

        //もしもぶつかった相手のTagにShellという名前が書いてあったならば
        if(col.CompareTag("Shell")){

            //オブジェクトのHPを1ずつ減らす
            objectHP -= 1;
            DamageEffect(col.gameObject);
        } else if(col.CompareTag("GreatShell")) {
            objectHP -= 5;
            DamageEffect(col.gameObject);
        }
    }

    private void DamageEffect(GameObject col){

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

            int randomValue = Random.Range(0, 100);
            Debug.Log(randomValue);
            Vector3 temp = new Vector3();
            temp.y = 1.0f;

            if(0 <= randomValue && randomValue < 50){
                item = (GameObject)Instantiate(itemsPrefab[1], new Vector3(transform.position.x, (transform.position.y + temp.y), transform.position.z), Quaternion.identity);    
            } else if(50 <= randomValue && randomValue < 75){
                item = (GameObject)Instantiate(itemsPrefab[0],  new Vector3(transform.position.x, (transform.position.y + temp.y), transform.position.z), Quaternion.identity);
            }

            sm.AddScore(scoreValue);
            Debug.Log(scoreValue);

            //このスクリプトがついているオブジェクトを破壊する（thisは省略可）
            Destroy(this.gameObject);

        }
    }
}
