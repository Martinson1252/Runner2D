using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public GameObject Standard_Tank, Heavy_Tank, center, winScreen;
    public GameUI ui;
    public float cEnem, ConstCEnemy, money, actualLevel, To;
    Spawn sp = new Spawn();
    // Start is called before the first frame update
    void Start()
    {
        sp.GetScreen();
        To = 1;
        Standard_Tank.transform.GetChild(2).gameObject.SetActive(true);
        ui.Load();

        ui.HealthBar.value = ui.HealthBarValue = 100;
        ui.SetPlasmaAmmoFirst();
    }

 


    public void SpawnStandardTank()
	{
            sp.SpawnTank(Standard_Tank, 1.75f, 50, sp.SetRandomPosition());
	} 
    public void SpawnHeavyTank()
	{
            sp.SpawnTank(Heavy_Tank, 1.4f, 92, sp.SetRandomPosition());
	}


    public bool CountTo(float number)
	{
        if(To>=number)
		{
            To = 1;
            return true;
		}
		else { To++; return false; }
	}

    public bool countToEnemy()
    {
        cEnem -= Time.deltaTime;
        if (cEnem <= 0) { cEnem = ConstCEnemy; return true; }
        else
            return false;
    }



    private void FixedUpdate()
    {
        counter();
        if (ui.minute == 0 && ui.second <= 0)
        { win(); ui.second = 0; }
        ui.ACTTime.text = ui.minute.ToString() + ":" + Mathf.Floor(ui.second).ToString("00");

    }



    void counter()
    {
        if (ui.minute > 0 && ui.second <= 0)
        { ui.minute--; ui.second = 59; }
        ui.second -= Time.fixedDeltaTime;
    }


    private void win()
    {
        Time.timeScale = 0;
        GameObject WINScreen = Instantiate(winScreen, ui.gameObject.transform);
        WINScreen.GetComponent<Animator>().SetTrigger("Death");
        if (ui.levelUnlocked <= actualLevel)
        {
            WINScreen.GetComponentInChildren<Text>().text = money.ToString();
            ui.money += money;
            ui.levelUnlocked = actualLevel+1;
            ui.SaveData();
            Debug.Log("unloc " + ui.levelUnlocked+" act "+actualLevel);
        }
        else
		{
        WINScreen.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        WINScreen.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        WINScreen.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);

            ui.SaveData();
		}
    }
}
