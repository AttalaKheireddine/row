using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MenuManager : MonoBehaviour {
	private bool startButton=false;
	private GameObject object1;
	public Canvas canvas;
	public string levelChoiceSceneName,creditsSceneName;

	// Use this for initialization
	// Update is called once per frame
	void Update () {
		startButton = CrossPlatformInputManager.GetButtonDown ("Submit");
		if (startButton) {
			MenuAnimation ();
		}
	}
	void MenuAnimation()
	{
		canvas.SendMessage ("StartMenuAnimation", SendMessageOptions.DontRequireReceiver);
	}
	public void Quit()
	{
		Application.Quit ();
	}
	public void Play()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (levelChoiceSceneName);
	}
	public void Credits()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (creditsSceneName);
	}
}
