using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehavior : MonoBehaviour
{
    public Animator anim;
    private float JumpPower = 8;
    private bool OnGround = true;
    public Rigidbody2D CurrentRigidbody;
    private Vector3 changePosition;
    public GameObject Rend;
    public static bool AutoRunning; 
    public float PlayerRunningSpeed;
    public PhysicsMaterial2D playerMat;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMat = CurrentRigidbody.sharedMaterial;
        Time.timeScale = 1;
        
        PlayerRunningSpeed = 4;
        changePosition = transform.localScale;
        CurrentRigidbody = transform.GetComponent<Rigidbody2D>();
    }
    
    
    // Update is called once per frame
    void LateUpdate()
    {
        if (!anim.GetBool("Static"))
        {
            
            {
                AutoRunning_run();
                slide();
                jump();
            }

        }
        else
            CurrentRigidbody.sharedMaterial = null;


    }

    
        
        
    
   public void jump()
    {
        if ( anim.GetBool("OnGround") && Input.GetKeyDown(KeyCode.W) && 
             !anim.GetCurrentAnimatorStateInfo(0).IsName("slide"))
        {
            CurrentRigidbody.velocity = new Vector2(CurrentRigidbody.velocity.x, JumpPower);
            anim.SetTrigger("jump");
            
        }  //else if(anim.GetCurrentAnimatorStateInfo(0).IsName("jump"))
            //gameObject.transform.Translate(Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * 4, 0, 0);
    }

   public void slide()
   {
       if (Input.GetKeyDown(KeyCode.S) && OnGround==true && anim.GetBool("running"))
       {
           anim.SetTrigger("slide");
           
           CurrentRigidbody.velocity = new Vector2(9,0);
          // transform.Translate(90*Time.fixedDeltaTime,0,0);
       }
   }

   private void AutoRunning_run()
   {
       if (!anim.GetCurrentAnimatorStateInfo(0).IsName("slide") )
       {
            anim.SetBool("running", true);
            
            //transform.Translate(  Time.fixedDeltaTime * PlayerRunningSpeed,0,0);
            CurrentRigidbody.velocity = new Vector2(12,CurrentRigidbody.velocity.y);
       }else
          anim.SetBool("running", false);
      
   }


   public void DeathByShock()
   {
       if(!anim.GetBool("Static"))
       anim.SetTrigger("DeathByShock");
       
       Rend.SetActive(true);
       anim.SetBool("Static",true);
   }

   public void DeathByDinosaur()
   {
       Rend.SetActive(true);
       gameObject.SetActive(false);
   }
    
}

