using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	[SerializeField]
	private AudioClip playerBlockedPunch = null, playerHitByJab = null, playerHitByHook = null, playerHitByUppercut = null, knockOutSound = null;
	[SerializeField]
	private AudioClip tigerHitByJab = null, tigerHitByHook = null, tigerHitByUppercut;

	private AudioSource audioSource = null;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayBlockOneShot () {
		audioSource.PlayOneShot(playerBlockedPunch);
	}

	public void PlayJabOneShot () {
		audioSource.PlayOneShot(playerHitByJab);
	}

	public void PlayHookOneShot () {
		audioSource.PlayOneShot(playerHitByHook);
	}

	public void PlayUppercutOneShot () {
		audioSource.PlayOneShot(playerHitByUppercut);
	}

	public void PlayKOSoundOneShot () {
		audioSource.PlayOneShot(knockOutSound);
	}

	public void PlayTigerHitByJabOneShot () {
		audioSource.PlayOneShot(tigerHitByJab);
	}

	public void PlayTigerHitByHookOneShot () {
		audioSource.PlayOneShot(tigerHitByHook);
	}

	public void PlayTigerHitByUppercutOneShot () {
		audioSource.PlayOneShot(tigerHitByUppercut);
	}
}
