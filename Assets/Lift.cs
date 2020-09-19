using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] Transform destination;

    public void MoveLift()
    {
        PlayerMovement.Instance.transform.position = destination.position;
    }
}
