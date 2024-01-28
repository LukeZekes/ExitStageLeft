using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    Transform player;
    public float offset = 5.0f;
    public float distFromOffset;
    public float scrMultiplier; // 0 to 1
    float limit = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerManager>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z < (limit - distFromOffset) && player.position.z > (-limit + distFromOffset))
        {
            if (player.position.z > (offset / scrMultiplier))
            {
                Debug.Log("Scroll left.");
                transform.position = new Vector3(transform.position.x, transform.position.y, (-player.position.z * scrMultiplier) + offset - distFromOffset);
            }
            else if (player.position.z < (offset / scrMultiplier))
            {
                Debug.Log("Scroll right.");
                transform.position = new Vector3(transform.position.x, transform.position.y, (-player.position.z * scrMultiplier) + offset - distFromOffset);
            }
        }
        else Debug.Log("Stop scrolling.");
    }
}
