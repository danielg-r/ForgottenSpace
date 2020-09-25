using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BoxPuzzle : MonoBehaviour
{

    public int sizeRow, sizeCol;
    int countPoint = 0;
    int countImageKey = 0;

    public List<GameObject> imageKeyList;
    public List<GameObject> imageOfPictureList;
    public List<GameObject> CheckpointList;

    GameObject[,] imageKeytMatrix;
    GameObject[,] imageOfPictureMatrix;
    GameObject[,] CheckpointMatrix;

    private void Start()
    {
        CheckPointManager();
        ImageKeyManager();
    }


    void CheckPointManager()
    {
        for(int i = 0;i<sizeRow; i++)
        {
            for(int j = 0; i < sizeRow; i++)
            {
                CheckpointMatrix[i, j] = CheckpointList[countPoint];
                countPoint++;
            }
        }
    }

    void ImageKeyManager()
    {
        for (int i = 0; i < sizeRow; i++)
        {
            for (int j = 0; i < sizeRow; i++)
            {
                imageKeytMatrix[i, j] = imageKeyList[countImageKey];
                countImageKey++;
            }
        }
    }

    void ImageOfNormal()
    {
        imageOfPictureMatrix[0, 0] = imageOfPictureList[0];
        imageOfPictureMatrix[0, 1] = imageOfPictureList[2];
        imageOfPictureMatrix[0, 2] = imageOfPictureList[5];
        imageOfPictureMatrix[1, 0] = imageOfPictureList[4];
        imageOfPictureMatrix[1, 1] = imageOfPictureList[1];
        imageOfPictureMatrix[1, 2] = imageOfPictureList[7];
        imageOfPictureMatrix[2, 0] = imageOfPictureList[3];
        imageOfPictureMatrix[2, 1] = imageOfPictureList[6];
        imageOfPictureMatrix[2, 2] = imageOfPictureList[8];
    }


}
