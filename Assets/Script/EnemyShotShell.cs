using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public GameObject enemyShellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;
    private float shotInterval;

    public float minShotCount;
    public float maxShotCount;

    private float randomValue;

    void Start(){
        randomValue = Random.Range(minShotCount, maxShotCount);

        Debug.Log(randomValue);
    }

    // Update is called once per frame
    void Update()
    {
        shotInterval += 1;

        if(shotInterval > randomValue){
            GameObject enemyShell = (GameObject)Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody EnemyShotShellRb = enemyShell.GetComponent<Rigidbody>();

            //forwardはZ軸方向（青軸）、この方向に力を加える
            EnemyShotShellRb.AddForce(transform.forward * shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, 3.0f);

            shotInterval = 0;
            randomValue = Random.Range(minShotCount, maxShotCount);
            Debug.Log(randomValue);
        }
    }
}
