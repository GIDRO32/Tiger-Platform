using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private float movespeed;
    void Start () {

    }

    // Update is called once per frame
    void Update () 
    {
        movespeed = PlayerPrefs.GetFloat("Speed", movespeed);
        transform.Translate(movespeed, 0, 0);
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.tag == "Boarder")
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }
}
