using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
	
	#region variables (private)
	
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private float directionDampTime = .25f;
	
	private float speed = 0.0f;
	private float h = 0.0f;
	private float v = 0.0f;
	
	#endregion

	#region
	
	[SerializeField]
	private float distanceAway;
	[SerializeField]
	private float distanceUp;
	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform follow;
	private Vector3 targetPosition;
	
	#endregion
	
	
	#region Properties (public)
	
	#endregion
	
	
	#region Unity event functions
	
	
	void Start()
	{
		follow = GameObject.FindWithTag("Player").transform;
	}
	
	
	void Update()
	{
		//if (Input.GetAxis("HorizontalRight"))
		{
			
		}
	}
	
	
	void OnDrawGizmos()
	{
		
	}
	
	
	void LateUpdate()
	{
		//Berechnung der korrekten Kamera-Posi
		targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		
		//Debug-Test Linien
		Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red); //ROT
		Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue); //BLAU
		Debug.DrawLine(follow.position, targetPosition, Color.magenta); //MAGENTA
		
		//weiche Transition zwischen aktueller Kamera-Posi und Kamera-Idle-Posi
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		
		//Kamera-Blickrichtung ist immer auf 'follow' gerichtet
		transform.LookAt(follow);
	}
	
	#endregion
}