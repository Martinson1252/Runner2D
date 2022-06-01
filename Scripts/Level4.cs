using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4 : MonoBehaviour
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
        ui.second = 40;
        lev.cEnem = cEnem = 5;
        lev.ConstCEnemy = 5;
        lev.money = 80;
        lev.actualLevel = 4;
    }

    public void Update()
    {


        if (lev.countToEnemy() == true)
        {

            lev.SpawnStandardTank();
        }


    }

}
