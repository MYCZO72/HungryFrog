using UnityEngine;
using System.Collections;

public class RandomBox : MonoBehaviour 
{

	bool GoCenter = false;
	float speed = 3f;
	bool GoLeft = false;
	bool GoUp = false;

	void Update () 
	{
		if(GoCenter == true)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(0,0,0),Time.deltaTime*speed);
			if(transform.position == new Vector3(0,0,0))
			{
				GoCenter = false;
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

		if(GoUp == true)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(0,60,0),Time.deltaTime*speed);
			if(transform.position.y >= 20)
			{
				Destroy(gameObject);
			}
		}
	}

	public void Right()
	{
		GoCenter = true;
	}

	public void Left()
	{

		GoLeft = true;

	}

	public void Up()
	{

		GoUp = true;

	}
}
