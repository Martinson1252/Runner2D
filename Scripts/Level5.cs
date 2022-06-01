using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5 : MonoBehaviour
{

    public Levels lev;
    public GameObject Tank, center, winScreen;
    public GameUI ui;
    public float cEnem;
    Spawn sp = new Spawn();

    // Start is called before the first frame update
    void Start()
    {

        ui.minute = 3;
        ui.second = 0;
        lev.cEnem = cEnem = 4.5f;
        lev.ConstCEnemy = 4.5f;
        lev.money = 90;
        lev.actualLevel = 5;
    }


	private void Update()
	{
        if (lev.countToEnemy() == true)
        {

            lev.SpawnStandardTank();
        }
    }

}
