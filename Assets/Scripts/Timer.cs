using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private int minute;
	private int second;
	public int total = 119;
	// Use this for initialization
	void Start () {
		StartCoroutine ("timer");
	}

	// Update is called once per frame
	void Update () 
	{

	}
	IEnumerator timer()
	{
		yield return new WaitForSeconds (3.0f);
		while(total>=0) 
		{
			yield return new WaitForSeconds (1.0f);
			minute = total / 60;
			second = total % 60;
			if (second <10) 
			{
				if (second == 0)
					GetComponent<Text> ().text = " "+minute + ":00";
				else
					GetComponent<Text> ().text = " "+minute + ":0" + second;
			}
			else
			{
				GetComponent<Text> ().text = " "+minute + ":" + second;
			}
			total--;

			if (total == 0)
				SceneManager.LoadScene (0);
		}

			
	}
}
