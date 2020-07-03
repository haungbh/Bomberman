using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplode : MonoBehaviour {
	public GameObject explosion;
	public LayerMask levelmask;
	public LayerMask explosionlevel;
	public LayerMask bomblevel;
	public float power;
	public bool isboom=false;
	// Use this for initialization
	void Start () 
	{
		if(!isboom)
			StartCoroutine ("explode");
	}
	IEnumerator explode()
	{
		yield return new WaitForSeconds (0.7f);
		Destroy (gameObject);
		explosionrange (power);
	}
	void explosionrange(float range)
	{
		Instantiate (explosion,transform.position,Quaternion.identity);
		RaycastHit hit,hitex,hitbomb;
		for (float i = range; i >= 1f; i--) 
		{
			Physics.Raycast (transform.position , Vector3.right, out hitex, i, explosionlevel);
			if (!hitex.collider) 
			{
				Physics.Raycast (transform.position , Vector3.right, out hit, i, levelmask);
				if (!hit.collider) 
				{
					Physics.Raycast (transform.position , Vector3.right, out hitbomb, i, bomblevel);
					if (!hitbomb.collider) 
					{
						Instantiate (explosion,transform.position+new Vector3(i,0,0),Quaternion.identity);
					} 
					else 
					{
						for (float j = 1; j <= range; j++) 
						{
							Physics.Raycast (transform.position , Vector3.right, out hitbomb, j, bomblevel);
							Instantiate (explosion, transform.position + new Vector3 (j, 0, 0), Quaternion.identity);
							if (hitbomb.collider) 
								break;
						}
					}
				}
			}

			Physics.Raycast (transform.position , Vector3.left, out hitex, i, explosionlevel);
			if (!hitex.collider) 
			{
				Physics.Raycast (transform.position , Vector3.left, out hit, i, levelmask);
				if (!hit.collider) 
				{
					Physics.Raycast (transform.position , Vector3.left, out hitbomb, i, bomblevel);
					if (!hitbomb.collider) 
					{
						Instantiate (explosion,transform.position+new Vector3(-i,0,0),Quaternion.identity);
					} 
					else 
					{
						for (float j = 1; j <= range; j++) 
						{
							Physics.Raycast (transform.position , Vector3.left, out hitbomb, j, bomblevel);
							Instantiate (explosion, transform.position + new Vector3 (-j, 0, 0), Quaternion.identity);
							if (hitbomb.collider)
								break;
						}
					}
				}
			}

			Physics.Raycast (transform.position , Vector3.forward, out hitex, i, explosionlevel);
			if (!hitex.collider) 
			{
				Physics.Raycast (transform.position , Vector3.forward, out hit, i, levelmask);
				if (!hit.collider) 
				{
					Physics.Raycast (transform.position , Vector3.forward, out hitbomb, i, bomblevel);
					if (!hitbomb.collider) 
					{
						Instantiate (explosion,transform.position+new Vector3(0,0,i),Quaternion.identity);
					} 
					else 
					{
						for (float j = 1; j <= range; j++) 
						{
							Physics.Raycast (transform.position , Vector3.forward, out hitbomb, j, bomblevel);
							Instantiate (explosion, transform.position + new Vector3 (0, 0, j), Quaternion.identity);
							if (hitbomb.collider) 
								break;
						}
					}
				}
			}

			Physics.Raycast (transform.position , Vector3.back, out hitex, i, explosionlevel);
			if (!hitex.collider) 
			{
				Physics.Raycast (transform.position , Vector3.back, out hit, i, levelmask);
				if (!hit.collider) 
				{
					Physics.Raycast (transform.position , Vector3.back, out hitbomb, i, bomblevel);
					if (!hitbomb.collider) 
					{
						Instantiate (explosion,transform.position+new Vector3(0,0,-i),Quaternion.identity);
					} 
					else 
					{
						for (float j = 1; j <= range; j++) 
						{
							Physics.Raycast (transform.position , Vector3.back, out hitbomb, j, bomblevel);
							Instantiate (explosion, transform.position + new Vector3 (0, 0, -j), Quaternion.identity);
							if (hitbomb.collider) 
								break;
						}
					}
				}
			}

		}//end for
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == ("Explosion")) 
		{
			Destroy (gameObject);
			explosionrange (power);
			isboom = true;
		}
	}
}
