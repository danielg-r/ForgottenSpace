using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public int index = 0;
    int x = 0;
    int y = 0;

    private Action<int, int> swapFunc = null;

    public void Init(int i, int j, int index, Sprite sprite, Action<int,int> swapFunc)
    {
        this.index = index;
        this.GetComponent<SpriteRenderer>().sprite = sprite;
        UpdatePos(i, j);
        this.swapFunc = swapFunc;
    }

    public void UpdatePos(int i,int j)
    {
        x = i;
        y = j;
        this.gameObject.transform.localPosition = new Vector2(i, j);
    }
    IEnumerator Move()
    {
        float elapsedtime = 0f;
        float duration = 0.2f;
        Vector2 start = this.gameObject.transform.position;
        Vector2 end = new Vector2(x, y);

        while(elapsedtime<duration)
        {
            this.gameObject.transform.localPosition = Vector2.Lerp(start, end, (elapsedtime / duration));
            elapsedtime += Time.deltaTime;
            yield return null;
        }

        

    }

    public bool IsEmpty()
    {
        return index == 9;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && swapFunc != null)
        {
           swapFunc(x,y);
        }
    }

}
