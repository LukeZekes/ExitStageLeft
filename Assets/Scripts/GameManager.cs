using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager player;
    public BossManager boss;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) PlayerManager.TakeDamage();
    }
}
