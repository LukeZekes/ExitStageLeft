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

    private void BossDeath()
    {

    }
}
