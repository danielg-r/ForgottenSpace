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
    GameObject enemy;
    int random; 

    void Start() {
    }
    void OnEnable() {        
        StartCoroutine("SpawnEnemies");
    }

    public IEnumerator SpawnEnemies() {
        while (true) {
            random = Random.Range(0, enemies.Length);
            positionRandomizer = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void OnDisable() {
        StopAllCoroutines();
    }


    void SpawnEnemy()
    {
        enemy = Instantiate(enemies[random], transform.position + positionRandomizer, transform.rotation);
        GameObject ps = Instantiate(spawnFX, transform.position + positionRandomizer + new Vector3 (0,-1f,0), transform.rotation);
        ps.transform.localScale = Vector3.one * 0.7f;
        enemy.transform.parent = transform;
        Invoke("EnemyBehavior", 0.5f);
    }

    void EnemyBehavior() {
        if (random == 1) { 
            enemy.GetComponentInChildren<EnemyController>().FollowDistance = 100f;
            enemy.GetComponentInChildren<EnemyController>().state = EnemyState.Chase;
            enemy.GetComponentInChildren<EnemyController>().PlayerDetected();
        } else if (random == 0) {
            enemy.GetComponentInChildren<NavMeshAgent>().SetDestination(PlayerLife.Instance.transform.position); 
        }
    }

    public void ClearEnemies() {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);            
        }
    }
}
