using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class survival : MonoBehaviour
{
   
    public GameObject center,Medium_Tank,Heavy_Tank;
    public GameUI ui;
    public float count = 2f,cEnemy=6,cEnemyConst=6, EstimatedTime, ActualTime,To;
    public bool shooted;
    Spawn sp = new Spawn();
    [SerializeField] SaveLoadManager SL = new SaveLoadManager();
    // Start is called before the first frame update
    void Start()
    {
        ui.SUR = true;
        Medium_Tank.transform.GetChild(2).gameObject.SetActive(true);
        sp.GetScreen();
        To = 1;
        ui.Load();
        //money = 500; 
        //SaveData(); Load();
        ui.BestTime.text = "Best " + ui.BestTiming[0].ToString() + ":" + ui.BestTiming[1].ToString("00");
        ui.HealthBar.value = ui.HealthBarValue = 100;
        ui.SetPlasmaAmmoFirst();
        sp.SpawnTank(Medium_Tank, 1.75f, 50, sp.SetRandomPosition());
    }

    public void Update()
    {

        if (countToEnemy() == true)
        {
            

            if (CheckTime(3,10)) cEnemyConst = 2;
            if (CheckTime(2, 30)) 
			{
                cEnemyConst = 3;
                if (CountTo(3))
                    SpawnHeavyTank();
                else
                    SpawnStandardTank();
            }
                else
                SpawnStandardTank();

            if (CheckTime(1, 40)) cEnemyConst = 4;
           

            if (CheckTime(0,40)) cEnemyConst = 5;
        }
    }


    public void SpawnStandardTank()
    {
        sp.SpawnTank(Medium_Tank, 1.75f, 50, sp.SetRandomPosition());
    }
    public void SpawnHeavyTank()
    {
        sp.SpawnTank(Heavy_Tank, 1.4f, 92, sp.SetRandomPosition());
    }

    private bool countToEnemy()
    {
        cEnemy -= Time.deltaTime;
        if (cEnemy <= 0) { cEnemy = cEnemyConst; return true; }
        else
            return false;
    }

    private void FixedUpdate()
    {
        counter();
        ui.ACTTime.text = ui.minute.ToString() + ":" + Mathf.Floor(ui.second).ToString("00");
    }
     


    void counter()
    {
        if (ui.second >= 59)
        { ui.minute++; ui.second = 0; }
        ui.second += Time.fixedDeltaTime;
    }

    public bool CountTo(float number)
    {
        if (To >= number)
        {
            To = 1;
            return true;
        }
        else { To++; return false; }
    }

    bool CheckTime(float minute, float second)
	{
        EstimatedTime = minute * 60 + second;
        ActualTime = ui.minute * 60 + ui.second;
        if (ActualTime >= EstimatedTime)
            return true;
        else return false;
	}

}
