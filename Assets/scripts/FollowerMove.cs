using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMove : MonoBehaviour {
	float x1,x2,middle,playerX,direction,previousDirection;
	public GameObject Player; //reference to the player game Object
	public float motorForce,breakForce; //the force to  be used for the fllower movement & break
	// Use this for initialization
	void Start () {
		x1 = transform.Find ("Bound1").position.x;
		x2 = transform.Find ("Bound2").position.x;
		if (x2 < x1) 
		{ //ensure that x2>=x1
			middle = x1;
			x1 = x2;
			x2 = middle;
		}
		direction = 1;
		middle = (x1 + x2) / 2; //this is the point the follower returns to if  no bird in range
	}
	
	// Update is called once per frame
	void Update () {
		playerX = Player.transform.position.x;
		if ((playerX < x2) && (playerX > x1) && (transform.position.x<x2) && (transform.position.x>x1))
		{ //this condition means woth the player & the follower r still in the range
			direction = ((playerX > transform.position.x) ? 1 : -1);
		} 
		else {
			direction = ((middle > transform.position.x) ? 1 : -1); 
		}
		if (previousDirection==direction)
			GetComponent<Rigidbody2D>().AddForce(new Vector2(motorForce*direction,0));
		else
			GetComponent<Rigidbody2D>().AddForce(new Vector2(breakForce*direction,0));
		previousDirection=direction;
	}
}
