using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavMesh : MonoBehaviour
{
	Animator m_Animator;
	NavMeshAgent m_Agent;
	Ray m_RayScreen;
	RaycastHit m_RayHit;
	Vector3 m_TargetPoint;
	float characterSpeed;

	void Start ()
	{
		characterSpeed = 0;
		m_Animator = GetComponent<Animator> ();
		m_Agent = GetComponent<NavMeshAgent> ();
		m_TargetPoint = transform.position;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			m_RayScreen = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (m_RayScreen, out m_RayHit, 300)) {
				m_TargetPoint = m_RayHit.point;
			}
		}
		m_Agent.SetDestination (m_TargetPoint);


	}
}