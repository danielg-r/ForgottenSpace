using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class CutsceneSkipper : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    PlayableAsset pb;
    double duration;

    void Start()
    {
        duration = director.duration;       
    }

    void Update()
    {
        if (Input.GetButtonDown("CutScene"))
        {
            director.time = director.duration;
        }
    }


}
