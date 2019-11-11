using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableMove : MonoBehaviour {
	//Use this class rather than "moving object V" for collectables
	// Use this for initialization
	public Vector3 moveDir=Vector3.zero;
	public float speed =0;
	public float travelDistance=0;
	private Transform transf = null;

	IEnumerator Start () {
		transf = transform;
		for (;;) {
			moveDir *= -1;
			yield return StartCoroutine (Travel ());
		}
		
	}
	IEnumerator Travel()
	{
		float distanceTravelled = 0;
		while (distanceTravelled < travelDistance) {
			Vector3 distToTravel = moveDir * speed * Time.deltaTime;
			transf.position += distToTravel;
			distanceTravelled += distToTravel.magnitude;
			yield return null;
		}
	}

}
