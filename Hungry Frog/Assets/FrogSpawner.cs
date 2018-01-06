using UnityEngine;
using System.Collections;

public class FrogSpawner : MonoBehaviour 
{

	public GameObject[] Skins;
	public int SkinCount;
	public bool[] Locked;
	public int Actual;
	public static int Actualn;
	public GameObject RandomBox;
	public int FrogCost = 30;

	void Start () 
	{
		Actual = PlayerPrefs.GetInt("Frog",0);
		GameObject Frogv2 = Instantiate(Skins[PlayerPrefs.GetInt("Frog",0)], new Vector3(0,0,0) ,Quaternion.identity) as GameObject;
	
	}




	public void RightWeGo()
	{
		if(Actual<SkinCount)
		{
			GameObject Zabinson = GameObject.FindGameObjectWithTag("Zaba");
			Zabinson.SendMessage("Left", false);
			Actual++;
			if(Locked[Actual])
			{
				GameObject LockedFrogR = Instantiate(Skins[30], new Vector3(40,0,0) ,Quaternion.identity) as GameObject;
				LockedFrogR.SendMessage("Left", true);
					
			}
			else
			{
				GameObject FrogR = Instantiate(Skins[Actual], new Vector3(40,0,0) ,Quaternion.identity) as GameObject;
				FrogR.SendMessage("Left", true);
			}
		}


	}

	public void LeftWeGo()
	{
		
		if(Actual>0)
		{
			GameObject Zabinson = GameObject.FindGameObjectWithTag("Zaba");
			Zabinson.SendMessage("Right", false);
			Actual--;
			if(Locked[Actual])
			{
				GameObject LockedFrogL = Instantiate(Skins[30], new Vector3(-40,0,0) ,Quaternion.identity) as GameObject;
				LockedFrogL.SendMessage("Right", true);
			}
			else
			{
				GameObject FrogL = Instantiate(Skins[Actual], new Vector3(-40,0,0) ,Quaternion.identity) as GameObject;
				FrogL.SendMessage("Right", true);
			}
		}
	}


	public void RandomBoxAppear()
	{
			// zabka leci w prawo
			GameObject Zabinson = GameObject.FindGameObjectWithTag("Zaba");
			Zabinson.SendMessage("Right", false);

			// instancjuj pudlo
			GameObject BOX = Instantiate(RandomBox, new Vector3(-40,0,0) ,Quaternion.identity) as GameObject;
			BOX.SendMessage("Right");

	}

	public void RandomBoxDestroy()
	{
		
		GameObject FrogR = Instantiate(Skins[Actual], new Vector3(40,0,0) ,Quaternion.identity) as GameObject;
		FrogR.SendMessage("Left", true);

		GameObject BOX = GameObject.FindGameObjectWithTag("Box");
		BOX.SendMessage("Left");
	}


	public void BuyFrog()
	{
		//if(FrogCost <= PlayerPrefs.GetInt("CoinCount",0))
	//	{
			PlayerPrefs.SetInt("CoinCount",PlayerPrefs.GetInt("CoinCount",0) - FrogCost);
			int XD = Random.Range(1,6);
			GameObject FrogR = Instantiate(Skins[XD], new Vector3(0,0,0) ,Quaternion.identity) as GameObject;
			Actual = XD;
			if(Locked[Actual])
			{
				Locked[Actual] = false;
				PlayerPrefs.SetInt("Locked" + Actual,2);
			}
			else
			{
				PlayerPrefs.SetInt("CoinCount",PlayerPrefs.GetInt("CoinCount",0) + 20);
			}

			GameObject BOX = GameObject.FindGameObjectWithTag("Box");
			BOX.SendMessage("Up");
		//}
	}

	public void Select()
	{
		if(Locked[Actual] == false)
		{
			PlayerPrefs.SetInt("Frog",Actual);
		}
	}

	public void Back()
	{
		if(Actual < PlayerPrefs.GetInt("Frog",0))
		{
			
			GameObject Zabinson = GameObject.FindGameObjectWithTag("Zaba");
			Zabinson.SendMessage("Left", false);

			GameObject FrogR = Instantiate(Skins[PlayerPrefs.GetInt("Frog",0)], new Vector3(40,0,0) ,Quaternion.identity) as GameObject;
			FrogR.SendMessage("Left", true);

			Actual = PlayerPrefs.GetInt("Frog",0);
		}
		else if(Actual > PlayerPrefs.GetInt("Frog",0))
		{
			GameObject Zabinson = GameObject.FindGameObjectWithTag("Zaba");
			Zabinson.SendMessage("Right", false);

			GameObject FrogL = Instantiate(Skins[PlayerPrefs.GetInt("Frog",0)], new Vector3(-40,0,0) ,Quaternion.identity) as GameObject;
			FrogL.SendMessage("Right", true);

			Actual = PlayerPrefs.GetInt("Frog",0);
		}
	}

	void Awake()
	{
		for(int i = 1; i<=SkinCount; i++)
		{
			if(PlayerPrefs.GetInt("Locked" + i,0) == 2)
			{
				Locked[i] = false;
			}
			else
			{
				Locked[i] = true;
			}
		}
	}

}
