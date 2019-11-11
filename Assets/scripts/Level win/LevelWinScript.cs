using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinScript : MonoBehaviour {	
	private Vector3 playerPos,position,playerScale; //those r ta hold the initial valors of the corresondin' parameters
	private const float animationFrames=200;
	// Use this for initialization
	void OnTriggerEnter2D( Collider2D other)
	{
		if (other.CompareTag ("Player"))
			StartCoroutine( "Victory" ,other.gameObject);
	}
	IEnumerator Victory(GameObject player) //reference to the player gameObject
	{
		player.GetComponent<Rigidbody2D> ().simulated = false; //we don't need physics simulation
		player.GetComponent<Animator>().enabled=false;
		position = transform.position;
		playerPos = player.transform.position;
		playerScale = player.transform.localScale;
		for(int i=1;i<animationFrames;i++)
		{
			player.transform.position =( playerPos - (i/animationFrames) * (playerPos-position)); //get the player closer
			player.transform.localScale = playerScale * ((animationFrames - i) / animationFrames+0.1f); //get him smaller
			yield return new WaitForSeconds (0.01f);
		}
		GameObject.Find ("Interface").SendMessage ("Victory");
	}
}
