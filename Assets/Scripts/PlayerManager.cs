using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private Player[] m_Players;
	private int m_CurrentPlayer = 0;
	private CameraFollow m_CameraFollow;

	private void Start()
	{
		m_CameraFollow = FindObjectOfType<CameraFollow> ();
		m_Players = FindObjectsOfType<Player> ();
		m_Players [m_CurrentPlayer].Enabled = true;
		m_CameraFollow.ChangeTarget (m_Players [m_CurrentPlayer].transform);

	}
		
	private void Update(){
		if (Input.GetButtonDown ("Fire2"))
		{
			ChangePlayer ();
			m_CameraFollow.ChangeTarget (m_Players [m_CurrentPlayer].transform);
		}
	}

	private void ChangePlayer()
	{
		m_Players[m_CurrentPlayer].Enabled = false;
		m_CurrentPlayer = (++m_CurrentPlayer) % m_Players.Length;
		m_Players [m_CurrentPlayer].Enabled = true;

	}


	private void Save()
	{
		for (int i = 0; i < m_Players.Length; i++) {
			if (PlayerPrefs.HasKey ("Player" + i))
				m_Players [i].transform.position = JsonUtility.FromJson<Vector3> (PlayerPrefs.GetString ("Player" + i));

			m_CurrentPlayer = PlayerPrefs.GetInt ("CurrentPlayer");
			m_Players [0].Enabled = false;
			m_Players [m_CurrentPlayer].Enabled = true;
			
		}

	}




}
