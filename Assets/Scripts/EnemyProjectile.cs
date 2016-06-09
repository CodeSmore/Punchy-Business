using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {


	[SerializeField]
	private float movementSpeed = 0;
	[SerializeField]
	private int power = 0;

	private int direction = 0;

	private HealthCircle playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = FindObjectOfType<HealthCircle>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x + (direction * movementSpeed * Time.deltaTime), transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			playerHealth.LoseHealth(power);
			Destroy(gameObject);
		}
	}

	public void SetDirection (int dir) {
		direction = dir;
	}
}
