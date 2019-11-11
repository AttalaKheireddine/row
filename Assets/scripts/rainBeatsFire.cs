using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainBeatsFire : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		if ( other.CompareTag("Fire"))
			{
				GameObject.Destroy(other.gameObject);
			}
	}
}
