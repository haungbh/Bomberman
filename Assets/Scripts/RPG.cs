using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG : MonoBehaviour {
	public bool Twice = false;
	void OnTriggerEnter(Collider player)
	{
		if (player.tag == ("Player1")) 
		{
			player.GetComponent<Player> ();
			Player.ToRPGmode ();
			Destroy (gameObject);
		}
		if (player.tag == ("Player2")) 
		{
			player.GetComponent<Player2> ();
			Player2.ToRPGmode ();
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
