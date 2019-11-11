using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DzardGround : MonoBehaviour {
	GameObject[] children;
	public GameObject oneShootFire;
	int parity=0; // decides wether to throw fire from pair/impair chidren
	// Use this for initialization
	void Start () {
		children = new GameObject[transform.childCount];
		int i = 0;
		foreach (Transform t in transform) {
			children [i] = t.gameObject;
			i++;
		}
	}
	void OnWindBlow()
	{
		for (int i = 0; i < children.Length; i++) {
			if (i % 2 == parity) {
				Instantiate (oneShootFire, children [i].transform.position, Quaternion.identity);
			}
		}
		parity = (parity + 1) % 2;
	}
}
