using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDamageDealer : MonoBehaviour {

	[SerializeField]
	int jabDamage = 0, hookDamage = 0, uppercutDamage = 0;

	[SerializeField]
	private GameObject damageText = null;
	[SerializeField]
	private GameObject textDestination = null;

	private EnemyController enemyController;
	private EnemyHealthBar enemyHealthBar;
	private Animator enemyAnimator;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		enemyController = GameObject.FindObjectOfType<EnemyController>();
		enemyHealthBar = GameObject.FindObjectOfType<EnemyHealthBar>();
		enemyAnimator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
		soundController = GameObject.FindObjectOfType<SoundController>();
	}

	public void ExecuteJabDamage () {
		DealDamage(jabDamage);

		if (enemyController.GetEnemyState() == EnemyState.Vulnerable) {
			soundController.PlayTigerHitByJabOneShot();
		}
	}

	public void ExecuteHookDamage () {
		DealDamage(hookDamage);

		if (enemyController.GetEnemyState() == EnemyState.Vulnerable) {
			soundController.PlayTigerHitByHookOneShot();
		}
	}

	public void ExecuteUppercutDamage () {
		DealDamage(uppercutDamage);

		if (enemyController.GetEnemyState() == EnemyState.Vulnerable) {
			soundController.PlayTigerHitByUppercutOneShot();
		}
	}

	void DealDamage (int damageToDeal) {
		if (enemyController.GetEnemyState() == EnemyState.Vulnerable) {
			enemyHealthBar.TakeDamage(damageToDeal);

			// Trigger hit
			enemyAnimator.SetTrigger("Enemy Hit Trigger");

			SpawnDamageIndicator(damageToDeal);

		} else if (enemyController.GetEnemyState() == EnemyState.Invulnerable) {
			// trigger block animation
		} else if (enemyController.GetEnemyState() == EnemyState.Stunable) {
			enemyAnimator.SetTrigger("Enemy Stun Trigger");
		}
	}

	void SpawnDamageIndicator (int dmg) {
		// spawn red number showing dmg done
		GameObject dmgTextGameObject = Instantiate(damageText, textDestination.transform.position, Quaternion.identity) as GameObject;

		dmgTextGameObject.GetComponent<Text>().text = dmg.ToString();

		dmgTextGameObject.transform.SetParent(textDestination.transform, false);
	}
}
