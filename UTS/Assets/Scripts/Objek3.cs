using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objek3 : MonoBehaviour
{
    int tumbuk;
    // Start is called before the first frame update
    void Start()
    {
        tumbuk = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "bola")
        {
            tumbuk = tumbuk - 1;

            if (tumbuk <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
