using UnityEngine;
using System.Collections;

public class zabson : MonoBehaviour {


	public CanvasGroup canvasgroup;
	Animator anim;
	public static bool game = false;
	public static bool restart = false;
	bool GoRight = false;
	bool GoCenter = false;
	bool GoLeft = false;
	float speed = 3f;

	public static bool Game()
	{
		return game;
	}
	public static void GameOn()
	{
		game = true;
	}
	public static void GameOff()
	{
		game = false;
		Center.ZeroCount();

	}
		

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(game)
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
				anim.SetBool("CatchB", true);
		if(game)
			if(Input.GetKeyDown(KeyCode.Space))
				anim.SetBool("CatchB", true);
		if(Input.GetKeyDown(KeyCode.L))
			game = true;

		if(GoCenter == true)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(0,0,0),Time.deltaTime*speed);
			if(transform.position == new Vector3(0,0,0))
			{
				GoCenter = false;
			}
		}

		if(GoRight == true)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(40,0,0),Time.deltaTime*speed);
			if(transform.position.x >= 15)
			{
				Destroy(gameObject);
			}
		}

		if(GoLeft == true)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(-40,0,0),Time.deltaTime*speed);
			if(transform.position.x <= -15)
			{
				Destroy(gameObject);
			}
		}

	}

	void CatchExit()
	{
		anim.SetBool("CatchB", false);
	}

	public void Right(bool isAlive)
	{
		if(isAlive)
		{
			GoCenter = true;
		}
		else
		{
			GoRight = true;
		}
	}

	public void Left(bool isAlive)
	{
		if(isAlive)
		{
			GoCenter = true;
		}
		else
		{
			GoLeft = true;
		}
	}
}
