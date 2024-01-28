using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
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

    private SpriteRenderer sr;
    [HideInInspector]
    public InputAction enabledMoveAction, dashAction;

    [SerializeField]
    private Vector3 minBounds, maxBounds;

    private void Start()
    {
        dir = direction.RIGHT;
        prevDir = direction.RIGHT;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        mvmtValues = enabledMoveAction.ReadValue<Vector2>();
        dashing = dashAction.enabled ? dashAction.ReadValue<float>() > 0 && !dashLock : false;

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
        transform.Translate(playerMovement * speed * Time.deltaTime);
        if (transform.position.x < minBounds.x) transform.position = new Vector3(minBounds.x, transform.position.y, transform.position.z);
        else if (transform.position.x > maxBounds.x) transform.position = new Vector3(maxBounds.x, transform.position.y, transform.position.z);

        // if (transform.position.y < minBounds.y) transform.position = new Vector3(transform.position.x, minBounds.y, transform.position.z);
        // else if (transform.position.y > maxBounds.y) transform.position = new Vector3(transform.position.x, maxBounds.y, transform.position.z);

        if (transform.position.z < minBounds.z) transform.position = new Vector3(transform.position.x, transform.position.y, minBounds.z);
        else if (transform.position.z > maxBounds.z) transform.position = new Vector3(transform.position.x, transform.position.y, maxBounds.z);
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
