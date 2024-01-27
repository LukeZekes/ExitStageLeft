using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public enum BossState
    {
        MELEE = 0,
        RANGED = 1
    }
    public static Transform player;
    public static bool allowMove;
    public static BossState state;
    private int health;
    public int Health
    {
        get { return this.health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                BossDeath();
            }
        }
    }

    private void Start()
    {
        state = BossState.MELEE;
        health = 100;
        if (player == null) player = FindObjectOfType<PlayerManager>().GetComponent<Transform>();
        allowMove = true;
    }
    private void SwitchState()
    {
        if (state == BossState.MELEE)
        {
            state = BossState.RANGED;
        }
        else
        {
            state = BossState.MELEE;
        }
    }
    private void BossDeath()
    {

    }
}
