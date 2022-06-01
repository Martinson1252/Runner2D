using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Ball : MonoBehaviour
{
    public Animator anim;
    public ball_behaviour b;
    public float radius = 4;
    public float FreezeTime = 7;
    public GameObject freezeTimeout;
    void Start()
    {
        b.symbol = 'B';
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius);
        for (int a = 0; a < hit.Length; a++)
        {
            GameObject enemy = hit[a].transform.gameObject;
           
                if (hit[a].CompareTag("enemy"))
                {
                if (enemy.GetComponent<enemy>().Freezable)
                {
                    if (enemy.transform.GetChild(enemy.transform.childCount - 1).gameObject.name.Contains("freeze"))
                    {
                        enemy.transform.GetChild(enemy.transform.childCount - 1).GetComponent<freezeEnemy>().Destroy();
                    }
                    GameObject freeze = Instantiate(freezeTimeout, enemy.transform);
                    enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    freeze.GetComponent<freezeEnemy>().parent = enemy;
                }
                    //AddExplosionForce(hit[a], hit[a].collider.gameObject.GetComponent<Rigidbody2D>());
                    //enemy.GetComponent<Rigidbody2D>().AddForce((b.Ball.transform.position - enemy.transform.position) * 2, ForceMode2D.Impulse);
                }
        }
        anim.SetTrigger("blue explosion");
        //b.coli.enabled = false;
        b.rb.bodyType = RigidbodyType2D.Static;
        Destroy(b.Ball, 0.3f);
    }

    

}
