using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPACE_Restart : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
       
            if(Input.GetKeyDown(KeyCode.Space))
                LevelLoader.PlayAgain();     
        
    }
}
