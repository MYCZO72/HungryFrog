using UnityEngine;
using System.Collections;

public class obstacle : MonoBehaviour {

	public bool isfly;
	public bool isCoin;
	bool isdead = false;
	Vector3 AxisR = new Vector3(0,0,1);
	public float RotationSpeed = 5.0f;
	public Transform RotateAroundObject;
	public int state = 0;
	public float fallspeed = 1.0f;
	bool rotat = false;
	public GameObject[] Umieralnia; 
	GameObject XD;
	public Vector3 axis = Vector3.up;
	public Vector3 desiredPosition;
	public float radius = 20.5f;
	public float radiusSpeed = 22.5f;


/* UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE*/
	Quaternion rotation;
	void Awake()
	{
		rotation = transform.rotation;
		state = 1;
	}
	void LateUpdate()
	{
		transform.rotation = rotation;
	}
/* UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE UNROTATE*/

	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.Q))
			state = 1;
		if(Input.GetKey(KeyCode.W))
			state = 2;
		if(Input.GetKey(KeyCode.E))
			state = 3;

		if(state == 1 && isdead == false)
			Fall();
		if(state == 2 && isdead == false)
			Fly();
		if(isdead == true)
			Die();
			
	}
	
	void Fall()
	{
		transform.position -= new Vector3(0,fallspeed,0);
	}
	void Fly()
	{
		//transform.RotateAround( RotateAroundObject.transform.position , AxisR , RotationSpeed*Time.deltaTime );
		transform.RotateAround (RotateAroundObject.position, AxisR, RotationSpeed * Time.deltaTime);
		desiredPosition = (transform.position - RotateAroundObject.position).normalized * radius + RotateAroundObject.position;
		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
	
	}

	void Die()
	{
		transform.position -= new Vector3(0,fallspeed,0);
	}

	 void WeAreDead()
	{
		isdead = true;

	}



	void OnTriggerEnter2D (Collider2D col)
	{

		if(Center.Count() == 1 && isfly == true && col.gameObject.tag == "Zaba" && isdead == false && isCoin != true)
		{
			Destroy(gameObject);	
			Umieralnia = GameObject.FindGameObjectsWithTag("Obstacle");
			foreach (GameObject respawn in Umieralnia) 
			{
				respawn.SendMessage("WeAreDead"); 
			}
			Center.ComboA();
			//if(isCoin)
			//	Center.AddCoin();
			//if(isCoin == false)
		//	{
				Center.AddScore();
				Center.UnCount();
		//	}
		}
		else
		{
			if(isfly && isdead == false)	
			{
				if(col.gameObject.tag == "Zaba")
				{
					Destroy(gameObject);	
					Center.ComboA();
					if(isCoin)
						Center.AddCoin();
					if(isCoin == false)
					{
						Center.AddScore();
						Center.UnCount();
					}
				}
			}
		}
		if(isfly)	
			if(col.gameObject.name == "Combo")
				Center.ComboZ();

		if(isfly == false && isdead == false)	
		{
			if(col.gameObject.tag == "Zaba")
			{
				Destroy(gameObject);
				Umieralnia = GameObject.FindGameObjectsWithTag("Obstacle");
				foreach (GameObject respawn in Umieralnia) 
				{
					respawn.SendMessage("WeAreDead"); 
				}
				zabson.GameOff();
				XD = GameObject.FindGameObjectWithTag("Restart");
				XD.SendMessage("FadeMeIn");
			}
		}

		if(col.gameObject.name == "Umieralnia")
			Destroy(gameObject);	

		if(rotat == false)
		{
			if(col.gameObject.name == "Rotator")
			{
				rotat = true;
				state = 2;
			}
		}
			
		
	}

}
	
