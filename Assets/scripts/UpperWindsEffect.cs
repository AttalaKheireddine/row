using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperWindsEffect : MonoBehaviour {

	public float gravityReduceFactor=1; 
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<KatoHatoMove>().makeWindsUp();
			other.GetComponent<Rigidbody2D> ().gravityScale *= 1/gravityReduceFactor;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<KatoHatoMove>().makeWindsNotUp();
			other.GetComponent<Rigidbody2D> ().gravityScale *=gravityReduceFactor;
		}
	}
}
