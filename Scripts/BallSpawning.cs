using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawning : MonoBehaviour
{
    public GameObject GreenBall, BlueBall, YellowBall, RedBall,center;
    [SerializeField] private ToggleGroup Buttons;
    public float count = 2f;
    Spawn sp = new Spawn();
    public GameUI ui;
    public char BallSymbol;
    public bool shooted;
    public string ShootedBallName;
    // Start is called before the first frame update
    void Start()
    {
        BallSymbol = 'G';
        sp.GetScreen();
        Instantiate(GreenBall, center.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (shooted)
        {
                if(ShootedBallName.Contains("BlueBall"))  ui.SetPlasmaAmmo("blue",-1); 
                if(ShootedBallName.Contains("YellowBall")) ui.SetPlasmaAmmo("yellow", -1); 
                if(ShootedBallName.Contains("RedBall")) ui.SetPlasmaAmmo("red", -1); 
            ShootedBallName = "";
            if (countToBall() == true)
            { sp.SpawnBall(CheckBallSymbol(), center); shooted = false;  }
        }
    }

    public void SpawnBallInstanlty()
    {
        GameObject[] ball = GameObject.FindGameObjectsWithTag("ball");
        if (ball != null && !shooted)
        {
            for (int a = 0; a < ball.Length; a++)
            {
                if (!ball[a].GetComponent<ball_behaviour>().Shooted)
                {
                    Destroy(ball[a]);

                }
            }
            sp.SpawnBall(CheckBallSymbol(), center);
            shooted = false;
        }
    }

    private GameObject CheckBallSymbol()
    {
        switch (BallSymbol)
        {
            case 'G': return GreenBall;
            case 'Y': return YellowBall;
            case 'B': return BlueBall;
            case 'R': return RedBall;
        }
        return null;
    }

    private bool countToBall()
    {
        count -= Time.deltaTime;
        if (count <= 0) { count = 2; return true; }
        else
            return false;
    }
}
