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
    private int stage; // Start at stage 0 (ranged)
    private float health;
    [SerializeField]
    private float maxHealth;
    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            if (stage == 0 && health <= maxHealth * 0.75f)
            {
                // Move to stage 1 (melee)
                allowMove = true;
                state = BossState.MELEE;
                stage = 1;
            }
            else if (stage == 1 && health <= maxHealth * 0.5f)
            {
                // Move to stage 2 (ranged)
                allowMove = false;
                state = BossState.RANGED;
                stage = 2;
            }
            else if (stage == 2 && health <= maxHealth * 0.25f)
            {
                // Move to stage 3 (melee)
                allowMove = true;
                state = BossState.MELEE;
                stage = 3;
            }
            else if (health <= 0)
            {
                health = 0;
                BossDeath();
            }
        }
    }

    private void Start()
    {
        health = maxHealth;
        if (player == null) player = FindObjectOfType<PlayerManager>().GetComponent<Transform>();
        allowMove = false;
        state = BossState.RANGED;
        stage = 0; // Start at stage 0 (ranged)
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
        allowMove = false;
        Debug.Log("Boss dead");
    }
}
