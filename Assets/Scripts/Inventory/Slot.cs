using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

   public bool isEmpty;

    public GameObject item;
    public Texture itemIcon;
    //private SpriteRenderer icon;

    void Awake()
    {
        isEmpty = true;
    }

    void Update()
    {
        if (item)
        {
            isEmpty = false;
            itemIcon = item.GetComponent<Item>().icon;
            this.GetComponent<RawImage>().texture = itemIcon;
        }
        else
        {
            isEmpty = true;
        }
    }

    public void OnClick()
    {

    }
}
