using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GroundCheck : MonoBehaviour
{
   public Animator player;

   private void Start()
   {
      player = GetComponentInParent<Animator>();
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      player.SetBool("OnGround",true);
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      player.SetBool("OnGround",false);
   }

   
}
