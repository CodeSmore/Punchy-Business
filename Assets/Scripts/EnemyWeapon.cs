using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {

	[SerializeField]
	private int power = 0;

	private HealthCircle playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = GameObject.FindObjectOfType<HealthCircle>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			playerHealth.LoseHealth(power);
		}
	}
}
