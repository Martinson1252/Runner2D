using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class enemy : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public GameObject tank,explosion;
    public Animator anim;
    public float HP, maxHP, Speed, BaseDestroyPoints;
    public Image HP_bar;
    public bool isStatic, Pushable, Freezable, ExplosionSensitive;
    [HideInInspector] private Spawn sp = new Spawn();
     public GameUI ui  ;
    Vector2 mouseP,Temp;
    public bool EnemyBehindBorder { get; set; }
    Quaternion zero = new Quaternion();
    float count = 3.5f;
    private void Start()
    {
        isStatic = false;
        ui = GameObject.FindObjectOfType<GameUI>();
        zero.Set(0, 0, 0, 1);
        sp.GetScreen();
        
    }

    public void Move()
    {
        if(isStatic==false)
		{
            if (tank.transform.rotation == zero)
            {
                //rb.velocity = new Vector2(-Speed, 0);
                rb.velocity = -transform.right*Speed;

            }
            else
                rotateToDest();

		}
        
    }

   public void rotateToDest()
    {
        if(rb.bodyType!=RigidbodyType2D.Static)
        tank.transform.rotation = Quaternion.RotateTowards(tank.transform.rotation, zero, 55 * Time.fixedDeltaTime);
        //enemy.transform.position += Vector3.forward * Time.fixedDeltaTime * Speed;
        
    }
    public void IsBehindBorder()
    {
        if (tank.transform.position.x <= sp.screen.LeftDown.x - 1 || tank.transform.position.x >= sp.screen.RightDown.x + 5f)
        {

            if (ui != null && !(tank.transform.position.x >= sp.screen.RightDown.x + 5f))
                ui.SetHealthBar(10);

            Destroy(tank);
           
        }
        
        
    }

    public void Destroyed()
    {
        
        if (HP <= 0)
        {
            
            rb.bodyType = RigidbodyType2D.Static;
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            anim.SetTrigger("explosion");
            
            if(!FindObjectOfType<SoundManager>().IsPlaying("explosion"))
                FindObjectOfType<SoundManager>().PlayFX("explosion");

            Destroy(tank,.2f);  
        }
    }

    public void Health(float value)
    {
        float CurrentValue = HP_bar.fillAmount;
        
       

            HP_bar.fillAmount +=  (value / maxHP);
            HP += value;
        
        
    }
  
    public float GetHealth()
	{
        return HP;
	}

    private float counter()
    {
        return count -= Time.fixedDeltaTime;
    }


    private void Update()
    {
        Destroyed();
        IsBehindBorder();

    }


    private void FixedUpdate()
    {
        Move();
    }

    public void Blast(float time)
	{
        StartCoroutine(count());
        IEnumerator count()
	    {
            isStatic = true;
           yield return new WaitForSeconds(time);
            isStatic = false;
            rb.angularVelocity = 0;
            rb.angularDrag = 0;
            rb.velocity = Vector2.SmoothDamp(rb.velocity, Vector2.left,ref Temp,1);
           
	    }

	}
}
