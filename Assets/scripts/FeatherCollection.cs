using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherCollection : MonoBehaviour {
	private AudioSource source;
	private GameObject sourceObj;
	public AudioClip clip;
	// Use this for initialization
	void OnTriggerEnter2D( Collider2D other )
	{
		if (other.CompareTag("Player"))
		{
			sourceObj = GameObject.FindGameObjectWithTag ("sound");
			if (sourceObj) 
			{
				source = sourceObj.GetComponent<AudioSource> ();
				source.PlayOneShot (clip, 1f);
			}
			other.GetComponent<HealthManager>().IncreaseHealth(1);
			GameObject.Destroy (gameObject);
		}
	}
}
