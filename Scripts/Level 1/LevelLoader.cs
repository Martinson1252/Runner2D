using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    
    public static Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    
   public static void PlayAgain()
    {
        SceneManager.LoadScene(scene.name);
        MoneyText.SetMoney(0);
    }


   public void LoadNextLevel()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
       
    }

    public static void LoadFirstLevel()
    {
        SceneManager.LoadScene((1));
    }

    public static void PauseGame()
    {
        Time.timeScale = 0f;
    }
    
    public static void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public static void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    
    
    public static void WaitTillGameLoaded()
    {
        Time.timeScale = 0;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    
   public static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    { 
        Time.timeScale = 1;
    }
}
