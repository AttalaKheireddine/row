using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWindDirectionOnCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag ("Player")) {
			other.collider.GetComponent<WindBlow> ().FlipWind ();
			//flip the sprite
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
