using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ball_behaviour : MonoBehaviour
{
    public char symbol;
     Spawn ScBound = new Spawn();
    public Collider2D coli;
    public GameObject Ball;
    protected GameObject center;
    protected Camera cam;
    public Vector3 MouseArrow, BallToCenter, BallPos;
    public Rigidbody2D rb;
    public Transform firepoint;
    public bool Shooted = false, CanMove = false;
    protected float ShootBounds = 3.3f, counter = 3f;
    public TrailRenderer tr;
    public LineRenderer line;
    public GameUI ui;
    // Start is called before the first frame update
    private void Awake()
    {
        ScBound.GetScreen();
    }
    private void Start()
    {
        coli.isTrigger = true;
        tr.enabled = false;
        center = GameObject.FindGameObjectWithTag("center");
        cam = Camera.main;
        Ball.transform.position = center.transform.position;
        BallPos = Ball.transform.position;
       
       
    }

    // Update is called once per frame
    private void Update()
    {
       
        MouseArrow = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(MouseArrow, new Vector3(0,0,1));


        if (hit.collider)
            if (Input.GetMouseButton(0) && hit.collider.CompareTag("ball") && !Shooted)
                CanMove = true;    
                    if(CanMove)
                        DragBall();

        
            

        if (Shooted)
        {
            count();
            if(counter <= 0 && rb.velocity.x <0.2f && rb.velocity.y <0.2f || Ball.transform.position.x <0 || 
                Ball.transform.position.x > ScBound.screen.RightDown.x || Ball.transform.position.x < ScBound.screen.LeftDown.x)
            Destroy(Ball);
        }

        if (Input.GetMouseButtonUp(0) && CanMove)
        {
            ShootBall();
            CanMove = false;
        }
    }

    protected void DragBall()
    {
        
        //Ograniczenie przemieszcznia pocisku
        Vector2 APos = MouseArrow - center.transform.position;
        APos = Vector2.ClampMagnitude(APos,ShootBounds);  
        firepoint.transform.position = Ball.transform.position;
        Ball.transform.position = APos + new Vector2(center.transform.position.x,center.transform.position.y);
        //rb.MovePosition(APos+center.transform.position);
        line.SetPosition(0,Ball.transform.position);
        line.SetPosition(1,center.transform.position);
        
 
    }

   protected void ShootBall()
    {
        coli.isTrigger = false;
        line.enabled = false;
        tr.enabled = true;
        BallPos = Ball.transform.position;
        float Force = Vector3.Distance(center.transform.position , Ball.transform.position);
        BallToCenter = new Vector3(center.transform.position.x,center.transform.position.y) - BallPos;
        firepoint.rotation = Quaternion.LookRotation(Vector3.forward, BallToCenter);
        rb.AddForce(firepoint.up * 4 * Force, ForceMode2D.Impulse );
        Shooted = true;
        center.GetComponent<BallSpawning>().shooted=true;
        center.GetComponent<BallSpawning>().ShootedBallName=Ball.name;
        Debug.Log(Ball.name);
        
    }

   protected void count()
    {
        counter -= Time.deltaTime;
    }

  
}

