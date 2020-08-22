using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] GameObject lockedPs, unlockedPs;

    public void Unlock()
    {
        lockedPs.SetActive(false);
        unlockedPs.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Unlock();
        }
    }
}
