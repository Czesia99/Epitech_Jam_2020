using UnityEngine;
using UnityEngine.Events;

public class PlayerController: MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;
	[SerializeField] private float m_DashForce = 500f;
	[Range(0, 1)] [SerializeField] private float m_dashSpeed = 1f;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
	[SerializeField] private bool m_AirControl = false;
	[SerializeField] private LayerMask m_WhatIsGround;
	[SerializeField] private Transform m_GroundCheck;
	[SerializeField] private Transform m_CeilingCheck;

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;
	private int nb_jumps = 2;
	private int nb_dash = 1;
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;
	private Vector3 m_Velocity = Vector3.zero;
	// public float startDashTime;


	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	// public BoolEvent OnCrouchEvent; CROUCH
	// private bool m_wasCrouching = false; CROUCH

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Move(float move, bool jump, bool dash)
	{
		if (dash && nb_dash > 0)
		{
			Debug.Log("dash !");
			if (m_FacingRight)
			{
				Debug.Log("positiv move");
				m_Rigidbody2D.AddForce(new Vector2(m_DashForce*4, 0f));
			}
			else if (!m_FacingRight) {
				Debug.Log("neg move");
				m_Rigidbody2D.AddForce(new Vector2(-m_DashForce*4, 0f));
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		}

		if (jump && nb_jumps > 0)
		{
			m_Grounded = false;
			nb_jumps -= 1;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}

		if (m_Grounded)
			nb_jumps = 2;
			nb_dash = 1;

	}


	private void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
