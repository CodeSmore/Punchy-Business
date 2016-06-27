using UnityEngine;
using System.Collections;

public class MomentumProgressController : MonoBehaviour {

	[SerializeField]
	private GameObject[] indicatorPanels = null;

	private MomentumController momentumController;

	// Use this for initialization
	void Start () {
		momentumController = GameObject.FindObjectOfType<MomentumController>();
	}
	
	public void UpdateIndicators () {
		for (int i = indicatorPanels.Length; i > 0; i--) {
			if (momentumController.GetMomentumProgress() == i) {
				for (int k = 0; k < i; k++) {
					indicatorPanels[k].SetActive(false);
				}
			}
		}
	}

	public void ResetIndicators () {
		foreach (GameObject indicator in indicatorPanels) {
			indicator.SetActive(true);
		}
	}
}
