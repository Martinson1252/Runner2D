using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct screenCorner
{
    public Vector3 LeftDown;
    public Vector3 LeftUp;
    public Vector3 RightUp;
    public Vector3 RightDown;

    public Vector3 SetLeftDown(Vector3 LeftDown)
    {
      return this.LeftDown = LeftDown;
    }
   public Vector3 SetLeftUp(Vector3 LeftUp)
    {
        return this.LeftUp = LeftUp;
    }
   public Vector3 SetRightDown(Vector3 RightDown)
    {
        return this.RightDown = RightDown;
    }
    public Vector3 SetRightUp(Vector3 RightUp)
    {
        return this.RightUp = RightUp;
    }

}
public class Spawn : MonoBehaviour
{
   
    float yDo, yUp;
    public screenCorner screen ;
   

    public void GetScreen()
    {
        screen.LeftDown = screen.SetLeftDown(Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)));
        screen.LeftUp = screen.SetLeftUp(Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)));
        screen.RightDown = screen.SetRightDown(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)));
        screen.RightUp = screen.SetRightUp(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0)));
        yDo = GameObject.FindGameObjectWithTag("Bottom").GetComponent<SpriteRenderer>().bounds.size.y;
        yUp = GameObject.FindGameObjectWithTag("Top").GetComponent<SpriteRenderer>().bounds.size.y;

    }



    public Vector3 SetRandomPosition()
    {
        return new Vector3(screen.RightDown.x +1,Random.Range(screen.RightDown.y+yDo,screen.RightUp.y-yUp),0);
    }

    public void SpawnBall(GameObject Ball,GameObject center)
    {
       GameObject ball = Instantiate(Ball,center.transform.position,Quaternion.identity);
     
    }

    public void SpawnTank(GameObject Prefab, float speed, float HP, Vector3 position)
    {
        
        GameObject newEnemy = Instantiate(Prefab);
        newEnemy.GetComponent<enemy>().Speed = speed;
        newEnemy.GetComponent<enemy>().maxHP = HP;
        newEnemy.GetComponent<enemy>().HP = HP;
        newEnemy.transform.position = position;
    }
}
