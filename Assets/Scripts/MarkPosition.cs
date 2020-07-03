using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkPosition : MonoBehaviour {
	// Update is called once per frame
	public Transform player;
	public LayerMask PropBlock;
	public LayerMask Ground;
	public LayerMask Block;
	public bool CanThrow = false;
	void Update () 
	{
		Vector3 pos=new Vector3(Mathf.RoundToInt(player.position.x),0.2f,Mathf.RoundToInt(player.position.z))+2*player.forward;
		transform.position = pos;
		RaycastHit hit;
		Physics.Raycast (transform.position+new Vector3(0,2f,0), Vector3.down, out hit, 5f, PropBlock);
		if (hit.collider) 
		{
			transform.position = pos + new Vector3 (0f, 0.81f, 0);
			GetComponent<SpriteRenderer> ().enabled = true;
			CanThrow = true;
		}
		else 
		{
			RaycastHit hitground;
			Physics.Raycast (transform.position,Vector3.down,out hitground,1f,Ground);
			if (hitground.collider) 
			{
				//Debug.Log ("shooting");
				RaycastHit hitblock;
				Physics.Raycast (transform.position + new Vector3 (0, 1f, 0), Vector3.down, out hitblock, 1f, Block);
				if (hitblock.collider) {
					GetComponent<SpriteRenderer> ().enabled = false;
					CanThrow = false;
				} else {
					GetComponent<SpriteRenderer> ().enabled = true;
					CanThrow = true;
				}
			}
			else
			{
				GetComponent<SpriteRenderer> ().enabled = false;
				CanThrow = false;
			}
		}

	 }
}
