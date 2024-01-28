using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    Transform player;
    float offset = 5.0f;
    float limit = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerManager>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z < limit && player.position.z > -limit)
        {
            if (player.position.z > offset)
            {
                Debug.Log("Scroll left.");
                transform.position = new Vector3(transform.position.x, transform.position.y, -player.position.z + offset);
            }
            else if (player.position.z < -offset)
            {
                Debug.Log("Scroll right.");
                transform.position = new Vector3(transform.position.x, transform.position.y, -player.position.z - offset);
            }
        }
        else Debug.Log("Stop scrolling.");
    }
}
