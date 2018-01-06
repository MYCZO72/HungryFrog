using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour 
{

/// ////////////////////////////////////////////////////////////////////////////// FADINMG FADING FADING FADING  OUT OUT OUT OUT

	public float FadeSpeed = 1f;
	public GameObject center;
	public GameObject FSPWN;
	public Button Right;
	public Button Left;
	public float time = 2f;
	public float BigTime = 4f;
	public float timer;

	void Update() 
	{
		if(timer>=0)
			timer -= Time.deltaTime;
	}

	public void FadeMeOut()
	{
		StartCoroutine(DoFadeOut());
	}

	public void TutorialBt()
	{
		
	}

	IEnumerator DoFadeOut()
	{
		CanvasGroup canvasgroup = GetComponent<CanvasGroup>();
		Canvas canvas = GetComponent<Canvas>();
		canvas.sortingOrder = 0;
		while(canvasgroup.alpha>0)
		{
			
			canvasgroup.alpha -= Time.deltaTime*FadeSpeed;
			yield return null;
		}
		canvasgroup.interactable = false;
		yield return null;
	}

/// <summary>
/// 
/// </summary>
	public void FadeMeIn()
	{
		StartCoroutine(DoFadeIn());
	}

	IEnumerator DoFadeIn()
	{
		CanvasGroup canvasgroup = GetComponent<CanvasGroup>();
		Canvas canvas = GetComponent<Canvas>();
		canvas.sortingOrder = 10;
		while(canvasgroup.alpha<1)
		{
			canvasgroup.alpha += Time.deltaTime*FadeSpeed;
			yield return null;
		}
		canvasgroup.interactable = true;
		yield return null;
	}
////////////////////////////////////////////////////////////////////////////////// FADING FADING FADING FADING
//////////////////T I T L E /////// T I T L E /////// T I T L E //////////////////

	public void PlayBt()
	{
		zabson.GameOn();
	}

	public void SkinsBt()
	{
		
		// nie wiem czy potrzebny heh : )
	}


/////////////////////////////////////////////////////////////////////////////////////
	/// //////////////////RESTART /////////////R E S T A  R T /////////////////////

	public void RestartBt()
	{
		center.SendMessage("ScoreMeOut");
		zabson.GameOn();

	}

//////////////////////////////////////////////////////////////////////////////////
	/// /////////////////


	public void LeftBt()
	{
		if(timer < 0)
		{

			FSPWN.SendMessage("LeftWeGo");
			timer = time;
		}
	}

	public void RightBt()
	{
		if(timer < 0)
		{

			FSPWN.SendMessage("RightWeGo");
			timer = time;
		}
	}
		
	public void Select()
	{
		FSPWN.SendMessage("Select");
	}

	public void GetSkins()
	{
		if(timer < 0)
		{

			FSPWN.SendMessage("RandomBoxAppear");
			timer = time;
		}
	}

	public void BoxDead()
	{
		if(timer < 0)
		{

			FSPWN.SendMessage("RandomBoxDestroy");
			timer = time;
		}	
	}

	public void BuyFrog()
	{
		if(timer < 0)
		{

			FSPWN.SendMessage("BuyFrog");
			timer = time;
		}
	}


	public void BackFromSkins()
	{
		if(timer < 0)
		{

			FSPWN.SendMessage("Back");
			timer = time;
		}
	}
}
