using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour
{
    public InputActionAsset actions;
    private InputActionMap Melee;
    private InputActionMap Range;
    private InputAction attackM, abilityM, moveM, switchM, attackR, abilityR, moveR, switchR;
    private PlayerManager playerManager;
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        Melee = actions.FindActionMap("Melee Player", true);
        Range = actions.FindActionMap("Range Player", true);

        attackM = Melee.FindAction("Attack");
        abilityM = Melee.FindAction("Ability");
        moveM = Melee.FindAction("Move");
        switchM = Melee.FindAction("Switch");

        attackR = Range.FindAction("Attack");
        abilityR = Range.FindAction("Ability");
        moveR = Range.FindAction("Move");
        switchR = Range.FindAction("Switch");
    }

    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerMovement = playerManager.GetComponent<PlayerMovement>();
        playerAttack = playerManager.GetComponent<PlayerAttack>();

        switchM.started += Switch;
        switchR.started += Switch;

        playerMovement.enabledMoveAction = moveM;

        attackM.started += playerAttack.AttackCall;
        abilityM.started += playerAttack.AbilityCall;

        attackR.started += playerAttack.AttackCall;
        // abilityR.started += playerAttack.AbilityCall;
        playerMovement.dashAction = abilityR;

        Melee.Enable(); // Start in melee
    }
    void Switch(InputAction.CallbackContext call)
    {
        PlayerManager.SwitchPlayerState();
        if (PlayerManager.playerState == PlayerManager.PlayerState.MELEE)
        {
            Melee.Enable();
            Range.Disable();

            playerMovement.enabledMoveAction = moveM;
            playerMovement.dashAction.Disable();
        }
        else
        {
            Melee.Disable();
            Range.Enable();

            playerMovement.enabledMoveAction = moveR;
            playerMovement.dashAction.Enable();
        }
    }
    private void OnEnable()
    {
        if (PlayerManager.playerState == PlayerManager.PlayerState.MELEE) Melee.Enable();
        else Range.Enable();
    }

    private void OnDisable()
    {
        Melee.Disable();
        Range.Disable();
    }
}
