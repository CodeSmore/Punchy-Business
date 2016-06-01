using UnityEngine;
using System.Collections;

public class PlayerDamageDealer : MonoBehaviour {

	[SerializeField]
	int jabDamage, hookDamage, uppercutDamage;

	private EnemyController enemyController;
	private EnemyHealthBar enemyHealthBar;
	private PunchController punchController;

	// Use this for initialization
	void Start () {
		enemyController = GameObject.FindObjectOfType<EnemyController>();
		enemyHealthBar = GameObject.FindObjectOfType<EnemyHealthBar>();
		punchController = GameObject.FindObjectOfType<PunchController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ExecuteJabDamage () {
		DealDamage(jabDamage);

		punchController.EnableAllButtons();
	}

	public void ExecuteHookDamage () {
		DealDamage(hookDamage);

		punchController.EnableAllButtons();
	}

	public void ExecuteUppercutDamage () {
		DealDamage(uppercutDamage);

		punchController.EnableAllButtons();
	}

	void DealDamage (int damageToDeal) {
		if (enemyController.GetEnemyState() == EnemyState.Vulnerable) {
			enemyHealthBar.TakeDamage(damageToDeal);
		} else if (enemyController.GetEnemyState() == EnemyState.Defense) {
			// trigger block animation
		}
	}
}
