using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dwuja : MonoBehaviour
{
    
    public  Vector3 direction;
    public Rigidbody2D rb;
   

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * 12;
        if (Vector2.Distance(Professor.ProfessorPosition, gameObject.transform.position)>16)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<Player>().GUI.GetComponent<GUI_System>().Player_WAR_Set(-1);
        }
    }
}
