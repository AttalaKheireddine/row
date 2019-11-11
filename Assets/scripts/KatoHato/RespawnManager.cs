using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {
	private Vector3 respawnPoint;
	private GameObject katoHato;
	public GameObject BirdPrefab;
	private int savedWindDirection;
	// Use this for initialization
	void Start () {
		SetRespawnPoint(transform.position);
		GameObject.Find ("Interface").SendMessage ("setBird", gameObject);
		}
	public void  Respawn()
	{
		katoHato=Instantiate (BirdPrefab, respawnPoint, Quaternion.identity);
		katoHato.GetComponent<WindBlow> ().direction = savedWindDirection;
	}
	public void SetRespawnPoint(Vector3 position)
	{
		respawnPoint = position;
		savedWindDirection = GetComponent<WindBlow> ().direction;
	}
}
