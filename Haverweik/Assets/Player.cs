using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
	private Color redColor = Color.red;
	private Color whiteColor = Color.white;
	private Renderer renderer;

	private int health = 100;
	private int dmg = 10;
    // Start is called before the first frame update
    void Start()
    {
		renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if (health == 0)
		{
			StartCoroutine(Dying());
		}
    }
	public int GetHealth()
	{
		return health;
	}
	public void TakeDamage()
	{
		health -= dmg;
	}
	IEnumerator Dying()
	{
		yield return null;
		renderer.material.color = redColor;
		yield return new WaitForSeconds(0.08f);
		renderer.material.color = whiteColor;
		yield return new WaitForSeconds(0.08f);
		renderer.material.color = redColor;
		yield return new WaitForSeconds(0.08f);
		Destroy(this.gameObject);
	}

}
