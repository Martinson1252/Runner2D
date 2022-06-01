using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dinosaur : MonoBehaviour
{
    public Animator anim;
    public GameObject Player;
    private PlayerBehavior PlayerMethods;
    private float PlayerAndDinoDistance;
    private float DinosaurSpeed;
    private float playerSpeed;
    public float DinosaurStaticSpeed;
    private bool DinosaurEatsPlayer;
    
    private Animator PlayerAnim;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = Player.GetComponent<Animator>();
        PlayerMethods = Player.GetComponentInChildren<PlayerBehavior>();
        DinosaurStaticSpeed = 4f;
    }


    void LateUpdate()
    {
        DinosaurEatsPlayer = anim.GetCurrentAnimatorStateInfo(0).IsName("Dinosaur_eatPlayer");
        playerSpeed = Player.GetComponent<Rigidbody2D>().velocity.x;
        PlayerAndDinoDistance = Player.transform.position.x - gameObject.transform.position.x;

        DinosaurSpeed = DinosaurStaticSpeed + playerSpeed * 0.63f;
        if (!DinosaurEatsPlayer && PlayerAndDinoDistance <= 10 && !PlayerAnim.GetBool("Static"))
        {
            transform.Translate(DinosaurSpeed * Time.deltaTime, 0, 0);
        }
        else
        {   if(!PlayerAnim.GetBool("Static"))
            transform.Translate(playerSpeed*Time.deltaTime,0,0);
             if(PlayerAnim.GetBool("Static") && !DinosaurEatsPlayer )
                    transform.Translate(DinosaurStaticSpeed*Time.deltaTime,0,0);
          
        }
    

 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hero")&& !PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("canal_jump"))
        {
            Debug.Log("EAT!!!");
            PlayerMethods.DeathByDinosaur();
            anim.SetTrigger("DeathByDinosaur");
        }
    }

  
}