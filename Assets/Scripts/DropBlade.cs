using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlade : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private void OnEnable()
    {
        Instantiate(prefab, transform.position, Quaternion.Euler(0, 90, 0));
    }
}
