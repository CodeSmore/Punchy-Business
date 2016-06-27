using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour {
	
	private float currentHealth;
	[SerializeField]
	private float maxHealth = 0;
	private float healthRatio;

	private Image healthBarImage;
	private Text healthBarText;

	private MomentumController momentumController;

	// Use this for initialization
	void Start () {
		healthBarImage = GetComponent<Image>();
		healthBarText = GetComponentInChildren<Text>();
		momentumController = GameObject.FindObjectOfType<MomentumController>();

		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		HandleHealthBar ();

		HandleDeath ();
	}
	
	void HandleHealthBar () {
		healthRatio = currentHealth / maxHealth;

		healthBarImage.fillAmount = healthRatio;
		healthBarText.text = currentHealth + " / " + maxHealth;

		// Adjust color of healthbar
		if (healthRatio > 0.50f) {
			// green
			healthBarImage.color = Color.green;
		} else if (healthRatio > 0.25f) {
			// yellow
			healthBarImage.color = Color.yellow;
		} else {
			//red
			healthBarImage.color = Color.red;
		}
	}

	void HandleDeath () {
		if (currentHealth <= 0) {
			LevelManager.LoadScene("Lose Scene");
		}
	}

	public void TakeDamage (int damage) {
		currentHealth -= damage;

		// reset momemtum progress
		momentumController.SubtractWhenHit();
	}
}
