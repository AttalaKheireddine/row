using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Pause : MonoBehaviour {
	private bool pauseInput=false;
	private bool paused=false;
	private AudioSource source;
	private GameObject sourceObj,playerObj;
	public AudioClip clip;
	// Use this for initialization
	void Update(){
		pauseInput=CrossPlatformInputManager.GetButtonDown ("Cancel");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		if (pauseInput) {
			PauseUnpause ();
		}
	}
	public void PauseUnpause()
	{//pauses the game or unpauses if already paused
		paused = !paused;
		Time.timeScale = paused ? 0f : 1f;
		if (paused)
		{//display the pause menu
			transform.Find ("PauseMenu").gameObject.SetActive (true);
			//play the pause sound
			sourceObj = GameObject.FindGameObjectWithTag ("sound");
			if (sourceObj) 
			{
				source = sourceObj.GetComponent<AudioSource> ();
				source.PlayOneShot (clip, 1f);
			}
		}
		else
		{
			transform.Find ("PauseMenu").gameObject.SetActive (false);
		}			
	}
	public void Quit()
	{
		Time.timeScale = 1f;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("startWindow");
	}
}
