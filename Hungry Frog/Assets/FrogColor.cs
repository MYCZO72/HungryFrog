using UnityEngine;
using System.Collections;

public class FrogColor : MonoBehaviour 
{
	float smooth = 0.1f;
	private Color DayColor = new Color(1F,1f,1f,1f);
	private Color SunsetColor = new Color(0.964f,0.753f,0.51f,1f);
	private Color NightColor = new Color(0.416f,0.49f,0.62f,1f);
	private Color RainColor = new Color(0.663f,0.706f,0.882f,1f);
	private Color MorningColor = new Color(0.894f,0.823f,0.886f,1f);
	SpriteRenderer ten;
	public int Abool = 4;


	public void SetA(int xDDnowy)
	{
		Abool = xDDnowy;
	//	print("" + Abool);
	//	print("" + Abool);print("" + Abool);print("" + Abool);print("" + Abool);print("" + Abool);print("" + Abool);print("" + Abool);print("" + Abool);print("" + Abool);print("" + Abool);print("" + Abool);

	}


	void Awake ()
	{

		ten = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		//ColorChange(Abool);
		if(Abool == 0)
			ten.color = Color.Lerp(ten.color, SunsetColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
		if(Abool == 1)
			ten.color = Color.Lerp(ten.color, NightColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
		if(Abool == 2)
			ten.color = Color.Lerp(ten.color, RainColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
		if(Abool == 3)
			ten.color = Color.Lerp(ten.color, MorningColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
		if(Abool == 4)
			ten.color = Color.Lerp(ten.color, DayColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
	}

//	 void ColorChange(int a)
//	{
	//	print(" KURDE NO" + a);
	/*	if(a == 0)
			ten.color = Color.Lerp(ten.color, SunsetColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
		if(a == 1)
			ten.color = Color.Lerp(ten.color, NightColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
		if(a == 2)
			ten.color = Color.Lerp(ten.color, RainColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
		if(a == 3)
			ten.color = Color.Lerp(ten.color, MorningColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
		if(a == 4)
			ten.color = Color.Lerp(ten.color, DayColor, Mathf.PingPong(Time.deltaTime*smooth, 1.0f));
		*/
//	}


}