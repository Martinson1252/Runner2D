using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private float offset_x = 3f;
    private float offset_y = 2f;

        // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x+offset_x,player.position.y+offset_y, 0);
       
    }
}   
