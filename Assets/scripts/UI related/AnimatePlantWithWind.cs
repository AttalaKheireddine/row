using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlantWithWind : MonoBehaviour {
	private Animator anim;
	public AnimationClip clip; //supposed to hold plantAnim
	float animTime;
	void Awake () {
		anim = GetComponent<Animator> ();
		animTime = clip.length;
	}
	
	// Update is called once per frame
	IEnumerator WhenWindBlows()
	{
		anim.Play ("PlantAnim");			
		yield return new WaitForSeconds(animTime);
		anim.Play ("plantStill");
	}
	public void WhenWindIsSet (int direction)
	{//actions to do when wind direction changes
		if (transform.localScale.x * direction < 0) {
			Flip ();
		}
	}
	private void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
