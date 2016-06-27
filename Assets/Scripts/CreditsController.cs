using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour {

	[SerializeField]
	private GameObject credits = null;


	// Use this for initialization
	void Start () {
		credits.SetActive(false);
	}
	
	public void ToggleCredits () {
		credits.SetActive(!credits.activeSelf);
	}
}
