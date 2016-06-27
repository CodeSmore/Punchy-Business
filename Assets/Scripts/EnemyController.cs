using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum EnemyState {Invulnerable, Vulnerable, Stunable};

public class EnemyController : MonoBehaviour {

	private EnemyState enemyState;
	private PlayerController playerController;
	private Animator playerAnimator;

	private PlayerHealthBar playerHealthBar;
	private SoundController soundController;

	void Start () {
		playerHealthBar = GameObject.FindObjectOfType<PlayerHealthBar>();
		soundController = GameObject.FindObjectOfType<SoundController>();
		playerController = GameObject.FindObjectOfType<PlayerController>();
		playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}

	public EnemyState GetEnemyState () {
		return enemyState;
	}

	public void SetStateToInvulnerable () {
		enemyState = EnemyState.Invulnerable;
	}

	public void SetStateToVulnerable () {
		enemyState = EnemyState.Vulnerable;
	}

	public void SetStateToStunable () {
		enemyState = EnemyState.Stunable;
	}

	// TODO add if statements so sound doesn't play when player dodges or blocks

	public void Jab () {
		if (playerController.GetPlayerState() != PlayerState.dodgingLeft && playerController.GetPlayerState() != PlayerState.dodgingRight) {
			playerHealthBar.TakeDamage(1);
			soundController.PlayJabOneShot();

			// set "stun player bool" to trigger animation
			playerAnimator.SetBool("stunned", true);
		}

	}

	public void LHook () {
		if (playerController.GetPlayerState() != PlayerState.dodgingLeft) {
			playerHealthBar.TakeDamage(2);
			soundController.PlayHookOneShot();

			// set "stun player bool" to trigger animation
			playerAnimator.SetBool("stunned", true);
		}
	}

	public void RHook () {
		if (playerController.GetPlayerState() != PlayerState.dodgingRight) {
			playerHealthBar.TakeDamage(2);
			soundController.PlayHookOneShot();

			// set "stun player bool" to trigger animation
			playerAnimator.SetBool("stunned", true);
		}
	}

	public void Uppercut () {
		if (playerController.GetPlayerState() != PlayerState.dodgingLeft && playerController.GetPlayerState() != PlayerState.dodgingRight) {
			playerHealthBar.TakeDamage(3);
			soundController.PlayUppercutOneShot();

			// set "stun player bool" to trigger animation
			playerAnimator.SetBool("stunned", true);
		}
	}

	public void EnemyFall () {
		soundController.PlayKOSoundOneShot();
	}

	public void EnemyLose () {
		SceneManager.LoadScene("Win Scene");
	}
}
