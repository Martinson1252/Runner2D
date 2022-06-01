using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{

    public GameObject _PauseMenu_;
    public Animator anim;

    public void OpenGameMenu()
    {
        if (!_PauseMenu_.activeSelf)
        {
            Time.timeScale = 0;
            _PauseMenu_.SetActive(true);
            
            anim.SetTrigger("Open");
        }
        else
        {
            anim.SetTrigger("Close");
            StartCoroutine(Example());
            
           
        }
    }

    IEnumerator Example()
    {
        
            Time.timeScale = 1;
         yield return new WaitForSeconds(.313f);
            
        

            _PauseMenu_.SetActive(false);
        
    }
}
