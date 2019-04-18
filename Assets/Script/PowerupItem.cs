using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip getSound;
    private ShotShell ss;

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            ss = GameObject.Find("ShotShell").GetComponent<ShotShell>();
            ss.isPowerup = true;                 // Powerup状態にする

            Destroy(gameObject);
            GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
        }
    }        
}
