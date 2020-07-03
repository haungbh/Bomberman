using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour {
	void OnTriggerEnter(Collider player)
	{
		if (player.tag =="Floor") 
		{
			Destroy (gameObject);
		}

	}
}
