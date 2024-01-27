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
				PlayerDeath();
			}
		}
	}

	public PlayerState playerState;

	private void Start()
	{
		playerState = PlayerState.MELEE;
		health = 6;
	}

	// Switch player state
	void SwitchPlayerState()
	{
		if (playerState == PlayerState.MELEE) playerState = PlayerState.RANGED;
		else playerState = PlayerState.RANGED;
	}

	void PlayerDeath()
	{
		Debug.Log("Game over");
	}

}
