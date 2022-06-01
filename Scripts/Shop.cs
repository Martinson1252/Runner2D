using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;

public class Shop : MonoBehaviour
{
    public Text moneyT;
    [SerializeField] Button Plus,Minus,Buy;
    public ToggleGroup Buttonsgroup;
    public Text blueP, yellowP, redP,calcCost,CostPerOne, description;
    public float ForOneBullet;
    public InputField inputAmount;
     [HideInInspector]  GameUI sav = new GameUI();
    private void Start()
    {
        ForOneBullet = 10;
        sav.Load();
        inputAmount.text = "1";
        moneyT.text = sav.money.ToString();
        blueP.text = sav.BlueBalls.ToString();
        yellowP.text = sav.YellowBalls.ToString();
        redP.text = sav.RedBalls.ToString();
        InputField();
    }
  

    public void SetBluePlasma(float MONEY)
    {
        float BlueBALLS = float.Parse(blueP.text) + float.Parse(inputAmount.text);

        blueP.text = (BlueBALLS).ToString();
        moneyT.text = (MONEY).ToString();
        sav.money = MONEY;
        sav.BlueBalls = BlueBALLS;
        sav.SaveData();
    }

    public void SetYellowPlasma(float MONEY)
    {
        float YellowBALLS = float.Parse(yellowP.text) + float.Parse(inputAmount.text);

        yellowP.text = (YellowBALLS).ToString();
        moneyT.text = (MONEY).ToString();
        sav.money = MONEY;
        sav.YellowBalls = YellowBALLS;
        sav.SaveData();
       
    }

    public void SetRedPlasma(float MONEY)
    {
        float RedBALLS = float.Parse(blueP.text) + float.Parse(inputAmount.text);

        redP.text = (RedBALLS).ToString();
        moneyT.text = (MONEY).ToString();
        sav.money = MONEY;
        sav.RedBalls = RedBALLS;
        sav.SaveData();
    }

  public void InputField()
    {
        if (inputAmount.text.Equals("")||inputAmount.text.Equals("0"))
            inputAmount.text = "1"; else
            calcCost.text = (  float.Parse(inputAmount.text)*ForOneBullet  ).ToString();

        if (float.Parse(moneyT.text) < float.Parse(calcCost.text))
        { Buy.interactable = false; 
            calcCost.color = new Color(0.6415094f, 0, 0, 1); 
        }else
        { Buy.interactable = true; 
            calcCost.color = new Color(0.5176471f, 0.5176471f, 0.5176471f, 1); 
        }
    }
       
      
   
}
