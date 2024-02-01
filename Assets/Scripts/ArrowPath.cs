using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPath : MonoBehaviour
{
    private GameObject origin;
    public GameObject arrow;
    SpriteRenderer sr;
    Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(arrow, new Vector3(0f, 0f, 0f), Quaternion.identity);
        origin = FindObjectOfType<PlayerManager>().gameObject;
        sr = origin.GetComponent<SpriteRenderer>();
        transform.position = origin.transform.position;

        vel = sr.flipX ? new Vector3(0.2f, 0.0f, 0.0f) : new Vector3(-0.2f, 0.0f, 0.0f);
        GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vel;
    }
}