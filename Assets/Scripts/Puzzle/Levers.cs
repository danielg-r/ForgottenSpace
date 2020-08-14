using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : MonoBehaviour
{

    public int State = 0;
    public bool puedegirar = true;

    public GameObject controlador;

    public GameObject Green;
    public GameObject Blue;
    public GameObject Red;

    IEnumerator girar()
    {
        yield return new WaitForSeconds(0.5f);
        puedegirar = true;
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


        controlador.GetComponent<Puzzle>().ReceberSignal(this.gameObject, State);
    }

    public void MoveLever()
    {
        //girado = true;

        if(puedegirar)
        {
            //1 Blue - 2 Green - 0 Red
            puedegirar = false;
            if (State == 0)
            {
                StartCoroutine(girar());
                Blue.gameObject.SetActive(true);
                Green.gameObject.SetActive(false);
                Red.gameObject.SetActive(false);
            }
            else if (State == 1)
            {
                StartCoroutine(girar());
                Blue.gameObject.SetActive(false);
                Green.gameObject.SetActive(true);
                Red.gameObject.SetActive(false);
            }
            if (State == 2)
            {
                StartCoroutine(girar());
                Blue.gameObject.SetActive(false);
                Green.gameObject.SetActive(false);
                Red.gameObject.SetActive(true);
            }
            
        }
    }

}
