﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject item;
	private Transform player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	public void SpawnDroppedItem()
	{
		Vector3 playerPos = new Vector3 (player.position.x, player.position.y, player.position.z + 3);
		Instantiate (item, playerPos, Quaternion.identity);
	}
}
