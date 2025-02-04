using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject fantasma;
    public Transform[] spawnPoints;
    GameManager gamemanager;

    void Start()
    {
       
        StartCoroutine(SpawnFantasma());
    }

    IEnumerator SpawnFantasma()
    {
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Instantiate(fantasma, spawnPoints[randomIndex].position, Quaternion.identity);
                gamemanager.EnemigosSpawn();
            }
            yield return new WaitForSeconds(10f);
        }
    }
}
