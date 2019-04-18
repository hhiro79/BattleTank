using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    private GameObject enemy;
    private float timer;
    public float minWaitTime;
    public float maxWaitTime;
    private float randomTime;
    public int maxCreateEnemy;
    private int createEnemy;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(minWaitTime, maxWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(createEnemy >= maxCreateEnemy){
            return;
        }

        timer += Time.deltaTime;
        if(timer >= randomTime){
            int randomValue = Random.Range(0, enemiesPrefab.Length);
            enemy = Instantiate(enemiesPrefab[randomValue], transform.position, Quaternion.identity);
            createEnemy++;
            Debug.Log(createEnemy);
            timer = 0;
            randomTime = Random.Range(minWaitTime, maxWaitTime);
        }
    }
}
