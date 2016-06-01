using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void Quit () {
		Application.Quit();
	}

	public void LoadSceneButton (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public static void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void ResetLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
