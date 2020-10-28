using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    void Start() {
        PlayerLife.Instance.onPlayerDied += CancelInvoke;       
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            InvokeRepeating("DoDamage", 0f, 0.35f);
        }
    }

    void OnTriggerExit(Collider other) {
        CancelInvoke();
    }

    void DoDamage() {
        GetComponentInParent<FireHazard>().DamageTick();
    }
}
