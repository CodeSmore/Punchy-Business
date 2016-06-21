using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class BellPlaceholder : MonoBehaviour {

	[SerializeField]
	private Sprite collectedSprite = null;

	private Image thisImage;

	private bool wasCollected = false;


	// Use this for initialization
	void Start () {
		thisImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetCollected () {
		wasCollected = true;

		thisImage.sprite = collectedSprite;
	}

	public bool GetCollectedStatus () {
		return wasCollected;
	}
}
