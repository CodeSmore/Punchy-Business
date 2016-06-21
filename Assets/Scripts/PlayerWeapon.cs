using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	[SerializeField]
	private int attackValue = 0;
	
	public int GetAttackValue() {
		return attackValue;
	}
}
