using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketexplode : MonoBehaviour {
	// Use this for initialization
	public GameObject FakeBomb;
	public float speed;
	static public bool fire=false;
	static public void IsFire()
	{
		fire = true;
	}
	// Update is called once per frame
	void Update () {
		if(fire)
			transform.position += new Vector3 (transform.forward.x * speed, 0, transform.forward.z * speed);
	}
	void OnTriggerEnter(Collider player)
	{
		Destroy (gameObject);
		fire = false;
		transform.position = new Vector3 (Mathf.RoundToInt (transform.position.x), transform.position.y, Mathf.RoundToInt (transform.position.z));
		Instantiate (FakeBomb,new Vector3 (Mathf.RoundToInt (transform.position.x), transform.position.y, Mathf.RoundToInt (transform.position.z)),Quaternion.identity);
	}
		
}
