using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MoneyText : MonoBehaviour
{
    // Start is called before the first frame update
    public static int MoneyVal = 0;
    public Text Money_Text;

    // Update is called once per frame
    void Update()
    {
        Money_Text.text =  MoneyVal.ToString();
        
    }

    public static void  AddMoney(int number)
    {
        MoneyVal = MoneyVal + number;
    }

    public static void SetMoney(int number)
    {
        MoneyVal = number;
    }
}
