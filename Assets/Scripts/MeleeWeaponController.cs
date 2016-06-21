using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class MeleeWeaponController : MonoBehaviour {

	[SerializeField]
	private GameObject fist = null;

	[SerializeField]
	private Button meleeButton = null;

	private Animator playerAnimator;
	private PlatformerSoundController soundController;

	// Use this for initialization
	void Start () {
		fist.SetActive(false);
		Debug.Log(fist.activeSelf);

		playerAnimator = GetComponentInParent<Animator>();
		soundController = GameObject.FindObjectOfType<PlatformerSoundController>();
	}

	public void Attack () {
		if (meleeButton.IsInteractable()) {
			playerAnimator.SetTrigger("Punch");
			soundController.PlayOthelloMissesMob();
		}
	}

	public void ToggleMeleeButton () {
		meleeButton.interactable = !meleeButton.IsInteractable();
	}


}
