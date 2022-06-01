using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{

    public Levels lev;
    public GameObject Tank, center, winScreen;
    public GameUI ui;
    public float cEnem;
    Spawn sp = new Spawn();

    // Start is called before the first frame update
    void Start()
    {
        
        ui.minute = 2;
        ui.second = 0;
        lev.cEnem = cEnem = 6;
        lev.ConstCEnemy = 6;
        lev.money = 60;
        lev.actualLevel = 2;
    }

    public void Update()
    {

        if (lev.countToEnemy() == true)
        {

            lev.SpawnStandardTank();
        }



    }

}
