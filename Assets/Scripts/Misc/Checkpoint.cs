using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Tooltip("The position where the player will appear at this checkpoint.")]
    [SerializeField] Transform spawnPoint;
    static Checkpoint lastCheckpoint;

    void Start() {
        PlayerLife.Instance.onPlayerRespawned += BackToCheckpoint;
    }

    public void BackToCheckpoint() {
        if (lastCheckpoint != null){
            Debug.Log("Cargando checkpoint");
            InventoryManager.Instance.transform.position = lastCheckpoint.spawnPoint.position;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log($"Guardando último checkpoint: {this.name}");
            lastCheckpoint = this;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
