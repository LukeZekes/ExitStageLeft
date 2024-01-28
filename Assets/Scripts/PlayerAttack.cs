using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private string playerState = "Melee";
    private int blockTimer;

    public Animator animate;

    //Reference to Input System: Attack
    // [HideInInspector]
    // public InputActionMap Melee, Range;

    // ///*
    // private InputAction attackM;
    // private InputAction abilityM;

    // private InputAction attackR;
    // private InputAction abilityR;

    // public InputActionReference switchP;
    //*/

    public void Awake()
    {
        // attackM = Melee.FindAction("Attack");
        // abilityM = Melee.FindAction("Ability");

        // attackR = Range.FindAction("Attack");
        // abilityR = Range.FindAction("Ability");
    }


    //When Button is pressed, will call to Input System to do action
    // private void OnEnable()
    // {
    //     attackM.started += AttackCall;
    //     abilityM.started += AbilityCall;

    //     attackR.started += AttackCall;
    //     abilityR.started += AbilityCall;

    //     switchP.action.started += SwitchCall;
    // }

    // private void OnDisable()
    // {
    //     attackM.started -= AttackCall;
    //     abilityM.started -= AbilityCall;

    //     attackR.started -= AttackCall;
    //     abilityR.started -= AbilityCall;

    //     switchP.action.started -= SwitchCall;
    // }

    // public void Update()
    // {
    //     if (playerState == "Melee")
    //     {
    //         Melee.Enable();
    //         Range.Disable();
    //     }

    //     else if (playerState == "Range")
    //     {
    //         Melee.Disable();
    //         Range.Enable();
    //     }
    // }


    //Melee and Range Attack Response
    public void AttackCall(InputAction.CallbackContext call)
    {
        Debug.Log("Attack");

        if (PlayerManager.playerState == PlayerManager.PlayerState.MELEE)
        {
            animate.SetTrigger("MeleeTrig");

        }
        else
        {
            animate.SetTrigger("RangeTrig");
        }
    }

    //Melee and Range Ability Response
    public void AbilityCall(InputAction.CallbackContext call)
    {
        Debug.Log("Ability");

        if (playerState == "Melee")
        {
            animate.SetTrigger("BlockTrig");
        }
        else if (playerState == "Range")
        {
            animate.SetTrigger("DashTrig");
        }
    }

    //Switch to Melee/Range Player
    // private void SwitchCall(InputAction.CallbackContext call)
    // {
    //     if (playerState == "Melee")
    //     {
    //         playerState = "Range";
    //         Debug.Log("Switched to Range");
    //     }

    //     else if (playerState == "Range")
    //     {
    //         playerState = "Melee";
    //         Debug.Log("Switched to Melee");
    //     }

    // }

    public void MeleeAttack(Input value)
    {

    }

    public void RangedAttack()
    {

    }

    public void Block()
    {

    }

    public void Dash()
    {

    }

    /*
     * public void OnTriggerEnter(Collider enemy)
     * 
     * if (playing Range)
     *      if (Arrow.State == inAir)
     *      {
     *          send message to arrow for collision and damage
     *      }
     * else if (playing Dash)
     *      Player.health += 0;
     *      
     * else if (blockTime >= 0 || blockTime < 2)
     *      if (enemy.tag == "Deflective")
     *          {
     *              Send Message to Enemy
     *          }
     *      
     * else
     *      Enemy.health -= 5;
    */
}
