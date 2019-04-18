using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public GameObject enemyShellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;
    private float shotInterval;

    public float stopTimer = 5.0f;

    public float minShotCount;
    public float maxShotCount;

    private float randomValue;

    void Start(){
        randomValue = Random.Range(minShotCount, maxShotCount);
    }

    // Update is called once per frame
    void Update()
    {
        shotInterval += 1;

        stopTimer -= Time.deltaTime;

        if(stopTimer < 0){
            stopTimer = 0;
        }

        //print("攻撃開始まであと" + stopTimer + "秒");

        // if(shotInterval % 60 == 0 && stopTimer <= 0){
        //     GameObject enemyShell = (GameObject)Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

        //     Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

        //     enemyShellRb.AddForce(transform.forward * shotSpeed);

        //     AudioSource.PlayClipAtPoint(shotSound, transform.position);

        //     Destroy(enemyShell, 3.0f);
        // }

        if(shotInterval > randomValue && stopTimer <= 0){
            GameObject enemyShell = (GameObject)Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody EnemyShotShellRb = enemyShell.GetComponent<Rigidbody>();

            //forwardはZ軸方向（青軸）、この方向に力を加える
            EnemyShotShellRb.AddForce(transform.forward * shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, 3.0f);

            shotInterval = 0;
            randomValue = Random.Range(minShotCount, maxShotCount);
        }
    }

        //敵の攻撃をストップさせるメソッド（Timerの時間を増加させることで攻撃の停止時間を伸ばす）
        //HPを増加させるアイテム等と同じ
        //このアイテムを複数取得すると、それだけ攻撃停止時間も加算される
        public void AddStopTimer(float amount){
            stopTimer += amount;
            Debug.Log(stopTimer);
        }
}
