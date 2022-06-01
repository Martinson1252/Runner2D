using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3 : MonoBehaviour
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
        ui.second = 20;
        lev.cEnem = cEnem = 5.5f;
        lev.ConstCEnemy = 5.5f;
        lev.money = 70;
        lev.actualLevel = 3;
    }

    public void Update()
    {

        if (lev.countToEnemy() == true)
        {

            lev.SpawnStandardTank();
        }



    }

}
