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
    public static BossManager boss;
    public static bool allowMove, isStunned;
    public static BossState state;
    private static int stage; // Start at stage 0 (ranged)
    private static float health;
    [SerializeField]
    private static float maxHealth = 12;
    private static float stunTimer;
    [SerializeField]
    private static float stunDuration;
    private static Transform healthBar;
    public static Vector3 standPos = new Vector3(9.5f, 0, -10.78f);
    private void Start()
    {
        health = maxHealth;
        player = FindObjectOfType<PlayerManager>().GetComponent<Transform>();
        boss = FindObjectOfType<BossManager>();
        allowMove = false;
        state = BossState.RANGED;
        stage = 0; // Start at stage 0 (ranged)
        healthBar = FindObjectOfType<BossHealthBar>().transform;
    }
    private void Update()
    {
        if (isStunned)
        {
            if (stunTimer <= 0) isStunned = false;
            else stunTimer -= Time.deltaTime;
        }
    }
    private static void SwitchState()
    {
        if (state == BossState.MELEE)
        {
            state = BossState.RANGED;
            boss.transform.position = standPos;
        }
        else
        {
            state = BossState.MELEE;
        }
    }
    private static void BossDeath()
    {
        allowMove = false;
        Debug.Log("Boss dead");
    }
    public static void DamageBoss()
    {
        health -= 1;
        Debug.Log(health);
        healthBar.localScale = new Vector3(Mathf.Max(0, health / maxHealth), healthBar.localScale.y, healthBar.localScale.z);
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
    public static void Stun()
    {
        isStunned = true;
        stunTimer = stunDuration;
    }
}
