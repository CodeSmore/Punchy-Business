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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		throwTimer += Time.deltaTime;

		if (throwTimer >= fireRate) {
			throwTimer = 0;
			Fire();
		}
	}

	void Fire () {
		GameObject newProjectile = Instantiate(projectile, projectileLaunchPoint.position, projectile.transform.rotation) as GameObject;

		newProjectile.GetComponent<EnemyProjectile>().SetDirection(Mathf.Clamp((int)-transform.localScale.x, -1, 1));
	}
}
