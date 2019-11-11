using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBeatsFire: MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Fire")) {
			GameObject.Destroy (other.gameObject);
		}
		GameObject.Destroy (gameObject);
	}
}
