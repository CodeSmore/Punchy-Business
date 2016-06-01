using UnityEngine;
using System.Collections;

public enum EnemyState {Defense, Vulnerable, InvulnerableAttack};

public class EnemyController : MonoBehaviour {

	private EnemyState enemyState;

	private PlayerHealthBar playerHealthBar;

	void Start () {
		playerHealthBar = GameObject.FindObjectOfType<PlayerHealthBar>();
	}
	// Update is called once per frame
	void Update () {

	}

	public EnemyState GetEnemyState () {
		return enemyState;
	}

	public void SetStateToDefense () {
		enemyState = EnemyState.Defense;
	}

	public void SetStateToVulnerable () {
		enemyState = EnemyState.Vulnerable;
	}

	public void Punch () {
		playerHealthBar.TakeDamage(2);
	}
}
