using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BoxPuzzle : MonoBehaviour
{
    public Box boxPrefab;

    public Box[,] boxes = new Box[3, 3];

    public Sprite[] sprites;




    private void Start()
    {
        Init();
    }

    void Init()
    {
        int n = 0;
        for (int y = 2; y >= 0; y--)
        {
            for (int x = 0; x < 3; x++)
            {
                Box box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, sprites[n], ClickToSwap);
                boxes[x, y] = box;
                n++;
            }
        }
    }

    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x, y);
        int dy = getDy(x, y);

        var from = boxes[x, y];
        var target = boxes[x + dx, y + dy];

        //Cambia las "Box"
        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        //Actualiza la posicion
        from.UpdatePos(x + dx, y + dy);
        target.UpdatePos(x, y);
    }

    int getDx(int x, int y)
    {
        //Derecha vacio
        if (x < 2 && boxes[x + 1, y].IsEmpty())
        {
            return 1;
        }
        //Izquierda Vacio
        if (x > 0 && boxes[x - 1, y].IsEmpty())
        {
            return -1;
        }
        return 0;
    }
    int getDy(int x, int y)
    {
        //Arriba vacio
        if (y < 2 && boxes[x, y + 1].IsEmpty())
        {
            return 1;
        }
        //Abajo vacio
        if (y > 0 && boxes[x, y - 1].IsEmpty())
        {
            return -1;
        }
        return 0;
    }




}
