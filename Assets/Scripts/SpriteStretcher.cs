using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]

public class SpriteStretcher : MonoBehaviour {
	SpriteRenderer sprite;

	void Awake() {
		sprite = GetComponent<SpriteRenderer>();

		Vector2 spriteSize = new Vector2 (sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);

		GameObject childPrefab = new GameObject();
		SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
		childPrefab.transform.position = transform.position;
		childSprite.sprite = sprite.sprite;

		GameObject child;


		for (float i = -sprite.bounds.extents.y + 1, l = (int)Mathf.Round(sprite.bounds.size.y); i < l; i++) {
			child = Instantiate(childPrefab) as GameObject;
			child.transform.position = transform.position - (new Vector3(0, spriteSize.y, 0) * i);

			child.transform.parent = transform;
		}

		childPrefab.transform.parent = transform;
		Destroy(childPrefab.gameObject);

		sprite.enabled = false;
	}
	
}
