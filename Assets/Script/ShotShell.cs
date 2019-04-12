using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{
    public GameObject shellPrefab;
    public GameObject greatShellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;

    public int shotCount;
    public int maxCount;

    public Text shellLabel;

    private float timeBetweenShot = 0.35f;
    private float timer;

    public GameObject greatShell;   //  TagもGreatShellを作って設定する
    public bool isPowerup;

    public float powerupTime;
    private float elapedTime;

    void Start(){
        shellLabel.text = shotCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //タイマーの時間を動かす
        timer += Time.deltaTime;

        if(isPowerup){
            elapedTime += Time.deltaTime;
            if(elapedTime > powerupTime){
                isPowerup = false;
                elapedTime = 0;
            }
        }
        
        //もしもSpaceキーを押したならば（条件）
        //「Space」の部分を変更することで他のキーにすることができる
        if(Input.GetKeyDown(KeyCode.Space) && timer > timeBetweenShot){

            //returnの働きをおさえる。
            if(shotCount < 1){
                return;
            }

            shotCount -= 1;
            //Debug.Log(shotCount);

            shellLabel.text = shotCount.ToString();

            //タイマーを０に戻す
            timer = 0.0f;

            GameObject shell;

            if(isPowerup){   //  Powerupがtureなら
                shell = Instantiate(greatShellPrefab, transform.position, Quaternion.identity) as GameObject;
            } else {
                //砲弾のプレハブを実体化（インスタンス化）する
                shell = Instantiate(shellPrefab, transform.position, Quaternion.identity) as GameObject;
            }

            //砲弾に付いているRigidbodyコンポーネントにアクセスする
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            //forward(青軸＝Z軸)の方向に力を加える
            shellRb.AddForce(transform.forward * shotSpeed);

            //発射した砲弾を3秒後に破壊する
            //（重要な考え方）不要になった砲弾はメモリ上から削除する
            Destroy(shell, 3.0f);

            //砲弾の発射音を出す
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }

    //残段数を増加させるメソッド
    //外部からこのメソッドを呼び出せるようにpublicをつける
    //このメソッドをShellItemスクリプトから呼び出す
    public void AddShell(int amount){

        //shotCountをamount分だけ回復
        shotCount += amount;

        //残段数が最大値を超えないように
        if(shotCount > maxCount){
            shotCount = maxCount;
        }
        
        //回復をUIに反映
        shellLabel.text = shotCount.ToString();
    }
}
