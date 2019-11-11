using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontCrouchPlatform : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Collider2D> ().IsTouching (player.GetComponent<Collider2D> ())) {
			Debug.Log ("AAAA NOOOON");
			if (player.GetComponent<KatoHatoMove> ().crouch) {
				player.GetComponent<HealthManager> ().TakeDamage ();
			}
		}
	}
}
