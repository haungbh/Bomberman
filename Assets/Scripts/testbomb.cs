using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbomb : MonoBehaviour {

	public LayerMask bomblevel;
	public Player player;
	public Vector3 RoundPos;
	RaycastHit hit;
	// Update is called once per frame
	void Update () 
	{
		RoundPos = new Vector3 (Mathf.RoundToInt(transform.position.x),0,Mathf.RoundToInt(transform.position.z));
		Physics.Raycast (RoundPos , Vector3.up, out hit, 2f, bomblevel);
		if (hit.collider) 
		{
			player.canDropBombs = false;
		} 
		else 
		{
			player.canDropBombs = true;
		}
	}
}
