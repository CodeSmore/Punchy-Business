using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SwipeScript : MonoBehaviour {

	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;

	private bool isSwipe = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 0.5f;

	private EventSystem eventSystem;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		eventSystem = GameObject.FindObjectOfType<EventSystem>();
		playerController = GameObject.FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && eventSystem.currentSelectedGameObject == null) {
			Debug.Log("Touching");
			foreach (Touch touch in Input.touches) {
				switch(touch.phase) {
					case TouchPhase.Began :
						// this is a new touch
						isSwipe = true;
						fingerStartTime = Time.time;
						fingerStartPos = touch.position;
						break;
					case TouchPhase.Canceled : 
						// the touch is being canceled
						isSwipe = false;

						break;
					case TouchPhase.Ended :
						float gestureTime = Time.time - fingerStartTime;
						float gestureDist = (touch.position - fingerStartPos).magnitude;

						if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
							Vector2 direction = touch.position - fingerStartPos;
							Vector2 swipeType = Vector2.zero;

							if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
								// swipe is horizontal
								swipeType = Vector2.right * Mathf.Sign(direction.x);
							} else {
								// swipe is vertical
								swipeType = Vector2.up * Mathf.Sign(direction.y);
							}

							if (swipeType.x != 0.0f) {
								if (swipeType.x > 0.0f) {
									// MOVE RIGHT
									playerController.RightHook();
									Debug.Log("Swipe Right");
								} else {
									// MOVE LEFT
									playerController.LeftHook();
									Debug.Log("Swipe Left");
								}
							}

							if (swipeType.y != 0.0f) {
								if (swipeType.y > 0.0f) {
									// MOVE UP
									playerController.LeftUppercut();
									Debug.Log("Swipe Up");
								} else {
									// MOVE DOWN
									Debug.Log("Swipe Down");
								}
							} 
						} else {
							playerController.LeftJab();
						}

						break;
				}
			}
		}
	}
}
