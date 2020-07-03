using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalStateManager : MonoBehaviour {
	public GameObject propblock;
	public GameObject FallingBrick;
	public GameObject p1;
	public GameObject p2;
	public Timer TimerScript;
	public Player player1;
	public Player2 player2;
	public Text UIMessage;
	//public Text Count;
	public bool Done = false;
	public bool Over = false;
	public float hieght;
	public float Gap;
	public int RoundNum = 0;
	public int Player1Wins = 0;
	public int Player2Wins = 0;
	Vector3 location;
	Vector3 FallingPoint;
	void Update()
	{
		if (TimerScript.total == 44&&!Done) 
		{
			//StartCoroutine ("CreateBricks");
		}
		if (player1.Dead&&!player2.Dead) 
		{
			UIMessage.text="PLAYER2 WINS!!";
			StartCoroutine ("ReStart");
		} 
		else if (player2.Dead&&!player1.Dead) 
		{
			UIMessage.text = "PLAYER1 WINS!!";
			StartCoroutine ("ReStart");
		}
		else if (player2.Dead&&player1.Dead) 
		{
			UIMessage.text = "         DRAW!!";
			StartCoroutine ("ReStart");
		}
	}
	void Start()
	{
		Invoke ("CreatePropForBig",3.0f);
		StartCoroutine ("EnabledPlayer");
		//CreatePlayer ();
		//StartCoroutine("GameLoop");
	}
	public void create(Vector3 pos)
	{
		Instantiate (propblock,pos,Quaternion.identity);
	}
	IEnumerator EnabledPlayer()
	{
		player1.enabled = false;
		player2.enabled = false;
		yield return new WaitForSeconds (3.0f);
		player1.enabled = true;
		player2.enabled = true;
	}
	IEnumerator ReStart()
	{
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene (0);
	}
	IEnumerator CreateBricks()
	{ 
		Done = true;
		for (int j = 0; j < 2; j++) 
		{
			for (int i = 1+j; i <= 8-j; i++) 
			{
				FallingPoint = new Vector3 (1+j, hieght, i);
				Instantiate (FallingBrick, FallingPoint, FallingBrick.transform.rotation);
				yield return new WaitForSeconds (Gap);
			}
			for (int i = 2+j; i <= 16-j; i++) 
			{
				FallingPoint = new Vector3 (i, hieght, 8-j);
				Instantiate (FallingBrick, FallingPoint, FallingBrick.transform.rotation);
				yield return new WaitForSeconds (Gap);
			}
			for (int i = 7-j; i >1+j; i--) 
			{
				FallingPoint = new Vector3 (16-j, hieght, i);
				Instantiate (FallingBrick, FallingPoint, FallingBrick.transform.rotation);
				yield return new WaitForSeconds (Gap);
			}
			for (int i = 16-j; i >1+j; i--) 
			{
				FallingPoint = new Vector3 (i, hieght, 1+j);
				Instantiate (FallingBrick, FallingPoint, FallingBrick.transform.rotation);
				yield return new WaitForSeconds (Gap);
			}
		}
		/*for (int j = 0; j < 3; j++) 
		{
			for (int i = 3; i <= 6; i++) 
			{
				FallingPoint = new Vector3 (3+j, hieght, i);
				Instantiate (FallingBrick, FallingPoint, FallingBrick.transform.rotation);
				FallingPoint = new Vector3 (14-j, hieght, 9-i);
				Instantiate (FallingBrick, FallingPoint, FallingBrick.transform.rotation);
				yield return new WaitForSeconds (Gap);
			}
		}*/

	}
	void CreateProp()
	{
		for (int i = 1; i <= 8; i++) 
		{
			if (i == 1 || i == 8) 
			{
				if (i == 1) 
				{
					for (int j = 1; j <= 14; j++) {
						location = new Vector3 (j, 0.5f, i);
						create (location);
					}
				} 
				else 
				{
					for (int j = 3; j <= 16; j++) {
						location = new Vector3 (j, 0.5f, i);
						create (location);
					}
				}

			}
			if (i % 3 == 0) 
			{
				for (int j = 1; j <= 16; j++) 
				{
					if (j == 2 || j == 15) {
					}
					else 
					{
						location = new Vector3 (j,0.5f,i);
						create(location);
					}
				}
			}
			if(i==4||i==5)
			{
				for(int j=1;j<=16;j++)
				{
					if (j == 4 || j == 6 || j == 8 || j == 9 || j == 11 || j == 13) {
					}
					else
					{
						location = new Vector3 (j,0.5f,i);
						create(location);
					}
				}
			}
			if (i == 2 || i == 7) 
			{
				if (i == 2) {
					for (int j = 1; j <= 14; j++) {
						if (j == 1 || j == 5 || j == 7 || j == 10 || j == 12) {
							location = new Vector3 (j, 0.5f, i);
							create (location);
						}
					}
				} else {
					for (int j = 1; j <= 16; j++) {
						if (j == 5 || j == 7 || j == 10 || j == 12 || j == 16 ) {
							location = new Vector3 (j, 0.5f, i);
							create (location);
						}
					}
				}

			}
		}
	}
	/*void CreateBlocks()
	{
		for (float i = 1; i <= 7; i++) 
		{
			if (i % 2 == 1) 
			{
				if (i == 7 ) 
				{
					for (float j = 3; j <= 8; j++) 
					{
						location=new Vector3(j,0.5f,i);
						create(location);
					}	
				}
				else if(i==1)
				{
					for (float j = 1; j <= 6; j++) 
					{
						location=new Vector3(j,0.5f,i);
						create(location);
					}	
				}
				else
				{
					for (float j = 1; j <= 8; j++) 
					{
						location=new Vector3(j,0.5f,i);
						create(location);
					}	
				}	
			}
		}
		for (float i = 1; i <= 8; i++) 
		{
			if (i == 1) 
			{
				for (float j = 2; j <= 4; j += 2) 
				{
					location=new Vector3(i,0.5f,j);
					create(location);
				}
			}
			if (i == 8) 
			{
				for (float j = 4; j <= 6; j += 2) 
				{
					location=new Vector3(i,0.5f,j);
					create(location);
				}
			}
			if (i % 3 == 0) 
			{
				for (float j = 2; j <= 6; j += 2) 
				{
					location=new Vector3(i,0.5f,j);
					create(location);
				}
			}

		}
	}*/
	void CreatePropForBig()
	{
		for (int i = 1; i <= 12; i++) 
		{
			if (i == 1 || i == 12) 
			{
				for (int j = 3; j <= 6; j++) 
				{
					location = new Vector3 (j, 0.5f, i);
					create (location);
				}
				for (int j = 11; j <= 14; j++) 
				{
					location = new Vector3 (j, 0.5f, i);
					create (location);
				}
			}
			if (i == 3 ||i == 10) 
			{
				for (int j = 1; j <= 16; j++) 
				{
					location = new Vector3 (j, 0.5f, i);
					create (location);
				}
			}
			if (i == 2 || i == 11) 
			{
				for (int j = 5; j <= 7; j++) 
				{
					location = new Vector3 (j, 0.5f, i);
					create (location);
				}
				for (int j = 10; j <= 12; j++) 
				{
					location = new Vector3 (j, 0.5f, i);
					create (location);
				}
			}
			if (i == 4 || i == 5|| i == 6|| i == 7|| i == 8|| i == 9) 
			{
				location = new Vector3 (2, 0.5f, i);
				create (location);
				location = new Vector3 (15, 0.5f, i);
				create (location);
				location = new Vector3 (4, 0.5f, i);
				create (location);
				location = new Vector3 (13, 0.5f, i);
				create (location);
				location = new Vector3 (8, 0.5f, i);
				create (location);
				location = new Vector3 (9, 0.5f, i);
				create (location);
				if (i == 4 || i == 9) 
				{
					location = new Vector3 (6, 0.5f, i);
					create (location);
					location = new Vector3 (7, 0.5f, i);
					create (location);
					location = new Vector3 (10, 0.5f, i);
					create (location);
					location = new Vector3 (11, 0.5f, i);
					create (location);
				}
			}
		}
	}
	public IEnumerator count()
	{
		yield return new WaitForSeconds (1.0f);
		for(int i=4;i>=0;i--)
		{
			if (i == 0) {
				UIMessage.text = "";
			}else if (i == 1) {
				UIMessage.text = "GO!";
			} else {
				UIMessage.text = "  "+(i-1)+"";
			}
			yield return new WaitForSeconds (1.0f);
		}
	}
	/*void CreatePlayer()
	{
		Instantiate (p1,new Vector3(1,0.5f,12),p1.transform.rotation);
		Instantiate (p2,new Vector3(16,0.5f,1),p2.transform.rotation);
	}
	IEnumerator GameLoop()
	{
		//StartCoroutine ("EnabledPlayer");
		//yield return new WaitForSeconds (3.0f);
		CreatePropForBig ();
		yield return StartCoroutine (RoundStart());
		yield return StartCoroutine (RoundPlay());
		yield return StartCoroutine (RoundEnd());

		if (Over) {
			SceneManager.LoadScene (0);
		} 
		else 
		{
			StartCoroutine ("GameLoop");
		}
	}
	private string RoundWin()
	{
		string Winner;
		if (!p1.activeSelf) 
		{
			Winner="2";
			Debug.Log ("2");
			Player2Count++;
			return Winner;
		}
		else if (!p2.activeSelf) 
		{
			Winner="1";
			Debug.Log ("1");
			Player1Count++;
			return Winner;
		}
		return null;
	}
	public bool OnePlayerLeft()
	{
		//bool OneLeft=false;
		if (p1.activeSelf && p2.activeSelf)
			return false;
		else
			return true;
	}
	IEnumerator RoundStart()
	{
		p1.transform.position = new Vector3 (1, 0.5f, 12);
		p2.transform.position = new Vector3 (16, 0.5f, 1);
		RoundNum++;
		UIMessage.text = "Round" + RoundNum;
		yield return new WaitForSeconds(1.0f);
		StartCoroutine ("EnabledPlayer");
		StartCoroutine ("count");
		yield return null;
	}
	IEnumerator RoundPlay()
	{
		UIMessage.text = string.Empty;
		while (!OnePlayerLeft()) 
		{
			yield return null;
		}
	}
	IEnumerator RoundEnd()
	{
		string message = EndMessage ();
		UIMessage.text = message;
		yield return new WaitForSeconds (2.0f);
	}
	string EndMessage()
	{
		string WMessage = "";
		string RWinner = RoundWin ();
		WMessage = "PLAYER" + RWinner + "WINS THE ROUND";
		WMessage+="PLAYER1:"+Player1Count+"WINS\n";
		WMessage+="PLAYER2:"+Player2Count+"WINS";
		if (Player1Count == 3) 
		{
			WMessage = "PLAYER1 WINS THE GAME";
			Over = true;
		}
		else if (Player2Count == 3) 
		{
			WMessage = "PLAYER2 WINS THE GAME";
			Over = true;
		}
		return WMessage;
	}*/
}
