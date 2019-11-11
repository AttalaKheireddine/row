using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisOscillationEffect : MonoBehaviour {
	float originalY,counter,pi=3.14f;
	public float oscillationRange;
	// Use this for initialization
	void Start () {
		originalY = transform.position.y;
		StartCoroutine ("Oscillate");
	}
	
	// Update is called once per frame
	IEnumerator Oscillate()
	{
		counter = 0;
		for (;;) {
			counter += 0.1f;
			transform.position= new Vector3( transform.position.x, originalY + Mathf.Sin (counter)*oscillationRange,transform.position.z);
			if (counter == pi * 2) {
				counter = 0;
			}
			yield return new WaitForSeconds (0.01f);
		}
	}
}
