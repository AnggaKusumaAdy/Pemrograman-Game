using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pemukul : MonoBehaviour
{
    public float kecepatan;
    public float BatasKanan;
    public float batasKiri;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * kecepatan * Time.deltaTime;
        

        float nextPos = transform.position.x + moveHorizontal;
        if (nextPos > BatasKanan)
        {
            moveHorizontal = 0;
        }
        if (nextPos < batasKiri)
        {
            moveHorizontal = 0;
        }
        transform.Translate(moveHorizontal, 0, 0);
    }
}
