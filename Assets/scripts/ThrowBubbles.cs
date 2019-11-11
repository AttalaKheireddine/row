using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBubbles : MonoBehaviour {
	public Transform Bubble;
	public float waitTime;
	public float intensity;
	private Transform bubble;
	private float scaleY,Vdir;
	// Use this for initialization
	void Start () {
		StartCoroutine ("BlowBubbles");
	}
	IEnumerator BlowBubbles()
	{
		for (;;) {
			bubble = Instantiate (Bubble,transform);
			bubble.localPosition = new Vector3 (0, 3f, 0);
			scaleY = transform.lossyScale.y;
			Vdir = Mathf.Abs (scaleY) / scaleY; //-1 if scale is positive else -1
			bubble.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector2.up* (intensity*Vdir)); 
			//Vdir's role : if scale is negative ; force must be the opposite direction
			yield return new WaitForSeconds (waitTime);
		}
	}

}
