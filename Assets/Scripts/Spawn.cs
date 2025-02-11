using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject fantasma;
    public GameObject cherryPrefab;
    public Transform[] spawnPoints;
    public Transform[] spawnCherry;
    public GameManager gamemanager;

    void Start()
    {
       
        StartCoroutine(SpawnFantasma());
        StartCoroutine(SpawnCherry());
    }

    IEnumerator SpawnFantasma()
    {
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                gamemanager.EnemigosSpawn();
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Instantiate(fantasma, spawnPoints[randomIndex].position, Quaternion.identity);               
            }
            yield return new WaitForSeconds(10f);
        }
    }

    IEnumerator SpawnCherry()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            int randomIndex = Random.Range(0, spawnCherry.Length);
            Vector3 spawnPosition = spawnCherry[randomIndex].position;
            GameObject cherry = Instantiate(cherryPrefab, spawnPosition, Quaternion.identity);
            Destroy(cherry, 10f);

        }
    }
}
