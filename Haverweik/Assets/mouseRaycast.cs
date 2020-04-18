using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mouseRaycast : MonoBehaviour
{
	[SerializeField] private Camera camera;
	public event Action takeDMG;
		void FixedUpdate()
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				RaycastHit hit;
				Ray ray = camera.ScreenPointToRay(Input.mousePosition);
				Debug.DrawLine(ray.origin, ray.direction, Color.magenta);
				if (Physics.Raycast(ray, out hit))
				{
				if (hit.collider.CompareTag("Player"))
					takeDMG();
				}
			}
		}
}
