using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthCircle : MonoBehaviour {

	[SerializeField]
	private int currentHealth = 0;
	private int maxHealth = 8;


	private Image fillerColor;
	private LevelManager levelManager;
	private PlatformerSoundController soundController;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		fillerColor = GetComponent<Image>();
		soundController = GameObject.FindObjectOfType<PlatformerSoundController>();

		currentHealth = maxHealth / 2;

		UpdateHealthCircle();
	}

	public void UpdateHealthCircle () {
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		} else if (currentHealth <= 0) {
			levelManager.ResetLevel();
		}

		fillerColor.fillAmount = ((float)currentHealth / maxHealth);
	}

	public void GainHealth (int gains) {
		currentHealth += gains;
		UpdateHealthCircle();
	}

	public void LoseHealth (int losses) {
		soundController.PlayOthelloTakesDamage();

		currentHealth -= losses;
		UpdateHealthCircle();
	}
	

}
