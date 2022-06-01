using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class G_R_shock : MonoBehaviour
{
    public char choice;
    float radius=6;
    public float countdown;
    void Start()
    {
       
        radius = gameObject.GetComponent<SpriteRenderer>().bounds.size.x*gameObject.transform.localScale.x;


        if (gameObject.tag == "greenshock")
        { choice = 'G'; countdown = 1.5f; }
        if (gameObject.tag == "redshock")
        { choice = 'R'; countdown = 6f;
            if (!FindObjectOfType<SoundManager>().IsPlaying("BigElectricShock"))
                FindObjectOfType<SoundManager>().PlayFX("BigElectricShock");
        }
    }

    
    void FixedUpdate()
    {
        if (choice == 'G')
            counter();

        if(choice == 'R')
        {
            counter();

            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius);
            for(int a=0;a<hit.Length;a++)
            {
                if(hit[a].CompareTag("enemy"))
                hit[a].gameObject.GetComponent<enemy>().Health(-14f*Time.fixedDeltaTime);
            }
            
        } 
    }
     void counter()
    {
        if (countdown > 0)
            countdown -= Time.fixedDeltaTime;
        else
		{

            FindObjectOfType<SoundManager>().StopFX("BigElectricShock");
            Destroy(gameObject);
		}
    }

	
}
