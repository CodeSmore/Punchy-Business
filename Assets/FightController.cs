using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FightController : MonoBehaviour {

	[SerializeField]
	private Text roundText = null, timerText = null;
	
	[SerializeField]
	private float secondsPerRound = 0, numberOfRounds = 0;

	private int currentRound = 1;

	private float fightTimer = 0;
	private bool startTimer = true;

	LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		fightTimer = secondsPerRound;
	}
	
	// Update is called once per frame
	void Update () {
		HandleTimer();
		FormatTimer();
	}

	void HandleTimer () {
		if (startTimer) {
			fightTimer -= Time.deltaTime;
		}

		if (fightTimer <= 0) {
			// end round
			// trigger bell sound, stop animations, fade to black, show round card, begin next round
			currentRound++;

			if (currentRound > numberOfRounds) {
				// load lose screen
				levelManager.LoadSceneButton("Lose Scene");
			}

			roundText.text = "Round " + currentRound;
		}
	}

	void FormatTimer () {
		int minutes = Mathf.FloorToInt(fightTimer / 60f);
		int seconds = Mathf.FloorToInt(fightTimer - minutes * 60);
		string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

		timerText.text = niceTime;
	}
}
