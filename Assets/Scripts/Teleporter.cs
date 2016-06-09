using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	[SerializeField]
	private GameObject destination = null;

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			collider.gameObject.transform.position = destination.transform.position;
		}
	}
}
