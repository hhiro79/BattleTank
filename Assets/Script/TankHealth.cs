using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public Camera tankCamera;
    public GameObject effectPrefab1;
    public GameObject effectPrefab2;
    public int tankHP;

    public Text HPLabel;

    void Start(){
        HPLabel.text = tankHP.ToString();
    }

    void OnTriggerEnter(Collider col){

        //もしもぶつかってきた相手のTagがEnemyShellであったなら
        if(col.gameObject.tag == "EnemyShell"){
            
            //HPを1ずつ減少させる
            tankHP -= 1;

            HPLabel.text = tankHP.ToString();

            //ぶつかってきた相手方(敵の砲弾)を破壊
            Destroy(col.gameObject);

            if(tankHP > 0){
                GameObject effect1 = (GameObject)Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            } else {

                GameObject effect2 = (GameObject)Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                //プレーヤーを破壊
                //Destroy(gameObject);

                //プレーヤーを破壊せずに画面から見えなくする
                //プレーヤーを破壊すると、その時点でメモリ上から消えるので、その後のコードが実行されなくなる。
                tankCamera.enabled = false;
                this.gameObject.SetActive(false);

                //1.5秒後に「GoToGameOver()」メソッドを実行
                Invoke("GoToGameOver", 1.5f);
            }
        }
    }

    void GoToGameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
