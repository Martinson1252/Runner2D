using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] public Text ACTTime, BestTime,BlueAmmo,YellowAmmo,RedAmmo;
    [SerializeField] public Slider HealthBar;
    public GameObject DeathScreen,center;
    [SerializeField] private Selectable GreenToggle,BlueToggle,YellowToggle,RedToggle;
 
    public ToggleGroup tg;
    SaveLoadManager SL = new SaveLoadManager();
    public float count = 2f,minute, second,HealthBarValue,money,BlueBalls,YellowBalls,RedBalls,levelUnlocked=1;
    public float[] BestTiming = { 0,0 };
    public bool SUR;
	// Start is called before the first frame update

	private void Start()
	{
        if (center.GetComponent(typeof(survival)))
            SUR = true;
        else
            SUR = false;

       
	}

	public void Load()
    {
        if (SL.LoadData() != null)
        {
            PlayerData Dat = SL.LoadData();
            PlayerRecord Rec = SL.LoadRecord();
            BestTiming = Rec.BestTime;
            money = Dat.money;
            BlueBalls = Dat.BlueBalls;
            YellowBalls = Dat.YellowBalls;
            RedBalls = Dat.RedBalls;
            levelUnlocked = Dat.levelUnlocked;
        }
    }
   

   

    public void SetHealthBar(float value)
    {
     
        
        HealthBarValue -= value;

        if (HealthBarValue <= 0)
        {
            HealthBar.value = 0;
            Time.timeScale = 0;
            if(SUR) DeathOnSurvival(); 
            else
            DeathOnLevel(); 
          
        Debug.Log(SUR);
            
        }
        else HealthBar.value = HealthBarValue;
    }

    public void SaveData()
    {
        SL.SavePlayerData(this);
    }

   public void SetPlasmaAmmoFirst()
    {
        BlueAmmo.text = BlueBalls.ToString();
        YellowAmmo.text = YellowBalls.ToString();
        RedAmmo.text = RedBalls.ToString();
        if (BlueBalls <= 0) BlueToggle.interactable = false;
        if (YellowBalls <= 0) YellowToggle.interactable = false;
        if (RedBalls <= 0) RedToggle.interactable = false;
    }

    public void SetPlasmaAmmo(string name,float quantity)
    {
        switch (name)
        {
            case "blue": 
               if(BlueBalls+quantity>0) BlueAmmo.text = (BlueBalls += quantity).ToString(); 
                else
                {   BlueToggle.interactable = false;
                    
                    GreenToggle.GetComponent<Toggle>().isOn=true;
                    BlueBalls = 0; BlueAmmo.text = "0";
                    
                } 
                break;
            case "yellow": 
                if(YellowBalls+quantity>0) YellowAmmo.text = (YellowBalls += quantity).ToString(); 
                else
                { 
                    YellowToggle.interactable = false;
                    GreenToggle.GetComponent<Toggle>().isOn = true;
                    YellowBalls = 0; YellowAmmo.text = "0";
                }
                break;
            case "red":
                if (RedBalls + quantity > 0) RedAmmo.text = (RedBalls += quantity).ToString();
                else
                {
                    RedToggle.interactable = false;
                    GreenToggle.GetComponent<Toggle>().isOn = true;
                    RedBalls = 0; RedAmmo.text = "0"; 
                }
                break;
        }    
    }

    private void DeathOnSurvival()
    {
        GameObject DS = Instantiate(DeathScreen, this.transform);
        float m = 0;
        //DS.transform.SetParent(this.gameObject.transform);

        DS.GetComponent<Animator>().SetTrigger("Death");
        Text[] TEX = DS.GetComponentsInChildren<Text>();
        TEX[0].text = minute.ToString() + ":" + Mathf.Floor(second).ToString("00");
        m = Mathf.Floor((minute * 20) + (second * 0.2f));
        TEX[1].text = m.ToString();
        TEX[6].text = "Death";
        money += m;
        BestTiming[0] = minute;
        BestTiming[1] = second;
        SaveData();
    } 
    
    private void DeathOnLevel()
    {
        GameObject DS = Instantiate(DeathScreen, this.transform);
        DS.GetComponent<Animator>().SetTrigger("Death");
        Text[] TEX = DS.GetComponentsInChildren<Text>();
        TEX[0].text = minute.ToString() + ":" + Mathf.Floor(second).ToString("00");
        TEX[6].text = "You Failed";
        BestTiming[0] = minute;
        BestTiming[1] = second;
        DS.transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
        DS.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        DS.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        SaveData();
    }

}
