using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : MonoBehaviour
{

    public int State = 0;
    public bool CanTurn = true;

    public GameObject Controller;

    public GameObject Green;
    public GameObject Blue;
    public GameObject Red;

    IEnumerator Turn()
    {
        yield return new WaitForSeconds(0.5f);
        CanTurn = true;
        switch (State)
        {
            case 0:
                State = 1;
                break;
            case 1:
                State = 2;
                break;
            case 2:
                State = 0;
                break;
            default:                
                break;
        }


        Controller.GetComponent<Puzzle>().ReceiveSignal(this.gameObject, State);
    }

    public void MoveLevers()
    {
        //girado = true;

        if(CanTurn)
        {
            //1 Blue - 2 Green - 0 Red
            CanTurn = false;
            if (State == 0)
            {
                StartCoroutine(Turn());
                Blue.gameObject.SetActive(true);
                Green.gameObject.SetActive(false);
                Red.gameObject.SetActive(false);
            }
            else if (State == 1)
            {
                StartCoroutine(Turn());
                Blue.gameObject.SetActive(false);
                Green.gameObject.SetActive(true);
                Red.gameObject.SetActive(false);
            }
            if (State == 2)
            {
                StartCoroutine(Turn());
                Blue.gameObject.SetActive(false);
                Green.gameObject.SetActive(false);
                Red.gameObject.SetActive(true);
            }
            
        }
    }

}
