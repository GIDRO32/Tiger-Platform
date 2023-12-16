using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () 
    {
        float movespeed = -0.0035f;
        transform.Translate(movespeed, 0, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boarder")
        {
            Destroy(this.gameObject);
        }
    }
}
