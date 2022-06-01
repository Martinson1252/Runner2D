using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour
{
    [SerializeField] private GameObject Tank;
    Spawn sp = new Spawn();
    float cEnem = 2;
    // Start is called before the first frame update
    void Start()
    {
        sp.GetScreen();
    }


    private void FixedUpdate()
    {
        if(countToEnemy())
        {
            Tank.transform.GetChild(2).gameObject.SetActive(false);
            sp.SpawnTank(Tank,  1.75f, 10, sp.SetRandomPosition()); 
        }
    }

    private bool countToEnemy()
    {
        cEnem -= Time.deltaTime;
        if (cEnem <= 0) { cEnem = 2; return true; }
        else
            return false;
    }
}
