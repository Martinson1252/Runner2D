using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject gui;
    
    private void Start()
    {
       
    }

    private void Update()
    {
        
        if (Vector2.Distance(Shooting.Startpos, gameObject.transform.position)>10)
        {
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Professor"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Professor>().GUI.GetComponent<GUI_System>().Professor_Health_Set(-10);
        }
    }
}
