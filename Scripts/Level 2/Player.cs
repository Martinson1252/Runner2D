using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject GUI;
    public Rigidbody2D CurrentRigid;
    private Vector3 LocalScaleR;
    private Vector3 LocalScaleL;
    public static float PlayerSide;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
       LocalScaleR = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
       LocalScaleL = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerSide = gameObject.transform.localScale.x;
        move();
        jump();
        
    }

    void move()
    {
        if(anim.GetBool("OnGround")==true)
        { if (Input.GetAxisRaw("Horizontal")>0 )
        {   anim.SetBool("move",true);
            CurrentRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 12, CurrentRigid.velocity.y);
            transform.localScale = LocalScaleR;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 )
        {   anim.SetBool("move",true);
            CurrentRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 12, CurrentRigid.velocity.y);
                transform.localScale = LocalScaleL;
        }
        else 
        {
            CurrentRigid.velocity = new Vector2(0, CurrentRigid.velocity.y);
            anim.SetBool("move",false);
        }}
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && anim.GetBool("OnGround"))
        {
            anim.SetTrigger("jump");
            CurrentRigid.velocity = new Vector2(CurrentRigid.velocity.x, 8);
        }
    }
}
