using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float verticalOffset;
    public float horizontalOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y != transform.position.y && player.position.y > -3 && player.position.y < 2f)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = player.position.y + verticalOffset;
            transform.position = newPosition;
        }

       
    }
}
