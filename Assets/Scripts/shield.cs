using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour {
	public bool Twice = false;
	void OnTriggerEnter(Collider player)
	{
		if (player.tag == ("Player1") || player.tag == ("Player2")) 
		{
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
