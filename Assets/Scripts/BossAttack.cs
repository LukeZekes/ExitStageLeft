using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    private float maxAttackTimer = 100; // Number of frames between attacks
    private float attackTimer;
    void Start()
    {
        attackTimer = maxAttackTimer;
    }
    private void Update()
    {
        if (attackTimer <= 0)
        {
            int rand = Random.Range(0, 2); // Randomly pick 0 or 1
            // Attack
            if (BossManager.state == BossManager.BossState.MELEE)
            {
                // Pick a melee attack
                if (rand == 0) AxeAttack();
                else FireBreathAttack();
            }
            else
            {
                // Pick a ranged attack
                if (rand == 0) FallingProjectileAttack();
                else FireballAttack();
            }

            attackTimer = maxAttackTimer;
        }
        attackTimer -= Time.deltaTime;
    }

    void AxeAttack()
    {
        Debug.Log("Axe");
    }
    void FireBreathAttack()
    {
        Debug.Log("Fire breath");
    }
    void FallingProjectileAttack()
    {
        Debug.Log("Falling projectile");
    }
    void FireballAttack()
    {
        Debug.Log("Fireball attack");
    }
}
