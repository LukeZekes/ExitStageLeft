using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropProjectile : MonoBehaviour
{
    public float fallSpeed;
    bool isDropping = false;
    IEnumerator Drop()
    {
        yield return new WaitForSeconds(1);
        isDropping = true;
    }
    private void OnEnable()
    {
        StartCoroutine(Drop());
    }

    private void Update()
    {
        if (isDropping)
        {
            transform.Translate(-Vector3.up * fallSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
