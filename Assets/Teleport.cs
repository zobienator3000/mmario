using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointTeleport;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.GameObject.tag == "Player")
        {


            collision.GameOject.transform.position = pointTeleport.GameObject.transform.position;


        }
                
                
     }

}