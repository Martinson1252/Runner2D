using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Progress : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public Slider slider;
    public Transform begin;
    public Transform end;
    private float PlayerDistance;
    private float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = Math.Abs(end.position.x - begin.position.x);
        slider.maxValue = maxDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerDistance = Math.Abs(Player.position.x-begin.position.x);
        slider.value = PlayerDistance;
        Console.Out.WriteLine(Player.position.x);
    }
}
