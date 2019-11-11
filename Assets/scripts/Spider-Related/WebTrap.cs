using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTrap : MonoBehaviour {
	private GameObject katoHato;

	// Use this for initialization
	void Start () {
		katoHato = GameObject.FindGameObjectWithTag ("Player");
		transform.localPosition = Vector3.zero;
		katoHato.GetComponent<KatoHatoMove> ().WebTrap (gameObject);
	}
}
