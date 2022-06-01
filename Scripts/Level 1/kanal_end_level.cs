using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class kanal_end_level : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject player;
    private int MoneyAmount;
   
   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            MoneyAmount = MoneyText.MoneyVal;
            WinScreen.SetActive(true);
            player.GetComponent<PlayerBehavior>().anim.SetBool("Static",true);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.GetComponent<PlayerBehavior>().anim.SetTrigger("canal_jump");

          Write_Money_In_File();
            

        }
    }

    void Write_Money_In_File()
    {
       
            string path = Application.dataPath  +"/log.txt";
        
       
            File.WriteAllText(path,MoneyAmount.ToString());
       
    }
}
