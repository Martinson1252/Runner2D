using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public Shop sh;


  

    public void plus()
    {
       float n = float.Parse(sh.inputAmount.text);
        sh.inputAmount.text = (n+1).ToString();
    }

    public void minus()
    {
        if(float.Parse(sh.inputAmount.text)-1>=0)
        {
            float n = float.Parse(sh.inputAmount.text);
            sh.inputAmount.text = (n - 1).ToString();
        }
    }

    public void BlueToggle()
    {
        sh.CostPerOne.text = "$10";
        sh.ForOneBullet = 10;
        sh.InputField();
        sh.description.text = "Blue Plasma - is able to freeze nearby enemies for a few seconds";
    }  
    public void YellowToggle()
    {
        sh.CostPerOne.text = "$25";
        sh.ForOneBullet = 25;
        sh.InputField();
        sh.description.text = "Yellow Plasma - causes an explosion that blow nearby enemies up ";
    }  
    public void RedToggle()
    {
        
        sh.CostPerOne.text = "$35";
        sh.ForOneBullet = 35;
        sh.InputField();
        sh.description.text = "Red Plasma - creates a circle of electrical discarge damaging enemies";
    }

    public void Buy()
    {
        GameObject SelectedItem = sh.Buttonsgroup.ActiveToggles().FirstOrDefault().gameObject;
        float MONEY = float.Parse(sh.moneyT.text) - float.Parse(sh.calcCost.text);
        switch (SelectedItem.name)
        {
            case "blue":
                sh.SetBluePlasma(MONEY);
                    break;
            case "yellow":
                sh.SetYellowPlasma(MONEY);
                break;
            case "red":
                sh.SetRedPlasma(MONEY);
                break;

        }
    }

    public void InputChanged()
    {
        sh.InputField();
    }
}
