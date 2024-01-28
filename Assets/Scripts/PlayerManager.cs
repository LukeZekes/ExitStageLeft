using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public enum PlayerState
	{
		MELEE = 0,
		RANGED = 1
	}
	private static SpriteRenderer[] hearts;
	private static int health;
	public static PlayerState playerState;

	private void Start()
	{
		playerState = PlayerState.MELEE;
		health = 6;
		hearts = GameObject.Find("HealthUI").GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer h in hearts) h.enabled = true;
	}

	// Switch player state
	public static void SwitchPlayerState()
	{
		if (playerState == PlayerState.MELEE) playerState = PlayerState.RANGED;
		else playerState = PlayerState.MELEE;
	}

	private static void PlayerDeath()
	{
		Debug.Log("Game over");
	}
	public static void TakeDamage()
	{
		hearts[health - 1].enabled = false;
		health -= 1;
		if (health <= 0)
		{
			health = 0;
			PlayerDeath();
		}
	}

}
