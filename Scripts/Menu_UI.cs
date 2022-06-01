using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu_UI : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject GameModePanel;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject SelectLevelPanel;
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private Text Log;
    public void PlaySurvival()
    {
        SceneManager.LoadScene(1);

        Time.timeScale = 1;
    }

    public void ShowGameMode()
    {
        MainMenuPanel.SetActive(false);
        GameModePanel.SetActive(true);
    }

    public void SelectLevel()
    {
        
        GameModePanel.SetActive(false);
        SelectLevelPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        GameModePanel.SetActive(false);
        ShopPanel.SetActive(false);
    }

    public void GoToOptions()
    {
        OptionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void FromGameModeToMenu()
	{
        MainMenuPanel.SetActive(true);
        GameModePanel.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void GoToShop()
    {   
        ShopPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
 
    }

    public void eraseData()
    {
        SaveLoadManager sl = new SaveLoadManager();
        Log.text = sl.EraseData();
    }
   
    public void ShopToMenu()
    {
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        GameModePanel.SetActive(false);
        ShopPanel.SetActive(false);
    }

    public void NextLevel()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1;
	}
    
}
