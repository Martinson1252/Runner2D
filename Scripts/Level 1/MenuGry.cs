using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGry : MonoBehaviour
{
    public  GameObject gameMenu;
    public bool AutoRun = true;
    public static bool GamePaused = false;
    // Start is called before the first frame update

   //menu w grze (NIE glowne)

   
    
    public void BUTTON_ResumeTheGame()
    {
        gameMenu.SetActive(false);
        LevelLoader.ResumeGame();
        GamePaused = false;
    }

    public void Restart()
    {
        LevelLoader.PlayAgain();
    }

    public void BackToMainMenu()
    {
        LevelLoader.GoToMainMenu();
        Time.timeScale = 1;
    }
}
