using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCooldown : MonoBehaviour
{
    [SerializeField] Player player;
    float speed;
    float distance;

    void Start()
    {
        player = Player.Instance;
        speed = 8f;

    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 4f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0, 1.5f, 0), speed * Time.deltaTime);
            //Destroy(this.gameObject);

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<InventaryManager>().RecolectRunning(1);
            Destroy(this.gameObject);
        }
    }
}
