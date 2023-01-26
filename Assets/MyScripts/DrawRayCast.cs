using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrawRayCast : MonoBehaviour
{
	RaycastHit hit;
	void Update()
	{
		if (Physics.Raycast(transform.position, transform.forward, out hit)) 
		{ 
			if (hit.collider.gameObject.tag == "Player")
			{ 
				Debug.DrawRay(transform.position, transform.forward, Color.green); print("Hit");
			} 
		}
	}
}
