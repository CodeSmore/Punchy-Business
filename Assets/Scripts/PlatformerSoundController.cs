using UnityEngine;
using System.Collections;

public class PlatformerSoundController : MonoBehaviour {

	[SerializeField]
	private AudioClip cherryCollected = null, bellCollected = null, boomerangCollected = null, trampolineJump = null; 

	[SerializeField]
	private AudioClip othelloHits = null, othelloMisses = null, spearThrow = null;

	[SerializeField]
	private AudioClip othelloJumps = null, othelloLands = null, othelloTakesDamage = null;


	private AudioSource audioSource = null;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayCherryCollectedOneShot () {
		audioSource.PlayOneShot(cherryCollected);
	}

	public void PlayBellCollectedOneShot () {
		audioSource.PlayOneShot(bellCollected);
	}

	public void PlayBoomerangCollectedOneShot () {
		audioSource.PlayOneShot(boomerangCollected);
	}

	public void PlayTrampolineJumpOneShot () {
		audioSource.PlayOneShot(trampolineJump);
	}

	public void PlayOthelloHitsMob () {
		audioSource.PlayOneShot(othelloHits);
	}

	public void PlayOthelloMissesMob () {
		audioSource.PlayOneShot(othelloMisses);
	}

	public void PlaySpearThrow () {
		audioSource.PlayOneShot(spearThrow);
	}

	public void PlayOthelloJump () {
		audioSource.PlayOneShot(othelloJumps);
	}

	public void PlayOthelloLand () {
		audioSource.PlayOneShot(othelloLands);
	}

	public void PlayOthelloTakesDamage () {
		audioSource.PlayOneShot(othelloTakesDamage);
	}


}
