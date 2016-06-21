using UnityEngine;
using System.Collections;

public class MeleeEnemyController : MonoBehaviour {

	[SerializeField]
	private float speed = 0;

	private int direction = 0;

	private bool movementIsEnabled = true;

	private PlatformerEnemyController platformerEnemyController;

	// Use this for initialization
	void Start () {
		direction = -1;

		platformerEnemyController = GetComponentInParent<PlatformerEnemyController>();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	public void Move () {
		if (platformerEnemyController.GetIsActive() && movementIsEnabled) {
			transform.position = new Vector3 (transform.position.x + speed * direction, transform.position.y, transform.position.z);
		}
	}

	public void ChangeDirection () {
		// reverse direciton of movement and x scale 
		direction *= -1;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}

	public int GetDirection () {
		return direction;
	}

	public void EnableMovement () {
		movementIsEnabled = true;
	}

	public void DisableMovement () {
		movementIsEnabled = false;
	}
}
