using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItem : MonoBehaviour
{
    private ShotShell ss;

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            ss = GameObject.Find("ShotShell").GetComponent<ShotShell>();
            ss.isPowerup = true;                 // Powerup状態にする

            Destroy(gameObject);
        }
    }        
}
