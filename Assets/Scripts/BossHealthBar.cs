using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public Vector3 offset;
    private Transform boss;
    private void Start()
    {
        boss = FindObjectOfType<BossManager>().transform;
    }
    private void Update()
    {
        transform.position = boss.transform.position + offset;
    }
}
