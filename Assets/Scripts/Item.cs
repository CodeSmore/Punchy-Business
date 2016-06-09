﻿using UnityEngine;
using System.Collections;

public enum ItemType {cherry, bell, boomerang};

public class Item : MonoBehaviour {

	[SerializeField]
	private ItemType itemType = ItemType.cherry; 

	[SerializeField]
	private float rotationSpeed = 0;

	[SerializeField]
	private BellPlaceholder bellPlaceholder = null;

	private float zRotation;

	private HealthCircle healthCircle;
	private Launcher playerLauncher;

	void Start () {
		healthCircle = GameObject.FindObjectOfType<HealthCircle>();
		playerLauncher = GameObject.FindObjectOfType<Launcher>();
	}

	void Update () {
		if (itemType == ItemType.boomerang) {
			
			zRotation += rotationSpeed * Time.deltaTime;
			transform.Rotate(new Vector3 (0f, 0f, rotationSpeed * Time.deltaTime));
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log("Hitting something");
		if (collider.tag == "Player") {
			// blah blah blah
			CollectItem();

			Destroy(gameObject);
		}
	}

	void CollectItem () {
		if (itemType == ItemType.cherry) {
			healthCircle.GainHealth(1);
		} else if (itemType == ItemType.boomerang) {
			// set player to have boomerang, enable button
			playerLauncher.UnlockBoomerang();
		} else if (itemType == ItemType.bell) {
			// update UI
			bellPlaceholder.SetCollected();
		}
	}
}
