using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum PlayerState {idle, blocking, punching, dodgingLeft, dodgingRight};

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private Button[] punchButtons = null;
	[SerializeField]
	private Button[] dodgeButtons = null;

	[SerializeField]
	private Image actionTimerSprite = null;

	private Animator playerAnimator;

	private PlayerState playerState;
	private MomentumController momentumController;

	private bool isActing = false;
	private float punchExecuteTime = 0;
	private float actionTimer = 0;

	// Use this for initialization
	void Start () {
		playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
		momentumController = GameObject.FindObjectOfType<MomentumController>();

		actionTimerSprite.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActing && playerState != PlayerState.dodgingLeft && playerState!= PlayerState.dodgingRight) {
			actionTimerSprite.fillAmount = actionTimer / punchExecuteTime;

			actionTimer += Time.deltaTime;
		} 
	}

	void ResetActionTimer () {
		actionTimerSprite.fillAmount = 0;
		isActing = false;

		actionTimer = 0;
		punchExecuteTime = -1;
	}

	public void LeftJab () {
		if (!isActing && !playerAnimator.GetBool("stunned")) {
			playerAnimator.SetTrigger("Left Jab Trigger");
			SetPlayerState(PlayerState.punching);

			punchExecuteTime = .5f;

			DisableAllButtons();

			isActing = true;
		}
	}

	public void RightJab () {
		if (!isActing && !playerAnimator.GetBool("stunned")) {
			playerAnimator.SetTrigger("Right Jab Trigger");
			SetPlayerState(PlayerState.punching);

			punchExecuteTime = .5f;

			DisableAllButtons();

			isActing = true;
		}
	}

	public void LeftHook () {
		if (!isActing && !playerAnimator.GetBool("stunned")) {
			playerAnimator.SetTrigger("Left Hook Trigger");
			SetPlayerState(PlayerState.punching);

			punchExecuteTime = 1f;

			DisableAllButtons();

			isActing = true;
		}
	}

	public void RightHook () {
		if (!isActing && !playerAnimator.GetBool("stunned")) {
			playerAnimator.SetTrigger("Right Hook Trigger");
			SetPlayerState(PlayerState.punching);

			punchExecuteTime = 1f;

			DisableAllButtons();

			isActing = true;
		}
	}

	public void LeftUppercut () {
		if (!isActing && !playerAnimator.GetBool("stunned")) {
			playerAnimator.SetTrigger("Left Uppercut Trigger");
			SetPlayerState(PlayerState.punching);

			punchExecuteTime = 1.5f;

			DisableAllButtons();

			isActing = true;
		}
	}

	public void RightUppercut () {
		if (!isActing && !playerAnimator.GetBool("stunned")) {
			playerAnimator.SetTrigger("Right Uppercut Trigger");
			SetPlayerState(PlayerState.punching);

			punchExecuteTime = 1.5f;

			DisableAllButtons();

			isActing = true;	
		}
	} 

	public void SuperPunch () {
		if (!isActing && !playerAnimator.GetBool("stunned") && momentumController.GetMomentum() >= 100) {
			playerAnimator.SetTrigger("Super Trigger");
			SetPlayerState(PlayerState.punching);

			punchExecuteTime = 3f;

			DisableAllButtons();

			// reset super meter
			momentumController.SubtractMomentum(100);

			isActing = true;
		}
	}

	public void DodgeLeft () {
		if (!isActing && !playerAnimator.GetBool("stunned")) {
			playerAnimator.SetTrigger("Dodge Left Trigger");
			SetPlayerState(PlayerState.dodgingLeft);

			isActing = true;
		}
	}

	public void DodgeRight () {
		if (!isActing && !playerAnimator.GetBool("stunned")) {
			playerAnimator.SetTrigger("Dodge Right Trigger");
			SetPlayerState(PlayerState.dodgingRight);

			isActing = true;
		}
	}

	public void SetIdle () {
		isActing = false;
		SetPlayerState(PlayerState.idle);
		EnableAllButtons();
		ResetActionTimer();

		playerAnimator.SetBool("stunned", false);
	}

	public void SetPlayerState (PlayerState state) {
		playerState = state;
	}

	public PlayerState GetPlayerState () {
		return playerState;
	}

	void DisableAllButtons () {
		foreach (Button button in punchButtons) {
			button.interactable = false;
		}

		foreach (Button button in dodgeButtons) {
			button.interactable = false;
		}
	}

	public void EnableAllButtons () {
		foreach (Button button in punchButtons) {
			button.interactable = true;
		}

		foreach (Button button in dodgeButtons) {
			button.interactable = true;
		}
	}
}
