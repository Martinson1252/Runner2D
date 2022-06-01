using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyTank : MonoBehaviour
{
    public enemy en;
    // Start is called before the first frame update
    void Start()
    {
        en.Pushable = false;
        en.Freezable = true;
        en.ExplosionSensitive = false;
    }

  
}
