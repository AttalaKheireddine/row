using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingFires : MonoBehaviour {
	public int numberOfEmpties=3; //number of fires to be unactivated
	GameObject[] children;
	int firstInactive,lastInactive;
	public float waiTime = 1f;
	// Use this for initialization
	void Start () {
		children = new GameObject[transform.childCount];
		int i = 0;
		foreach (Transform t in transform) {
			children [i] = t.gameObject;
			i++;
		}
		for (i = 0; i < numberOfEmpties; i++) {
			children [i].SetActive (false);
		}
		firstInactive = 0;
		lastInactive = numberOfEmpties - 1;
		StartCoroutine ("MoveFires");
	}
	IEnumerator MoveFires()
	{
		for (;;) {
			children [firstInactive].SetActive (true);
			firstInactive=(firstInactive+1)%children.Length;
			lastInactive=(lastInactive+1)%children.Length;
			children [lastInactive].SetActive (false);
			yield return new WaitForSeconds (waiTime);
		}
	}

}
