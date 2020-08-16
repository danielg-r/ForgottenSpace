using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Player player; // = Player.Instance;
    float speed = 8f;
    float distance;

    public bool Inter = false;

    void Start()
    {
        player = Player.Instance;
        speed = 8f;
    }

    void Update()
    {
        if (Inter == true)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < 4f)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0, 1.5f, 0), speed * Time.deltaTime);
                //Destroy(this.gameObject);        
            } 
        }
    }

    void OnTriggerStay(Collider other)
    {        
            if (other.gameObject.CompareTag("Player") && Inter == true)
            {
                other.GetComponent<InventaryManager>().RecolectCoin(1);
                Destroy(this.gameObject);
            }         
    }

    public void Atrract()
    {
        Inter = true;
        
    }

}
