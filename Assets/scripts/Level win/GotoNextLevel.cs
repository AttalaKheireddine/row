using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoNextLevel : MonoBehaviour
{
	void Victory()
	{
		transform.Find ("Victory").gameObject.SetActive (true);
	}
}
