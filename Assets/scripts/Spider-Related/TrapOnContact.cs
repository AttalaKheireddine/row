using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapOnContact : MonoBehaviour {
	public  Transform WebPrefab;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (other.GetComponent<KatoHatoMove> ().web == null)
				Instantiate (WebPrefab, other.transform);	
		}
		GameObject.Destroy (gameObject);
	}
}
