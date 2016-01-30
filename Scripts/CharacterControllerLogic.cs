using UnityEngine;
using System.Collections;

public class CharacterControllerLogic : MonoBehaviour
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
	
	
	#region Properties (public)
	
	#endregion
	
	
	#region Unity event functions
	
	void Start()
	{
		animator = GetComponent<Animator>();
		
		if(animator.layerCount >= 2)
		{
			animator.SetLayerWeight(1, 1);
		}
	}
	

	void Update()
	{
		if (animator)
		{
			// Werte vom Controller-Pad/Keyboard
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");
			
			speed = new Vector2(h, v).sqrMagnitude;
			
			animator.SetFloat("Speed", speed);
			animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);
		}
	}
	
	
	void OnDrawGizmos()
	{
		
	}
	
	#endregion
	
	
	#region Methods
	
	#endregion
}