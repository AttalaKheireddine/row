using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchronizeGaugeMaskAnimation : MonoBehaviour {
	Animator anim;
	public AnimationClip clip; //supposed to hold the same animation to play
	float animTime;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
	}
	void SetGaugeSpeed(float time)//animation must exactly fit the given time
	{
		anim.speed = clip.length / time;
		animTime = time;
	}
	IEnumerator GaugeAnimation()
	{
		anim.Play ("maskAnimation");
		yield return new WaitForSeconds (animTime);
		anim.Play ("GaugeIsEmpty");
	}
}
