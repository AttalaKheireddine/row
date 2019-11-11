using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStartingForce : MonoBehaviour {
	public Vector2 force;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().AddForce (force);
	}
}
