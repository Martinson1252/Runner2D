using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class YellowBall : MonoBehaviour
{
    [SerializeField] ball_behaviour b;
    public Animator anim;
    public float damage;
    public float radius;
    Vector2 dir;
    private void Start()
    {
        radius = 5;
        damage = 30;
        b.symbol = 'Y';
    }
        float aa;
    private void OnCollisionEnter2D()
    {
            b.coli.enabled = false;
        anim.SetTrigger("Yellow_explosion");
        FindObjectOfType<SoundManager>().PlayFX("BigExplosion");
        b.rb.bodyType = RigidbodyType2D.Static;
        {   // 
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius);
            for (int a=0; a< hit.Length; a++)
            { 
                if (hit[a].CompareTag("enemy"))
                {
                        dir = hit[a].transform.position - b.Ball.transform.position;
                    hit[a].gameObject.GetComponent<enemy>().Health(-damage);
                   

                    if (hit[a].GetComponent<enemy>().ExplosionSensitive)
                    {
                        hit[a].GetComponent<enemy>().Blast(2);
                        hit[a].gameObject.GetComponent<Rigidbody2D>().AddForce((dir.normalized) * 16, ForceMode2D.Impulse);
                    }
                    else
                        hit[a].GetComponent<enemy>().Blast(0);

                    aa++;
                }
            }
            Debug.Log(aa);
            Destroy(b.Ball,0.36f);
        }

    }
    

}
