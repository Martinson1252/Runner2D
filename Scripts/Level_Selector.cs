using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Selector : MonoBehaviour
{
    [SerializeField] GameObject[] level = new GameObject[10];
    GameUI savData = new GameUI();
    float levelU;
    // Start is called before the first frame update
    void Start()
    {
        savData.Load();
        Debug.Log(savData.levelUnlocked);
        levelU = savData.levelUnlocked;
        for (int i=0;i < levelU; i++)
		{
            level[i].GetComponent<Button>().interactable = true;
            level[i].transform.GetChild(1).gameObject.SetActive(false);
		}
    }

    
}
