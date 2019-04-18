using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip getSound;
    private TankHealth th;
    private int reward = 3;

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){

            th = GameObject.Find ("Tank").GetComponent<TankHealth> ();

            //AddHp()メソッドを呼び出して引数にrewardを与えている
            th.AddHP(reward);

            Destroy(gameObject);
            GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
        }
    }
}
