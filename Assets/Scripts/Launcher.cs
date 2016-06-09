﻿using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

	[SerializeField]
	private Button boomerangButton = null;
	[SerializeField]
	private GameObject boomerangPrefab = null;

	[SerializeField]
	private bool isBoomerangInFlight = false;

	private bool isUnlocked = false;

	// Use this for initialization
	void Start () {
		// disable button
		boomerangButton.interactable = false;
	}
	
	public void UnlockBoomerang () {
		boomerangButton.interactable = true;
		isUnlocked = true;
	}

	public void ThrowBoomerang () {
		// instantiate boomerang prefab from launcher position
		if (!isBoomerangInFlight && isUnlocked) {
			Instantiate(boomerangPrefab, transform.position, Quaternion.identity);

			isBoomerangInFlight = true;
		}
	}

	public void ResetBoomerang () {
		isBoomerangInFlight = false;
	}
}
