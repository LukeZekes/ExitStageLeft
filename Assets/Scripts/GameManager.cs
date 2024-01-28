using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public PlayerManager player;
    static public BossManager boss;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        boss = FindObjectOfType<BossManager>();
        GetComponent<InputActionManager>().AssignAnimator();
    }
}
