using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium_Tank : MonoBehaviour
{
    public enemy en;
    // Start is called before the first frame update
    void Start()
    {
        en.Pushable = true;
        en.Freezable = true;
        en.ExplosionSensitive = true;
    }

  
}
