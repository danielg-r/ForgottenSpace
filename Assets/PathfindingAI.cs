using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PathfindingAI : MonoBehaviour
{
    NavMeshAgent agent; 
    [SerializeField] PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        TestPathfinding();
    }
    void TestPathfinding()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Moving to player");
            agent.SetDestination(player.transform.position);
        }
    }
    
}
