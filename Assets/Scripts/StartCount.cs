using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCount : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("count");
	}
	public IEnumerator count()
	{
		for(int i=4;i>=0;i--)
		{
			if (i == 0) {
				GetComponent<Text> ().text = "";
			}else if (i == 1) {
				GetComponent<Text> ().text = "GO!";
			} else {
				GetComponent<Text> ().text = "  "+(i-1)+"";
			}
				
			yield return new WaitForSeconds (1.0f);
		}
	}


}
