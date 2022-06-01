using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject Rend;
    public BoxCollider2D coli1;
    public BoxCollider2D coli2;
    public GameObject Player;

    private PlayerBehavior PlayerMethods;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMethods = Player.GetComponentInChildren<PlayerBehavior>();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.otherCollider == coli1)
           
        // if (other.otherCollider == coli2)
            
        if (other.gameObject.CompareTag("Hero"))
        {
            PlayerMethods.DeathByShock();
        }
    }
}
