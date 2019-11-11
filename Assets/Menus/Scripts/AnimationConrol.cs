using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConrol : MonoBehaviour {
	private GameObject obj1;
	public GameObject arrowRight, arrowLeft;
	void StartMenuAnimation() 
	{//start the menuShowing Animation
		obj1=transform.Find("trees").gameObject;
		obj1.SetActive (false);
		GetComponent<Animator> ().SetBool ("anim", true);

	}
	void showMenu()
	{
		GetComponent<Animator> ().SetBool ("anim", false);
		obj1 = transform.Find ("MenuButtons").gameObject;
		obj1.SetActive (true);
		GetComponent<Animator> ().SetBool ("animButtons", true);
	}
	void endAnimation()
	{
		GetComponent<Animator> ().SetBool ("animButtons", false);
	}
		
}
