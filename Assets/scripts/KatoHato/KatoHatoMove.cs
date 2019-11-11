using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatoHatoMove : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
	[SerializeField] private float blowSpeed=20;
	[SerializeField] private float blowTime = 0.5f;
	private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .4f; // Radius of the overlap circle to determine if grounded
	[SerializeField] private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = false;  // For determining which way the player is currently facing.
	private int blow ; //0 means not blown ,1 for "blown right" , -1 for "blown left"
	public bool areWindsUp=false; // if blow != 0 && areWidsUp==true then upper wind
	public bool crouch;
	private Animator anim;
	public GameObject web;
	private int moveDirection = -1;

	private Rigidbody2D platform;//rigidbody of carrying platform (if any)
	private Vector2 platformSpeed=Vector2.zero; //speed of eventually moving platform carrying the player
	private void Start()
	{
		m_GroundCheck = transform.Find("GroundCheck");
		blow = 0;
		web = null;
		crouch = false;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		anim.SetBool ("Blown", blow!=0	);
	}

	private void FixedUpdate()
	{
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders [i].gameObject != gameObject) {
				m_Grounded = true;
				platform = colliders [i].gameObject.GetComponent<Rigidbody2D> ();
				if ((platform!=null) & (! colliders[i].isTrigger))
				{
					platformSpeed = platform.velocity;
				}
			}
		}
		anim.SetBool ("Grounded", this.m_Grounded);
		if (!m_Grounded) {
			platformSpeed = Vector2.zero;
		}
	}


	public void Move(float move, bool crouch_, bool jump)
	{
		anim.SetBool ("Blown", blow!=0	);
		if (web != null) {
			web.transform.position = transform.position;
			return;
		}
		if (blow!=0) {
			if (areWindsUp) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, blowSpeed);
			}
			else
			{
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (blowSpeed*blow, 0);//+platformSpeed ??;
			}
			return;
		}
		if (move*moveDirection<0)   //move is in the opposite of moveDirection
		{ 
			move = 0;
		}
		this.crouch = crouch_ && m_Grounded;
		anim.SetBool ("Crouch", this.crouch);

		// Set whether or not the character is crouching in the animator
		if ((m_Grounded || m_AirControl)) {
			// Reduce the speed if crouching by the crouchSpeed multiplier
			move = (this.crouch ? move * m_CrouchSpeed : move);
			anim.SetBool ("IsWalking", ((m_Grounded) && (move != 0) && (!crouch)));

			// The Speed animator parameter is set to the absolute value of the horizontal input
			m_Rigidbody2D.velocity = new Vector2 (move * m_MaxSpeed + platformSpeed.x, m_Rigidbody2D.velocity.y);
		}
	
		// If the player should jump...
		if (m_Grounded && jump) {
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce (new Vector2 (0f, m_JumpForce));
		}
	}

	public void setPlatformSpeed(Vector2 speed)
	{
		platformSpeed = speed;
	}
	public void WhenWindIsSet (int direction)
	{//actions to do when wind direction changes
		if (moveDirection * direction > 0) {
			moveDirection *= -1;
		}
		if (transform.localScale.x * direction < 0) {
			Flip ();
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	private IEnumerator Blow(int direction)
	{
		blow = direction;
		yield return new WaitForSeconds (blowTime);
		blow = 0;
	}
	public void WebTrap(GameObject web)
	{
		crouch = false;
		this.web = web;
		m_Rigidbody2D.velocity = new Vector2 (0, m_Rigidbody2D.velocity.y);
	}

	public void Release()
	{
		GameObject.Destroy(web);
		web = null;
	}
	public void makeWindsUp()
	{
		areWindsUp = true;
	}
	public void makeWindsNotUp()
	{
		areWindsUp = false;
	}
}
