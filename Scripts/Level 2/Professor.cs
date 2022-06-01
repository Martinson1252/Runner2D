using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Professor : MonoBehaviour
{
    public GameObject GUI;
    public Animator anim;
    public static int ProfessorHealth;
    public GameObject bullet;
    public Transform firePoint;
    private Vector3 Player2Professor;
    public static Vector3 ProfessorPosition;
    void Start()
    {
        ProfessorHealth = 100;
        ProfessorPosition = transform.position;
    }

    
   
    // Update is called once per frame
    void LateUpdate()
    {
        
         
            if (Vector2.Distance(Shooting.PlayerPosition,transform.position)<=16 && !GameObject.FindGameObjectWithTag("dwuja"))
            {
               
                Player2Professor =  Shooting.PlayerPosition - transform.position;
                firePoint.rotation = Quaternion.LookRotation(Vector3.forward, Player2Professor);

                anim.SetTrigger("Attack");
                Shoot();




            }
    }
    
    
     public void Shoot()
     {
         
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = firePoint.position;
        
        //bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.up * 12;
        bulletClone.GetComponent<dwuja>().direction = firePoint.up;
       
    }

     

    
}
