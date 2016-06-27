using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MomentumController : MonoBehaviour {

	[SerializeField]
	private int currentMomentum = 0, amountLostWhenHit = 0, amountGainedOnCombo = 0;

	private int momentumProgress = 0;

	private Image superImage;
	private GameObject superGlowImage;
	private MomentumProgressController progressController;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		superImage = GameObject.Find("Super Panel").GetComponent<Image>();
		superGlowImage = GameObject.Find("Glow");
		progressController = GameObject.FindObjectOfType<MomentumProgressController>();

		UpdateSuperPunchImage();

		if (currentMomentum < 100 && superGlowImage) {
			superGlowImage.SetActive(false);
		}
	}

	public void AddMomentum (int amount) {
		currentMomentum += amount;

		currentMomentum = Mathf.Clamp(currentMomentum, 0, 100);
		UpdateSuperPunchImage();
	}

	public void SubtractMomentum (int amount) {
		currentMomentum -= amount;

		currentMomentum = Mathf.Clamp(currentMomentum, 0, 100);
		UpdateSuperPunchImage();

		ResetMomentumProgress();
	}

	public int GetMomentum () {
		return currentMomentum;
	}

	public void ResetMomentumProgress () {
		momentumProgress = 0;

		progressController.ResetIndicators();

		if (superGlowImage) {
			superGlowImage.SetActive(false);
		}
	}

	public void IncrementMomentumProgress () {
		momentumProgress++;

		progressController.UpdateIndicators();

		if (momentumProgress >= 3) {
			// after 3 successful punches, award meter and reset progress
			AddMomentum(amountGainedOnCombo);
		}
	}

	public void SubtractWhenHit () {
		momentumProgress = 0;

		if (superGlowImage) {
			superGlowImage.SetActive(false);
		}

		SubtractMomentum(amountLostWhenHit);
	}

	void UpdateSuperPunchImage () {
		if (superImage) {
			superImage.fillAmount = (float)(100 - currentMomentum) / 100; 

			if (currentMomentum >= 100) {
				// add glow
				superGlowImage.SetActive(true);
			}
		}
	}

	public int GetMomentumProgress () {
		return momentumProgress;
	}
}
