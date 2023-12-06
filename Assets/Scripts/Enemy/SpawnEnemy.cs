using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    
    private float time = 3.5f;
    public GameObject[] enemies;
    private int spawns = 0;
    private int spawnLimit = 10;
    public Transform[] spawnPoints; 
 
    void Start()
    {
        
        StartCoroutine(Spawn());
    }
 
    IEnumerator Spawn()
    {
        while(spawns <= spawnLimit) {
            GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];
            Vector2 spawnPos = Random.insideUnitCircle.normalized;
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            spawns++;
            yield return new WaitForSeconds(time);
        }
    }
}
