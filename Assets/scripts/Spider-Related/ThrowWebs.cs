using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWebs : MonoBehaviour {
	public float waitTime ;
	public Transform webBlast;
	public Transform web;
	public float intensity;
	// Use this for initialization
	void Start () {
		StartCoroutine ("throwWebs");
	}
	
	IEnumerator throwWebs()
	{
		for (;;) {
			web=Instantiate (webBlast, transform.position,transform.localRotation);
			web.GetComponent<Rigidbody2D>().AddForce(transform.rotation*Vector2.down*intensity);
			yield return new WaitForSeconds (waitTime);
		}
	}
}
