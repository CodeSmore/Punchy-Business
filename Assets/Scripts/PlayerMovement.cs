using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float movementSpeed = 0;
	[SerializeField]
	private float encumberedMovementSpeed = 0;
	[SerializeField]
	private bool encumbered = false;
	[SerializeField]
	private bool RestrictedJump = false;
	[SerializeField]
	private Transform[] groundPoints = null;
	[SerializeField]
	private float groundRadius = 0;
	[SerializeField]
	private float jumpForce = 0;
	[SerializeField]
	private LayerMask whatIsGround = -1;

	private Rigidbody2D playerRigidbody;
	private Animator playerAnimator;
	private PlatformerSoundController soundController;

	private bool facingRight;

	[SerializeField]
	private bool isGrounded;
	private bool movementEnabled = true;
	private string groundTag;

	private float horizontal;

	private Vector3 startPosition;

	[SerializeField]

	private float startJumpYPos = 0;
	private float endJumpYPos = 0;
	[SerializeField]
	private float hardLandingThreshold = 0;
 
	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();
		soundController = GameObject.FindObjectOfType<PlatformerSoundController>();

		startPosition = transform.position;
		startJumpYPos = transform.position.y;
		endJumpYPos = transform.position.y;
	}

	void Update () {
		HandleKeyboard();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		isGrounded = CheckIsGrounded();

		HandleMovement(horizontal);
	}

	private void HandleMovement(float horizontalDirection) {
		if (movementEnabled) {
			if (isGrounded || !RestrictedJump) {
				
				float speed;

				if (encumbered) {
					speed = encumberedMovementSpeed;
				} else {
					speed = movementSpeed;
				}

				playerRigidbody.velocity = new Vector2(horizontalDirection * speed, playerRigidbody.velocity.y);
			}
			FlipImage(horizontalDirection);
		} else {
			playerAnimator.SetFloat("speed", 0);
		}
	}

	private void FlipImage (float horizontalDirection) {
		if (horizontalDirection > 0 && facingRight || horizontalDirection < 0 && !facingRight) {
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}
	}

	private bool CheckIsGrounded () {
		
		foreach (Transform point in groundPoints) {

			Collider2D[] colliders = null;
			colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

			foreach (Collider2D collider in colliders) {
				if (collider.gameObject != gameObject) {
					if (isGrounded == false) {
						// play land sound
						soundController.PlayOthelloLand();
					}

					return true;
				}
			}
		}



		return false;
	}


	private void HandleKeyboard () {
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			// move right
			horizontal = 1;

			playerAnimator.SetBool("WalkBool", true);
		} else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			// move left
			horizontal = -1;

			playerAnimator.SetBool("WalkBool", true);
		} 

		if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
			horizontal = 0;

			playerAnimator.SetBool("WalkBool", false);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			Jump();
		}
	}

	public void MoveLeft () {
		horizontal = -1;

		playerAnimator.SetBool("WalkBool", true);
	}

	public void MoveRight () {
		horizontal = 1;

		playerAnimator.SetBool("WalkBool", true);
	}

	public void ResetMovement () {
		horizontal = 0;

		playerAnimator.SetBool("WalkBool", false);
	}

	public void Jump () {
		if (CheckIsGrounded()) {
			soundController.PlayOthelloJump();

			playerRigidbody.AddForce(new Vector2(0f, jumpForce));
		}
	}

	public bool IsGrounded() {
		return isGrounded;
	}



	public void ResetVeloctiy () {
		playerRigidbody.velocity = Vector3.zero;
		playerRigidbody.angularVelocity = 0f;
	}
}
