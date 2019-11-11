using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShootFire : MonoBehaviour {
	public Vector2 startForce;
	public float waiTime;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().AddForce (startForce);
		StartCoroutine ("FadeAfterSomeTime");
	}
	
	IEnumerator FadeAfterSomeTime()
	{
		yield return new WaitForSeconds (waiTime);
		Destroy (gameObject);
	}
}
