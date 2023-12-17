using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform ShootPos;
    public GameObject Bullet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(Bullet, ShootPos.transform.position, transform.rotation);
        }
    }
}