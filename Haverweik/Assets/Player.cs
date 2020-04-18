using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
	private Color redColor = Color.red;
	private Color whiteColor = Color.white;
	private int health = 100;
	private int dmg = 10;
    // Start is called before the first frame update
    void Start()
    {
		var renderer = gameObject.GetComponent<Renderer>();
		var mouseRay = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mouseRaycast>();
		mouseRay.takeDMG += TakeDamage;
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
	private void TakeDamage()
	{
		health -= dmg;
		StartCoroutine(FlashColor());
	}
	IEnumerator Dying()
	{
		yield return null;
		GetComponent<Renderer>().material.color = redColor;
		yield return new WaitForSeconds(0.08f);
		GetComponent<Renderer>().material.color = whiteColor;
		yield return new WaitForSeconds(0.08f);
		GetComponent<Renderer>().material.color = redColor;
		yield return new WaitForSeconds(0.08f);
		Destroy(this.gameObject);
	}
	IEnumerator FlashColor()
	{
		GetComponent<Renderer>().material.color = redColor;
		yield return new WaitForSecondsRealtime(0.25f);
		GetComponent<Renderer>().material.color = whiteColor;
	}

}
