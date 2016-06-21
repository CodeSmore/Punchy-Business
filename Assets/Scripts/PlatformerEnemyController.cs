using UnityEngine;
using System.Collections;

public class PlatformerEnemyController : MonoBehaviour {

	[SerializeField]
	private int health = 0;

	[SerializeField]
	private bool isActive = false;

	private PlatformerSoundController soundController;

	// Use this for initialization
	void Start () {
		soundController = GameObject.FindObjectOfType<PlatformerSoundController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "MainCamera") {
			isActive = true;
		}

		if (collider.tag == "Player Weapon") {
			soundController.PlayOthelloHitsMob();

			health -= collider.GetComponent<PlayerWeapon>().GetAttackValue();

			if (health <= 0) {
				Destroy(gameObject);
			}
		}
	}

	public bool GetIsActive () {
		return isActive;
	}
}
