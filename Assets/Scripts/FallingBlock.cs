using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour 
{
	public bool IsLand=false;
	public void OnCollisionEnter(Collision other)
	{
		
		if (other.collider.tag == "Floor") 
		{
			IsLand = true;
		}
		else if(!IsLand) 
		{
			Destroy (other.collider.gameObject);
		}
	}

}
