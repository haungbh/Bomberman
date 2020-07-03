using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amount : MonoBehaviour {
	public bool Twice = false;
	void OnTriggerEnter(Collider player)
	{
		if (player.tag == ("Player1")) 
		{
			Player.playerplus ();
			Destroy (gameObject);
		} 
		else if (player.tag == ("Player2")) 
		{
			Player2.playerplus ();
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
