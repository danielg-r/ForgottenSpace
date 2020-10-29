using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HangarSpawner : MonoBehaviour
{
    [Header("Enemy prefabs")]
    [SerializeField] GameObject[] enemies;
    [Header("FX")]
    [SerializeField] GameObject spawnFX;
    [SerializeField] float spawnInterval;
    bool isSpawning;
    Vector3 positionRandomizer;
    int random; 

    void Start() {

    }

    public IEnumerator SpawnEnemies() {
        random = Random.Range(0, enemies.Length);
        positionRandomizer = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        SpawnEnemy();
        yield return new WaitForSeconds(spawnInterval);        
    }


    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemies[random], transform.position + positionRandomizer, transform.rotation);
        GameObject ps = Instantiate(spawnFX, transform.position + positionRandomizer + new Vector3 (0,-1f,0), transform.rotation);
        ps.transform.localScale = Vector3.one * 0.7f;
        enemy.GetComponentInChildren<NavMeshAgent>().SetDestination(PlayerLife.Instance.transform.position); 
    }
}
