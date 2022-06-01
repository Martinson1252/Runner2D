using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform firePoint;
    public Camera cam;
    private Vector3 Player2Mouse;
    private float lookAngle;
    public static Vector3 Startpos;
    public int Money;
    public static Vector3 PlayerPosition;

    public GameObject gui;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void LateUpdate()
    {
        Money = gui.GetComponent<GUI_System>().Money_amount;
        PlayerPosition = transform.position;
        firePoint.position = transform.position;
        Startpos = firePoint.position;
        if (Input.GetMouseButtonDown(0) && !GameObject.FindGameObjectWithTag("Bullet") && Money>0 &&Time.timeScale==1)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Player2Mouse =    transform.position - mousePos;
            firePoint.rotation = Quaternion.LookRotation(Vector3.forward, Player2Mouse);
            if(firePoint.rotation.z<0 && Player.PlayerSide<0 || firePoint.rotation.z>0 && Player.PlayerSide>0 )
            Shoot(BulletPrefab);
            gui.GetComponent<GUI_System>().Player_Money_Bar_Set(-10);
        }
    }

    void Shoot(GameObject BulletPrefab)
    {
        GameObject bullet = Instantiate(BulletPrefab);
        bullet.transform.position = firePoint.position;
       // bullet.transform.rotation = quaternion.Euler(0,0,lookAngle);
        bullet.GetComponent<Rigidbody2D>().velocity = -firePoint.up * 12;
    }
}
