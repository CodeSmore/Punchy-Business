using UnityEngine;
using System.Collections;

public class BellCollectables : MonoBehaviour {

	[SerializeField]
	private BellPlaceholder[] bells = null;

	public bool HaveAllBellsBeenCollected () {
		foreach (BellPlaceholder bell in bells) {
			if (!bell.GetCollectedStatus()) {
				return false;
			}
		}

		return true;
	}
}
