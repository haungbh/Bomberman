using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour {

	public Timer timer;
	public bool show = false;
	void Start()
	{
		GetComponent<Text>().text="";
	}
	// Update is called once per frame
	void Update () 
	{
		if (timer.total == 47&&!show) {
			StartCoroutine ("ShowWarning");
		}
	}
	IEnumerator ShowWarning()
	{
		show = true;
		for(int i=0;i<3;i++)
		{
			GetComponent<Text>().text="Warning!";
			yield return new WaitForSeconds(0.5f);
			GetComponent<Text>().text="";
			yield return new WaitForSeconds(0.5f);
		}
	}
}
