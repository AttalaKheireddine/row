using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindBlow : MonoBehaviour {
	private KatoHatoMove move ;
	public AudioSource windSound;
	public AudioSource ambientSound;
	private int windDirection = 1;
	GameObject interface_;
	// Use this for initialization
	void Awake()
	{
		interface_ = GameObject.Find ("Interface");
	}
	void Start () {
		windSound = transform.Find ("WindSoundHolder").GetComponent<AudioSource> ();
		ambientSound = transform.Find ("AmbientSoundHolder").GetComponent<AudioSource> ();
		move = GetComponent<KatoHatoMove> ();
		interface_.BroadcastMessage ("SetGaugeSpeed", ambientSound.clip.length);
		StartCoroutine ("WindBlows");
	}
	
	// Update is called once per frame
	IEnumerator WindBlows()
	{
		for (;;)
		{
			ambientSound.Play ();
			interface_.BroadcastMessage ("GaugeAnimation");
			yield return new WaitForSeconds (ambientSound.clip.length);
			windSound.Play ();
			move.Release ();
			if (!move.crouch) 
			{
				move.StartCoroutine ("Blow",windDirection);
			}
			interface_.BroadcastMessage ("WhenWindBlows",SendMessageOptions.DontRequireReceiver);
			GameObject dzard = GameObject.Find ("DZard Ground");
			dzard.SendMessage ("OnWindBlow");
			yield return new WaitForSeconds (windSound.clip.length);
		}
	}
	public int direction {
		get {
			return windDirection;
		}
		set {
			windDirection = value;
			GetComponent<KatoHatoMove> ().WhenWindIsSet (value);
			interface_.BroadcastMessage ("WhenWindIsSet",value,SendMessageOptions.DontRequireReceiver);
		}
	}
	public void FlipWind ()
	{
		direction *= -1;
	}
}
