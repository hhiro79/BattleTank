using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttackItem : MonoBehaviour
{
    private GameObject[] targets;
    public AudioClip getSound;
    public GameObject effectPrefab;

    // Update is called once per frame
    void Update()
    {
        //EnemyShotShellオブジェクトにEnemyShotShellタグを設定
        targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){

            for(int i = 0; i < targets.Length; i++){

                //攻撃停止時間を3秒加算
                targets[i].GetComponent<EnemyShotShell>().AddStopTimer(3.0f);
                
            }

            Destroy (gameObject);

            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);

            Destroy(effect, 0.5f);
        }
    }
}
