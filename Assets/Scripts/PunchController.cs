using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PunchController : MonoBehaviour {

	[SerializeField]
	private Button[] punchButtons = null;
	[SerializeField]
	private Image punchTimerSprite = null;

	private Animator playerAnimator;

	private bool isPunching = false;
	private float punchExecuteTime = 0;
	private float punchTimer = 0;

	// Use this for initialization
	void Start () {
		playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

		punchTimerSprite.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (punchTimer >= punchExecuteTime) {
			punchTimerSprite.fillAmount = 0;
			isPunching = false;

			punchTimer = 0;
		}

		if (isPunching) {
			punchTimerSprite.fillAmount = punchTimer / punchExecuteTime;

			punchTimer += Time.deltaTime;
		} 
	}

	public void LeftJab () {
		if (!isPunching) {
			playerAnimator.SetTrigger("Left Jab Trigger");
			punchExecuteTime = .5f;

			DisableAllButtons();

			isPunching = true;
		}
	}

	public void RightJab () {
		if (!isPunching) {
			playerAnimator.SetTrigger("Right Jab Trigger");
			punchExecuteTime = .5f;

			DisableAllButtons();

			isPunching = true;
		}
	}

	public void LeftHook () {
		if (!isPunching) {
			playerAnimator.SetTrigger("Left Hook Trigger");
			punchExecuteTime = 1f;

			DisableAllButtons();

			isPunching = true;
		}
	}

	public void RightHook () {
		if (!isPunching) {
			playerAnimator.SetTrigger("Right Hook Trigger");
			punchExecuteTime = 1f;

			DisableAllButtons();

			isPunching = true;
		}
	}

	public void LeftUppercut () {
		if (!isPunching) {
			playerAnimator.SetTrigger("Left Uppercut Trigger");
			punchExecuteTime = 1.5f;

			DisableAllButtons();

			isPunching = true;
		}
	}

	public void RightUppercut () {
		if (!isPunching) {
			playerAnimator.SetTrigger("Right Uppercut Trigger");
			punchExecuteTime = 1.5f;

			DisableAllButtons();

			isPunching = true;	
		}
	}

	void DisableAllButtons () {
		foreach (Button button in punchButtons) {
			button.interactable = false;
		}
	}

	public void EnableAllButtons () {
		foreach (Button button in punchButtons) {
			button.interactable = true;
		}
	}
}
