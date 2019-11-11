using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObjectH : MonoBehaviour {
	public float speed;
	private Rigidbody2D rigid;
	private Vector2 vect;
	private float bound1,bound2,save;

	// Use this for initialization
	void Start () {
		rigid = GetComponentInChildren<Rigidbody2D> ();
		bound1 = transform.Find ("Bound1").transform.position.x;
		bound2 = transform.Find ("Bound2").transform.position.x;
		if (bound1 > bound2) { //ensure bound2>bound1
			save = bound1;
			bound1 = bound2;
			bound2 = save;
		}
			
		vect = new Vector2 (speed, 0);

	}	
	void FixedUpdate () 
	{
		float pos = transform.Find ("object").transform.position.x;
		
		if ( (pos<bound1) | (pos>bound2)) {
				vect = -vect;
			}
		rigid.velocity = vect; 
	}

}
