using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_Ball : MonoBehaviour
{
    public ball_behaviour b;
    public GameObject GreenShock;
    private void Start()
    {
        b.symbol = 'G';
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<SoundManager>().PlayFX("GreenBallCollision");
        if (collision!=null)
            if(collision.gameObject.CompareTag("enemy"))
            {
                GameObject enemy = collision.gameObject;

                enemy.GetComponent<enemy>().Health(-30);
                if (enemy.GetComponent<enemy>().Pushable)
                    enemy.GetComponent<enemy>().Blast(1.5f);
                else
                    enemy.GetComponent<enemy>().Blast(0);

                if ((enemy.GetComponent<enemy>().GetHealth()) > 0)
                {
                    FindObjectOfType<SoundManager>().PlayFX("electricShock");

                    SpriteRenderer[] list = enemy.GetComponentsInChildren<SpriteRenderer>();

                    Vector3 Edimersions = list[1].bounds.size;
                    GameObject Shock = Instantiate(GreenShock, enemy.transform);
                    Vector3 Sdimersions = Shock.GetComponentInChildren<SpriteRenderer>().bounds.size;
                    Shock.transform.parent = enemy.transform;
                    Shock.transform.localScale = new Vector3(Edimersions.x / Sdimersions.x, Edimersions.y / Sdimersions.y, 1);
                }//else
                    //FindObjectOfType<SoundManager>().PlayFX("explosion");

            }
    }
}
