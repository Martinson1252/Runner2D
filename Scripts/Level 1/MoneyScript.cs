using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    // Start is called before the first frame update
    //private bool AddMoney = false;

    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hero"))
            //AddMoney = true;
            MoneyText.AddMoney(10);
            Destroy(gameObject);
    }
}
