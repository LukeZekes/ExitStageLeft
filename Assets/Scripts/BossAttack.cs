using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    private float maxAttackTimer = 100; // Number of frames between attacks
    private float attackTimer;
    [SerializeField]
    private float axeAttackRange, breathAttackRange;
    [SerializeField]
    private GameObject[] dropPoints;
    void Start()
    {
        attackTimer = maxAttackTimer;
    }
    private void Update()
    {
        if (!BossManager.isStunned)
        {
            if (attackTimer <= 0)
            {
                int rand = Random.Range(0, 2); // Randomly pick 0 or 1
                                               // Attack
                if (BossManager.state == BossManager.BossState.MELEE)
                {
                    // Stop movement while attacking
                    BossManager.allowMove = false;
                    float distanceToPlayer = (BossManager.player.position - transform.position).magnitude;
                    // Pick a melee attack randomly if both are possible, otherwise pick axe attack if only that is possible, otherwise do a fire breath that will miss
                    if (distanceToPlayer <= axeAttackRange && distanceToPlayer <= breathAttackRange)
                    {
                        if (rand == 0) AxeAttack();
                        else FireBreathAttack();
                    }
                    else if (distanceToPlayer <= axeAttackRange) AxeAttack();
                    else FireBreathAttack();
                    BossManager.allowMove = true;
                }
                else
                {
                    // Pick a ranged attack
                    // if (rand == 0) StartCoroutine(FallingProjectileAttack());
                    // else FireballAttack();
                    StartCoroutine(FallingProjectileAttack());
                }

                attackTimer = maxAttackTimer;
            }
            attackTimer -= Time.deltaTime;
        }
    }

    void AxeAttack()
    {
        Debug.Log("Axe");
    }
    void FireBreathAttack()
    {
        Debug.Log("Fire breath");
    }
    IEnumerator FallingProjectileAttack()
    {
        Debug.Log("Falling projectile");
        foreach (GameObject dropPoint in dropPoints)
        {
            dropPoint.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
    void FireballAttack()
    {
        Debug.Log("Fireball attack");
    }
}
