using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefa;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnLoop());
    }
    public float time;
    int counter =1;
    IEnumerator spawnLoop()
    {
        while (true)
        {
            yield return null;  
            time+= Time.deltaTime;

            if (time >= 10)
            {
                counter++;
                time = 0;
            }

            yield return new WaitForSeconds(15);  
            for (int c=0;c<counter;c++)
            {
       var randomPos =  new Vector3(UnityEngine. Random.Range(transform.position.x - 10, transform.position.x + 10), 1,UnityEngine. Random.Range(transform.position.z - 10, transform.position.z + 10));

                Instantiate(enemyPrefa, randomPos, enemyPrefa.transform.rotation);
            }

        }
    }
    
}
