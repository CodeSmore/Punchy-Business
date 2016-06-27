using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	[SerializeField]
	private string sceneToLoad = null;

	private LevelManager levelManager;
	private BellPlaceholder[] bellPlaceholders;
	private MomentumController momentumController;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		bellPlaceholders = GameObject.FindObjectsOfType<BellPlaceholder>();
		momentumController = GameObject.FindObjectOfType<MomentumController>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			// if all bells are collected, grant momentum
			int numBellsCollected = 0;
			foreach (BellPlaceholder placeholder in bellPlaceholders) {
				if (placeholder.GetCollectedStatus()) {
					numBellsCollected++;
				}
			}

			if (numBellsCollected >= 3) {
				momentumController.AddMomentum(25);
			}

			levelManager.LoadSceneButton(sceneToLoad);
		}
	}
}
