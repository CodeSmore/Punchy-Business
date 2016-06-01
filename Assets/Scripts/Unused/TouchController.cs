using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchController : MonoBehaviour {

	private EventSystem eventSystem;

	private Camera mainCamera;

	private EnemyHealthBar enemyHealthBar;
	private EnemyController enemyController;

	[SerializeField]
	private GameObject powImage = null;


	// Use this for initialization
	void Start () {
		eventSystem = GameObject.FindObjectOfType<EventSystem>();
		enemyHealthBar = GameObject.FindObjectOfType<EnemyHealthBar>();
		enemyController = GameObject.FindObjectOfType<EnemyController>();
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && eventSystem.currentSelectedGameObject == null) {

			Vector3 pressedPosition = new Vector3 (mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);

			// put POW! where player taps
			Instantiate(powImage, pressedPosition, Quaternion.identity);

			if (pressedPosition.x < 0 /*center of screen*/) {
				PunchLeft();
			} else {
				PunchRight();
			}
		}
	}

	void OnMouseUp () {
		eventSystem.currentSelectedGameObject.Equals(null);
	}

	void PunchLeft () {
		if (enemyController.GetEnemyState() == EnemyState.Vulnerable) {
			enemyHealthBar.TakeDamage(1);
		}
	}

	void PunchRight () {
		if (enemyController.GetEnemyState() == EnemyState.Vulnerable) {
			enemyHealthBar.TakeDamage(1);
		}
	}
}
