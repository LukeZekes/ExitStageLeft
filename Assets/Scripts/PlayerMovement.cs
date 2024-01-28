using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public enum direction
    {
        LEFT = 0,
        RIGHT = 1
    };
    direction dir, prevDir;

    private Vector3 rotation = new Vector3(0, -90, 0);
    public float speed;
    private float dashForce = 0.0f;
    private bool dashing = false, dashLock = false;

    private float hValue, vValue;
    private Vector2 mvmtValues;
    private Vector3 playerMovement;

    public GameObject Player;
    private SpriteRenderer sr;

    public InputActionReference move;
    public InputActionReference dash;
    
    private void Start()
    {
        speed = 3.0f;
        dir = direction.RIGHT;
        prevDir = direction.RIGHT;
        sr = Player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        mvmtValues = move.action.ReadValue<Vector2>();
        dashing = dash.action.ReadValue<float>() > 0 && !dashLock;

        if (dashing)
        {
            StartCoroutine(Dash(dir));
        }

        hValue = mvmtValues.x;
        vValue = mvmtValues.y;

        prevDir = dir;
        if (hValue != 0)
        {
            dir = (hValue < 0) ? direction.LEFT : direction.RIGHT;
        }

        if (prevDir != dir)
        {
            FlipSprite();
        }

        playerMovement = new Vector3(hValue + dashForce, 0.0f, vValue);
    }

    private void FixedUpdate()
    {
        Player.transform.Translate(playerMovement * speed * Time.deltaTime);
    }

    public IEnumerator Dash(direction dir)
    {
        Debug.Log("Dash called.");
        int multiplier = (dir == direction.RIGHT) ? 1 : -1;
        dashLock = true;
        dashForce = 8.0f * multiplier;
        
            while (dashForce != 0.0f)
            {
                if (dir == direction.RIGHT)
                {
                    dashForce = (dashForce / 1.2f) - 0.5f;
                    yield return new WaitForSeconds(0.03f);
                    if (dashForce < 0.0f) dashForce = 0.0f;
                }
                else
                {
                    dashForce = (dashForce / 1.2f) + 0.5f;
                    yield return new WaitForSeconds(0.03f);
                    if (dashForce > 0.0f) dashForce = 0.0f;
                }
                    
            }
        yield return new WaitForSeconds(0.2f);

        dashLock = false;
    }

    void FlipSprite()
    {
        sr.flipX = !sr.flipX;
    }
}
