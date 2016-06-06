using UnityEngine;
using System.Collections;
//using System;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour 
{
	
	public float m_JumpForce;

	[Range(0.0f, 10.0f)]
	public float m_Speed;
	public bool m_IsGrounded;
	public bool Enabled { get; set; }

	//[Serialize]
	//private float m_JumpForce;
	private Rigidbody2D m_Rigidbody;
	private Transform m_Transform;
	private float m_Horizontal;
	private bool m_Jump;
	private Vector2 m_Movement;
	private Vector3 m_StartPosition;

	private void Start()
	{
		m_StartPosition = m_Transform.position;
	}
		
	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody2D> ();
		m_Transform = GetComponent<Transform> ();

	}

	private void Update()
	{
		if (!Enabled) return;

		m_Horizontal = Input.GetAxis ("Horizontal");
		m_Jump = Input.GetButtonDown ("Jump");

		if (m_Jump && m_IsGrounded)
			m_Rigidbody.AddForce (Vector2.up * m_JumpForce);

		m_Movement = Vector2.right * m_Horizontal * m_Speed * Time.deltaTime;
		m_Transform.Translate (m_Movement);
	}

	private void OnTriggerEnter2D(Collider2D hit){
		if (hit.CompareTag ("DeadZone"))
			m_Transform.position = m_StartPosition;
	}


	private void OnTriggerStay2D(Collider2D hit)
	{
		m_IsGrounded = true;
	}

	private void OnTriggerExit2D(Collider2D hit)
	{
		m_IsGrounded = false;
	}



}
