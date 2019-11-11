using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : MonoBehaviour {
	private int currentHealth,counter;
	void WhenHealthChanges()
	{
		currentHealth=GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthManager> ().health;
		counter = 1;
		foreach (Transform child in gameObject.transform)
		{
			if (counter>currentHealth)
			{
				child.gameObject.SetActive(false);
			}
			else
			{
				child.gameObject.SetActive(true);
			}
			counter++;
		}
	}

}
