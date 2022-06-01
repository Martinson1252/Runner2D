using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    public Levels lev;
    public GameObject Tank,center,winScreen;
    public GameUI ui;
    public float cEnem, ConstCEnemy;
    Spawn sp = new Spawn();

    // Start is called before the first frame update
    void Start()
    {

        ui.minute = 1;
        ui.second = 40;
        lev.cEnem = cEnem = 6.5f;
        lev.ConstCEnemy = 6.5f;
        lev.money = 50;
        lev.actualLevel = 1;
    }

	private void Update()
	{
        if (lev.countToEnemy() == true)
        {
           
                lev.SpawnStandardTank();
        }
    }

}
