using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    public Animator player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        player.SetBool("OnGround",true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.SetBool("OnGround",false);
        player.SetBool("move",false);
    }
}
