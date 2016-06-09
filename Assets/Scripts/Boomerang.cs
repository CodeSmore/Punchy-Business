using UnityEngine;
using System.Collections;

public class Boomerang : MonoBehaviour {

	private int direction = 0;

	private Transform playerTransform = null;
	private Launcher playerLauncher = null;

	[SerializeField]
	private float rotationSpeed = 0;

	[SerializeField]
	private float initialSpeed = 0;
	[SerializeField]
	private float rateOfDeceleration = 0;
	[SerializeField]
	private float currentSpeed = 0;

	private bool isReturning = false;
	private bool destroyLater = false;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		playerLauncher = GameObject.FindObjectOfType<Launcher>();

		if (playerTransform.localScale.x < 0) {
			direction = -1;
		} else {
			direction = 1;
		}

		currentSpeed = initialSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		// used to ensure boomerang is not destroyed until item on boomerang is collected
		if (destroyLater == true && transform.childCount == 0) {
			Destroy(gameObject);
		}

		// Rotates boomerang :D
		Rotate();

		// boomerang will move straight in horizontal direction, decreasing in speed.
		// Once currentSpeed = 0, speed will go negative, but always in the direction of player.transform.postion
		if (currentSpeed >= 0) {
			transform.position = new Vector3 (transform.position.x + currentSpeed * Time.deltaTime * direction, transform.position.y, transform.position.z);
		} else {
			isReturning = true;
			// move towards player
			Vector3 vectorToPlayer = -(playerTransform.position - transform.position);
			vectorToPlayer.Normalize();
			Debug.Log(vectorToPlayer);

			transform.position = new Vector3 (transform.position.x + currentSpeed * vectorToPlayer.x * Time.deltaTime, transform.position.y + currentSpeed * vectorToPlayer.y * Time.deltaTime, transform.position.z);
		}

		currentSpeed -= rateOfDeceleration;
	}

	void OnDestroy () {
		playerLauncher.ResetBoomerang();
	}

	void Rotate () {
		transform.Rotate(new Vector3 (0f, 0f, rotationSpeed * Time.deltaTime));
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player" && isReturning) {
			if (transform.childCount == 0) {
				Destroy(gameObject);
			} else {
				destroyLater = true;
			}
		} else if (collider.tag == "Item") {
			collider.transform.parent = transform;
			collider.transform.localPosition = Vector3.zero;
		}
	}
}
