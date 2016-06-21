using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

	private PlatformerSoundController soundController;

	// Use this for initialization
	void Start () {
		soundController = GameObject.FindObjectOfType<PlatformerSoundController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			soundController.PlayTrampolineJumpOneShot();
		}
	}
}
