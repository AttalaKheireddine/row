using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour {

	// Use this for initialization
	public void Play(int level)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Level " + level);
	}
}
