using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Center : MonoBehaviour 
{
	public GameObject mucha;
	public GameObject Osa;
	public GameObject Coin;
	public bool Game = false;
	bool arespawned = false;
	static int count = 0;
	public float startpos;
	public float dist;
	public int ilosc = 8;
	public float chance = 0.65f;
	public float CoinChance = 0.9f;
	static int combo = 0;
	static int score = 0;
	static bool AreDead = false;
	public Text ScoreText;
	public Text HScore;
	public Text CoinText;
	public bool tutorial;
	int Chan = 25;
	public float FadeSpeed = 1f;
	public Renderer[] bekgrunds;
	public Renderer[] leaves;
	public GameObject[] FrogParts;
	bool glupieto = true;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(score == 0)
			glupieto = true;
		if(zabson.Game() == true && count == 0)
		{	
			if(tutorial == true)
			{
				count++;
				spawnTut();
			}
			else
			{
				count++;
				spawn();
				if(score % 100 >= Chan && glupieto == true)
				{
					CHANGE();
				}
			}
				
		}

		if(Input.GetKeyDown(KeyCode.S))
			score++;

		CoinText.text = ""+ PlayerPrefs.GetInt("CoinCount",0);
		ScoreText.text = "" + score;
		HScore.text = "High Score : " + PlayerPrefs.GetInt("HScore",0);
		
	}

	public void ScoreMeOut()
	{
		glupieto = false;
		Chan = 25;
		if(score >= 25)
		{
			foreach(GameObject part in FrogParts)
			{
				part.SendMessage("SetA",4);
				//print("dlaczego");
			}
			StartCoroutine(TODAY());
		}
		StartCoroutine(ScoreOut());


	}

	IEnumerator ScoreOut()
	{
		while(score>0)
		{
			score--;
			yield return null;
		}
		yield return null;
	}



	public static int Count()
	{
		return count;
	}

	public static void UnCount()
	{
		count--;
	}

	public static void ZeroCount()
	{
		count = 0;
	}

	public  static void ComboA()
	{
		combo++;
	}
	public static void ComboZ()
	{
		combo = 0;

	}

	public static void AddScore()
	{
		score++;

		Umieralnia.AddingAPoint();
		if(score > PlayerPrefs.GetInt("HScore", 0))
		{
			PlayerPrefs.SetInt("HScore", score);
		}
	}

	public static void AddCoin()
	{
		
		PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount",0)+1);
		coincount.AddingACoin();

	}


	void spawnTut()
	{
		GameObject fly = Instantiate(mucha, new Vector3(0,startpos + (dist*0),0) ,Quaternion.identity) as GameObject;
		GameObject wasp = Instantiate(Osa, new Vector3(0,startpos + (dist*4),0) ,Quaternion.identity) as GameObject;
		tutorial = false;
	}

	IEnumerator TODAY()
	{


		for(int i = 0; i<5;i++)
		{
			
			Color bekgrund = bekgrunds[i].material.color;
			Color Leaf = leaves[i].material.color;
			while(bekgrund.a < 1)
			{
				bekgrund.a += Time.deltaTime*FadeSpeed;
				bekgrunds[i].material.color = bekgrund;
				Leaf.a += Time.deltaTime*FadeSpeed;
				leaves[i].material.color = Leaf;
				yield return null;
			}
		}
		yield return null;
	}

	IEnumerator Weather()
	{
		int fa = (Chan/25) - 1;
		Color bekgrund = bekgrunds[fa].material.color;
		Color Leaf = leaves[fa].material.color;

		foreach(GameObject part in FrogParts)
		{
			part.SendMessage("SetA",fa);
			//print("dlaczego");
		}

		while(bekgrund.a >0)
		{
			bekgrund.a -= Time.deltaTime*FadeSpeed;
			bekgrunds[fa].material.color = bekgrund;
			Leaf.a -= Time.deltaTime*FadeSpeed;
			leaves[fa].material.color = Leaf;
			yield return null;
		}
		yield return null;
	}

	void CHANGE()
	{


		/*
		if(Chan == 25)
		{ // TO SUNSET
			StartCoroutine(Weather("bgday", 246, 192, 130));
		}
		if(Chan == 50)
		{// TO NIGHT
			StartCoroutine(Weather("bgsunset", 106, 125, 158));
		}
		if(Chan == 75)
		{// TO RAIN
			StartCoroutine(Weather("bgnight", 169, 180, 225));
		}
		if(Chan == 100)
		{// TO MORNING
			StartCoroutine(Weather("bgrain", 228, 210, 226));
		}
		if(Chan == 125)
		{// BACK TO DAY
			//StartCoroutine(TODAY());
		}
*/
		FrogParts = GameObject.FindGameObjectsWithTag("FrogPart");

		if(Chan != 125)
		{
			StartCoroutine(Weather());
			Chan += 25;
		}
		else
		{
			Chan = 25;
			StartCoroutine(TODAY());


		}

	}

	void spawn()
	{
		bool first = true;
		bool FlyTrue = false;
		int FlyInRow = 0;
		for(int i = 0; i <ilosc; i++)
		{

			if(i<ilosc-1)
			{
				if(Random.value >= chance && i != 0 && FlyInRow < 2)
				{	
					if(first == true)
					{
						GameObject fly = Instantiate(mucha, new Vector3(0,startpos + (dist*i),0) ,Quaternion.identity) as GameObject;
						first = false;
						FlyInRow ++;
						FlyTrue = true;
					}
					else
					{
						if(Random.value <= CoinChance)
						{
							GameObject fly = Instantiate(mucha, new Vector3(0,startpos + (dist*i),0) ,Quaternion.identity) as GameObject;
							count++;
						}
						else
						{
							GameObject Coinn = Instantiate(Coin, new Vector3(0,startpos + (dist*i),0) ,Quaternion.identity) as GameObject;

						}
						FlyInRow ++;
					
					}
					if(FlyInRow == 1)
						chance = 0.85f;
				}
				else
				{
					GameObject wasp = Instantiate(Osa, new Vector3(0,startpos + (dist*i),0) ,Quaternion.identity) as GameObject;
					FlyInRow = 0;
					chance = 0.5f;
				}
			}
			else
			{
				if(FlyTrue == false)
				{
					GameObject fly = Instantiate(mucha, new Vector3(0,startpos + (dist*i),0) ,Quaternion.identity) as GameObject;
				}
				else
				{
					GameObject wasp = Instantiate(Osa, new Vector3(0,startpos + (dist*i),0) ,Quaternion.identity) as GameObject;
				}
			}
		}
		
	}
}
