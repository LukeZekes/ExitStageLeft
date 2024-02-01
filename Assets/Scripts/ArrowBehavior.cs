using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public GameObject origin;
    SpriteRenderer sr;
    public Vector3 vel;
    public float arrowSpeed;

    // Start is called before the first frame update

    void Awake()
    {
        sr = origin.GetComponent<SpriteRenderer>();

        vel = new Vector3(arrowSpeed, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vel * Time.deltaTime);
    }

    
}
