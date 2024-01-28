using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private bool facingLeft;
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float minDistanceToPlayer = 0;

    private void Start()
    {
        facingLeft = true;
    }
    void Update()
    {
        if (!BossManager.isStunned)
        {
            if (BossManager.allowMove && BossManager.state == BossManager.BossState.MELEE)
            {
                Vector3 playerPos = BossManager.player.position;
                // Flip boss around if player is on the wrong side
                if (facingLeft && playerPos.z > transform.position.z)
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -1);
                    transform.Rotate(0, 180, 0);
                    facingLeft = false;
                }
                else if (!facingLeft && playerPos.z < transform.position.z)
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
                    transform.Rotate(0, -180, 0);
                    facingLeft = true;
                }
                Vector3 towards = playerPos - transform.position;
                float distance = towards.magnitude;
                if (distance > minDistanceToPlayer)
                {
                    // Move towards player position
                    // Move along vector by speed
                    Vector3 movementVector = towards.normalized * speed * Time.deltaTime; // Could possibly put the boss inside the player's minimum distance - fix later
                    transform.position += movementVector;
                }
            }
        }
    }
}
