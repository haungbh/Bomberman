using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createprop : MonoBehaviour {
	public LayerMask explosionlevel;
	public GameObject gas;
	public GameObject bomb;
	public GameObject shoe;
	public GameObject ice;
	public GameObject shield;
	public GameObject RPG;
	public GameObject Hat;
	public GameObject Grenade;
	public int index;
	public int PropertyNum;
	RaycastHit hit;
	// Update is called once per frame
	void Update () 
	{
		Physics.Raycast (transform.position+new Vector3(0,-0.5f,0) , Vector3.up, out hit, 2f, explosionlevel);
		if (hit.collider) 
		{
			Destroy (gameObject);
			index = Random.Range (1,PropertyNum+1);
			if (index % PropertyNum == 1||index % PropertyNum == 11||index % PropertyNum == 21||index % PropertyNum == 13) {
				Instantiate (gas, transform.position + new Vector3 (0, -0.4f, -0.2f), gas.transform.rotation);
			} else if (index % PropertyNum == 2||index % PropertyNum == 12||index % PropertyNum == 22||index % PropertyNum == 23) {
				Instantiate (bomb, transform.position, bomb.transform.rotation);
			} else if (index % PropertyNum == 3) {
				Instantiate (ice, transform.position + new Vector3 (0.05f, 0, -0.2f), ice.transform.rotation);
			} else if (index % PropertyNum == 4) {
				Instantiate (shield, transform.position, shield.transform.rotation);
			} else if (index % PropertyNum == 5) {
				Instantiate (RPG, transform.position + new Vector3 (0.25f, -0.2f, -0.2f), RPG.transform.rotation); 
			} else if (index % PropertyNum == 6) {
				Instantiate (Hat, transform.position, Hat.transform.rotation); 
			} else if (index % PropertyNum == 7||index % PropertyNum == 17) {
				Instantiate (Grenade, transform.position + new Vector3 (0, -0.5f, 0), Grenade.transform.rotation); 
			} else if (index % PropertyNum == 8) {

			}else if (index % PropertyNum == 0||index % PropertyNum == 10||index % PropertyNum == 20) {
				Instantiate (shoe,transform.position+new Vector3(0,-0.3f,-0.2f),shoe.transform.rotation);
			}

		} 
	}

}
