using UnityEngine;
using System.Collections;

public class RangedEnemyController : MonoBehaviour {

	[SerializeField]
	private GameObject projectile = null;
	[SerializeField]
	private Transform projectileLaunchPoint = null;

	[SerializeField]
	private float fireRate = 0;
	private float throwTimer = 0;

	private PlatformerEnemyController enemy;
	private PlatformerSoundController soundController;


	void Start () {
		enemy = GetComponent<PlatformerEnemyController>();	
		soundController = GameObject.FindObjectOfType<PlatformerSoundController>();

		// ensures projectile is thrown up activation
		throwTimer = fireRate;
	}

	// Update is called once per frame
	void Update () {
		if (enemy.GetIsActive()) {
			throwTimer += Time.deltaTime;

			if (throwTimer >= fireRate) {
				throwTimer = 0;
				Fire();
			}
		}
	}

	void Fire () {
		GameObject newProjectile = Instantiate(projectile, projectileLaunchPoint.position, projectile.transform.rotation) as GameObject;

		newProjectile.GetComponent<EnemyProjectile>().SetDirection(Mathf.Clamp((int)-transform.localScale.x, -1, 1));
		soundController.PlaySpearThrow();
	}
}
