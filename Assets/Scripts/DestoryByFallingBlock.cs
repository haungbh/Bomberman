using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByFallingBlock : MonoBehaviour {

	void OnTriggerEnter(Collider player)
	{
		if (player.tag == ("Block")) 
		{	
			Destroy (gameObject);
		}
	}
}
