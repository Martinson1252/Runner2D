using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Ball : MonoBehaviour
{
    public GameObject RedStorm;
  
    public ball_behaviour b;
   
    float radius=4;
    void Start()
    {
        b.symbol = 'R';
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject RED = Instantiate(RedStorm);
        RED.transform.position = b.Ball.transform.position;
        Destroy(b.Ball);
       
    }

 


}
