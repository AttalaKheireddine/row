using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuManager : MonoBehaviour 
{
	private GameObject bird;   //reference to player
	void setBird(GameObject bird)
	{
		this.bird = bird;
	}
	void ShowDeathMenu()
	{
		transform.Find ("DeathMenu").gameObject.SetActive (true);
	}
	void HideDeathMenu()
	{
		transform.Find ("DeathMenu").gameObject.SetActive (false);
	}
	public void MakeTheBirdRespawn()
	{
		bird.SendMessage ("TryAgain");
	}
}
