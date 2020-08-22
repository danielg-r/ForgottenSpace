using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimations : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (PlayerLife.Instance != null)
        {
            PlayerLife.Instance.onPlayerDied += new PlayerLife.OnPlayerDied(OnPlayerDiedAnimation);
        }
    }

    void OnPlayerDiedAnimation()
    {
        anim.applyRootMotion = false;
        int animation = Random.Range(1,3);
        switch (animation)
        {
            case 1:
                anim.SetTrigger("Death_1");
                break;
            case 2:
                anim.SetTrigger("Death_2");
                break;
            case 3:
                anim.SetTrigger("Death_3");
                break;
        }
    }
}
