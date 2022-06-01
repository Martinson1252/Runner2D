using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GUI_System : MonoBehaviour
{
    public GameObject M;
    public static int Professor_HP;
    public int Money_amount;
    public Text Player_lives;
    public Text MoneyText;
    public Slider slider;
    public GameObject Failed_window;
    public GameObject Win_window;
    private int Player_WAR_counts;
    // Start is called before the first frame update
    void Start()
    {
        
        Player_WAR_counts = 2;
        Player_lives.text = Player_WAR_counts.ToString();
        Professor_HP = 100;
        Player_Money_Bar_Set(Read_Money());
    }

    public void Professor_Health_Set(int value)
    {
        Professor_HP += value;
        slider.value = Professor_HP;
        if(Professor_HP<=0)
            Game_won();
    }

    public void Player_WAR_Set(int value)
    {
        if((Player_WAR_counts+=value)>=0)
        Player_lives.text = (Player_WAR_counts += value).ToString();
        else
        {
            Game_Failed();
        }
    }

    public void Player_Money_Bar_Set(int value)
    {
        MoneyText.text = (Money_amount += value).ToString();
    }

    void Game_Failed()
    {
        Time.timeScale = 0;
        Failed_window.SetActive(true);

    }

    void Game_won()
    {
        Time.timeScale = 0;
        Win_window.SetActive(true);
    }

    int Read_Money()
    {
       return Int32.Parse(File.ReadAllText(Application.dataPath+"/Log.txt"));
    }
}
