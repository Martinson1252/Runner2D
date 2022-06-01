using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private Camera cam;

    private float halfHeight;
    private void Start()
    {
        cam = Camera.main;
        halfHeight = cam.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y + player.GetComponent<Renderer>().bounds.extents.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y, transform.position.z);
       
    }
}
