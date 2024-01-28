using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private string playerState = "Melee";
    public Animator animate;
    //private int blockTime;

    //Reference to Input System: Attack
    public InputActionReference attack;
    public InputActionReference ability;
    public InputActionReference switchP;

    //When Button is pressed, will call to Input System to do action
    private void OnEnable()
    {
        attack.action.started += AttackCall;
        ability.action.started += AbilityCall;
        switchP.action.started += SwitchCall;
    }

    private void OnDisable()
    {
        attack.action.started -= AttackCall;
        ability.action.started -= AbilityCall;
        switchP.action.started -= SwitchCall;
    }

    //Melee and Range Attack Response
    private void AttackCall(InputAction.CallbackContext call)
    {
        Debug.Log("Attack");
        if (playerState == "Melee")
        {
            animate.SetTrigger("MeleeTrig");
        }

        else if(playerState == "Range")
        {
            animate.SetTrigger("RangeTrig");
        }
    }

    //Melee and Range Ability Response
    private void AbilityCall(InputAction.CallbackContext call)
    {
        Debug.Log("Ability");

        if (playerState == "Melee")
        {
            animate.SetTrigger("BlockTrig");
        }

        /*
        else if (playerState == "Range")
        {
            animate.SetTrigger("DashTrig, true);
            ResetBool("DashButton");
        }
        */
    }

    //Switch to Melee/Range Player
    private void SwitchCall(InputAction.CallbackContext call)
    {
        if (playerState == "Melee")
        {
            playerState = "Range";
            Debug.Log("Switched to Range");
        }

        else if (playerState == "Range")
        {
            playerState = "Melee";
            Debug.Log("Switched to Melee");
        }

    }

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
