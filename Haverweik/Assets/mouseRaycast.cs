using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseRaycast : MonoBehaviour
{
	[SerializeField] private Camera camera;
	Player player;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.CompareTag("Player")){
				player.TakeDamage();
			}
		}
    }
}
