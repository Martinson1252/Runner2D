using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    public  GameObject gameMenu;
    public static bool GamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused==true)
                ResumeTheGame();
            else
                PauseTheGame();

        }
    }
    
    void PauseTheGame()
    {
        gameMenu.SetActive(true);
        LevelLoader.PauseGame();
        GamePaused = true;
    }

    public void ResumeTheGame()
    {
        gameMenu.SetActive(false);
        LevelLoader.ResumeGame();
        GamePaused = false;
    }
}
