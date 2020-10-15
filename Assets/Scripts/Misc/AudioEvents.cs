using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
   public void Walk1()
   {
        AudioManager.Instance.Play("Walk1");
   }

   public void Walk2()
   {
        AudioManager.Instance.Play("Walk2");
   }
}
