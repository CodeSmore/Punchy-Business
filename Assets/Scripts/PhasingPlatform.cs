using UnityEngine;
using System.Collections;

public class PhasingPlatform : MonoBehaviour {

	[SerializeField]
	private BoxCollider2D boxCollider = null;

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			boxCollider.enabled = false;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Player") {
			boxCollider.enabled = true;
		}
	}
}
