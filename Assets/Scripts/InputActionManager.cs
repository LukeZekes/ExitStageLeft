using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour
{
    public InputActionAsset actions;
    public InputActionReference switchA;

    private InputActionMap Melee;
    private InputActionMap Range;
    private InputAction attackM, abilityM, moveM, attackR, abilityR, moveR;

    private PlayerManager playerManager;
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;

    private Animator animate;

    private void Awake()
    {
        Melee = actions.FindActionMap("Melee Player", true);
        Range = actions.FindActionMap("Range Player", true);

        attackM = Melee.FindAction("Attack");
        abilityM = Melee.FindAction("Ability");
        moveM = Melee.FindAction("Move");

        attackR = Range.FindAction("Attack");
        abilityR = Range.FindAction("Ability");
        moveR = Range.FindAction("Move");
    }

    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerMovement = playerManager.GetComponent<PlayerMovement>();
        playerAttack = playerManager.GetComponent<PlayerAttack>();

        switchA.action.started += Switch;

        playerMovement.enabledMoveAction = moveM;

        attackM.performed += playerAttack.AttackCall;
        abilityM.performed += playerAttack.AbilityCall;

        attackR.performed += playerAttack.AttackCall;
        abilityR.started += playerAttack.AbilityCall;
        playerMovement.dashAction = abilityR;

        Melee.Enable(); // Start in melee
        switchA.action.actionMap.Enable();

    }
    public void AssignAnimator()
    {
        animate = GameManager.player.GetComponent<Animator>();
    }
    void Switch(InputAction.CallbackContext call)
    {
        Debug.Log("Switch");
        PlayerManager.SwitchPlayerState();
        if (PlayerManager.playerState == PlayerManager.PlayerState.MELEE)
        {
            playerMovement.enabledMoveAction = moveM;
            playerMovement.dashAction.Disable();
            Melee.Enable();
            Range.Disable();

            animate.SetBool("State", false);
        }

        else
        {
            playerMovement.enabledMoveAction = moveR;
            playerMovement.dashAction.Enable();
            Melee.Disable();
            Range.Enable();

            animate.SetBool("State", true);
        }
    }
    private void OnEnable()
    {
        switchA.action.actionMap.Enable();

        // switchA.action.started += Switch;
        if (PlayerManager.playerState == PlayerManager.PlayerState.MELEE) Melee.Enable();
        else Range.Enable();
    }

    private void OnDisable()
    {
        switchA.action.actionMap.Disable();

        // switchA.action.started -= Switch;
        Melee.Disable();
        Range.Disable();
    }
}
