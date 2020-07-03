using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour {
	public bool Twice = false;
	public bomb bombscript;
	public bomb1 bomb1script;
	void OnTriggerEnter(Collider player)
	{
		if (player.tag == ("Player1")) 
		{
			if(bombscript.power<bombscript.maxpower)
			bombscript.power++;
			Destroy (gameObject);
		} 
		else if(player.tag==("Player2"))
		{
			//Debug.Log ("up");
			if(bomb1script.power<bomb1script.maxpower)
			bomb1script.power++;
			Destroy (gameObject);
		}
		else if (player.tag == ("Explosion")) 
		{
			if (!Twice) {
				Twice = true;
			} else {
				Destroy (gameObject);
			}
		}

	}
}
