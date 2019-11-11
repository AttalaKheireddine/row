using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoLevelSelectAfterAnim: MonoBehaviour {
	public float waitTime;
	private AudioSource source;
	private GameObject sourceObj,playerObj;
	public AudioClip victorySoundClip;
	public IEnumerator EndSuccessAnimAndProceed()
	{
		sourceObj = GameObject.FindGameObjectWithTag ("sound");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		playerObj.GetComponent<WindBlow> ().StopAllCoroutines (); //so we stop the wind sound
		if (sourceObj) 
		{
			source = sourceObj.GetComponent<AudioSource> ();
			source.PlayOneShot (victorySoundClip, 2f);
		}
		GetComponent<Animator> ().SetBool ("anim", false);
		yield return new WaitForSeconds (waitTime);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("LevelSelectionMenu");
	}
}
