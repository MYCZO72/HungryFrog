using UnityEngine;
using System.Collections;

public class coincount : MonoBehaviour {

	Animator anim;
	static bool XDD = false;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(XDD == true)
		{

			anim.SetBool("CoinAddBool", true);
			XDD = false;
		}
	}

	public static void AddingACoin () 
	{
		XDD = true;
	}



	public void NoCoin () 
	{
		anim.SetBool("CoinAddBool", false);
	}
}
