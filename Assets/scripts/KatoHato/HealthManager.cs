using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
	public int initHealth;
	public int maxHealth=5;
	private int healthVar;
	private bool invincible;
	private float invincibleTime=1;
	private SpriteRenderer SR;
	private GameObject deathParticleSystem;
	public Color damageColor;
	GameObject interface_;
	private AudioSource source;
	private GameObject sourceObj;
	public AudioClip deathClip;
	public AudioClip damageClip;

	// Use this for initialization
	void Start () {
		interface_ = GameObject.Find ("Interface");
		SR = GetComponent<SpriteRenderer> ();
		deathParticleSystem = transform.Find ("DeathParticleSystem").gameObject;
		sourceObj = GameObject.FindGameObjectWithTag ("sound");
		health = initHealth;
		SR.enabled = true;
		GetComponent<Rigidbody2D> ().simulated = true;
	}
	public void TakeDamage()
	{
		if (!invincible) {
			health -= 1;
			if (health == 0) {
				StartCoroutine(Die());
			}
			else 
			{
				if (sourceObj) 
				{
					source = sourceObj.GetComponent<AudioSource> ();
					source.PlayOneShot (damageClip, 1f);
				}
				StartCoroutine ("DamageEffectAndInvincibility");
			}
		}
	}
	public int health 
	{
		get 
		{
			return healthVar;
		}
		set 
		{
			if (value < 0)
			{
				healthVar = 0;
			} 
			else
			{
				healthVar = Mathf.Min (maxHealth, value);
				interface_.BroadcastMessage ("WhenHealthChanges");
			}
		}
	}

	IEnumerator Die()
	{
		GetComponent<KatoHatoMove>().Release();
		GetComponent<Rigidbody2D> ().simulated = false;  //so the bird won't move or do anything
		if (sourceObj) 
		{
			source = sourceObj.GetComponent<AudioSource> ();
			source.PlayOneShot (deathClip, 1f);
		}
		deathParticleSystem.GetComponent<ParticleSystem>().Play ();
		SR.enabled=false;
		yield return new WaitForSeconds (deathParticleSystem.GetComponent<ParticleSystem>().main.duration);//the release function needs a necessary time to detroy webs
		interface_.SendMessage("ShowDeathMenu");
	}
	public void IncreaseHealth(int increase)
	{
		health += increase;
	}
	IEnumerator DamageEffectAndInvincibility()
	{
		SR.color = damageColor;
		invincible = true;
		yield return new WaitForSeconds (invincibleTime);
		SR.color = Color.white;
		invincible = false;
	}
	public void TryAgain()
	{
		//function that makes the player respawn after dying
		interface_.SendMessage("HideDeathMenu");
		GetComponent<RespawnManager> ().Respawn();
		gameObject.SetActive(false);
		GameObject.Destroy (gameObject);
	}

}
