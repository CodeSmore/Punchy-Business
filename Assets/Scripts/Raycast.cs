using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	private MeleeEnemyController meleeEnemyController;
	private PlatformerEnemyController platformerEnemyController;
	private Animator meleeAnimator;

	[SerializeField]
	private float changeDirectionDistance = 0;
	private float originalDistanceToGround = 0;
	[SerializeField]
	private LayerMask groundLayerToHit = -1;
	[SerializeField]
	private float attackTriggerDistance = 0;
	[SerializeField]
	private LayerMask playerLayerToHit = -1;

	private Vector2 originVector;
	private RaycastHit2D hitGround;
	private RaycastHit2D hitPlayer;


	// Use this for initialization
	void Start () {
		meleeEnemyController = GetComponentInParent<MeleeEnemyController>();
		platformerEnemyController = GetComponentInParent<PlatformerEnemyController>();
		meleeAnimator = GetComponentInParent<Animator>();

		originVector = new Vector2 (transform.position.x, transform.position.y);

		hitGround = Physics2D.Raycast(new Vector2 (originVector.x, originVector.y), Vector2.down, 5f, groundLayerToHit);
		originalDistanceToGround = hitGround.distance;
	}
	
	// Update is called once per frame
	void Update () {
		CheckGroundRaycast();
		CheckEnemyRaycast();
	}

	private void CheckGroundRaycast () {
		if (platformerEnemyController.GetIsActive()) {
			// create downward raycast
			originVector = new Vector2 (transform.position.x, transform.position.y);

			hitGround = Physics2D.Raycast(new Vector2 (originVector.x, originVector.y), Vector2.down, 5f, groundLayerToHit);

			// 'hitGround.point' reverts to (0,0) if hitGround == false, so it's set to max distance down instead
			if (!hitGround) {
				Debug.DrawLine(originVector, new Vector2 (originVector.x, originVector.y - 2), Color.red);
			} else {
				Debug.DrawLine(originVector, hitGround.point, Color.red);
			} 

			// if raycast length exceeds limit...
			// meleeEnemyController.ChangeDirection()

			if (hitGround.distance > changeDirectionDistance || hitGround.distance < originalDistanceToGround) {
				meleeEnemyController.ChangeDirection();
			}
		}
	}

	private void CheckEnemyRaycast () {
		// create horizontal raycast
		originVector = new Vector2 (transform.position.x, transform.position.y);

		hitPlayer = Physics2D.Raycast(new Vector2 (originVector.x, originVector.y), new Vector2(meleeEnemyController.GetDirection(), 0), 5f, playerLayerToHit);

		// 'hit.point' reverts to (0,0) if hit == false, so it's set to max distance instead
		if (!hitPlayer) {
			Debug.DrawLine(originVector, new Vector2 (originVector.x + 5 * meleeEnemyController.GetDirection(), originVector.y), Color.red);
		} else {
			Debug.DrawLine(originVector, hitPlayer.point, Color.red);
		} 

		// if raycast length is shorter than limit...
		// activate melee animation and halt movement
		if (!hitPlayer || hitPlayer.distance > attackTriggerDistance) {
			meleeEnemyController.EnableMovement();
			meleeAnimator.SetBool("PlayerWithinReach", false);
		} else if (hitPlayer.distance < attackTriggerDistance) {
			// enemy animator.setTriggerAttack && meleeEnemyController.ToggleMovement()
			meleeAnimator.SetBool("PlayerWithinReach", true);
			meleeEnemyController.DisableMovement();
		} 
	}
}
