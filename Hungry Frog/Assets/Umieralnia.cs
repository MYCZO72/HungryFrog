using UnityEngine;
using System.Collections;

public class Umieralnia : MonoBehaviour {


	Animator anim;
	static bool xd = false;

	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if(xd == true)
		{
			
			anim.SetBool("scoreadd", true);
			xd = false;
		}

	}
	// Update is called once per frame
	public static void AddingAPoint () 
	{
		xd = true;
	}

	public void NoPoint () 
	{
		anim.SetBool("scoreadd", false);
	}

}
