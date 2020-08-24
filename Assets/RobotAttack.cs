using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttack : MonoBehaviour
{
    [SerializeField]EnemyController enemy;

    void Start()
    {
        enemy = GetComponentInParent<EnemyController>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerLife.Instance.TakeDamage(enemy.damage);
        }        
    }
}
