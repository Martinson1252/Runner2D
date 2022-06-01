using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class freezeEnemy : MonoBehaviour
{
    public float FreezeTime = 7;
    public GameObject parent;
    [SerializeField] TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        counter();
    }

    void counter()
    {
        if (FreezeTime - Time.deltaTime > 0)
        {
            text.text = (Mathf.Floor(FreezeTime -= Time.deltaTime)).ToString();
        }
        else
        {
            Destroy(gameObject);
            parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        
    }
	public void Destroy()
	{
        Destroy(gameObject);
	}
}
