using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using System;

public class Player2 : MonoBehaviour {

	//Player parameters
	[Range(1, 2)] //Enables a nifty slider in the editor
	public int playerNumber = 2; //Indicates what player this is: P1 or P2
	public bool canDropBombs = true; //Can the player drop bombs?
	public bool canMove = true; //Can the player move?
	public float moveSpeed = 4f;
	public float sprint = 3.0f;
	public float slow = 5.0f;
	public float force;
	public int random;
	public float ThrowForce;
	public bool GFirst = false;
	static public int bombamount = 1;
	static public int maxamount = 5;
	static public bool icemode = false;
	static public bool RPGmode = false;
	public bool invincible = false;
	public bool KickMode = false;
	public bool GrenadeMode = false;
	public bool Dead = false;
	static public int Wins = 0;

	static public void playerplus()
	{
		if(bombamount<maxamount)
			bombamount++;
	}
	static public void Toicemode()
	{
		icemode = true;
	}
	static public void ToRPGmode()
	{
		RPGmode = true;
	}
	static public void Win()
	{
		Wins++;
	}
	public GameObject bombPrefab;
	public GameObject ice;
	public GameObject RPG;
	public GameObject Rocket;
	public GameObject Mark;
	public GameObject FakeBomb;
	public GameObject Grenade;
	public Rigidbody GrenadeThrow;
	public LayerMask blocklevel;
	public Rigidbody bombrigi;
	public bomb1 bomb1script;
	public MarkPosition MarkScript;
	public Text score;

	//Cached components
	private Rigidbody rigidBody;
	private Transform myTransform;
	private Animator animator;

	// Use this for initialization
	void Start() {
		//Cache the attached components for better performance and less typing
		rigidBody = GetComponent<Rigidbody>();
		myTransform = transform;
		animator = myTransform.Find("PlayerModel").GetComponent<Animator>();
		bomb1script.power = 1;
		bomb1script.GetComponent<Rigidbody> ().isKinematic = true;
		bombamount = 1;
		icemode = false;
		RPGmode = false;
		invincible = false;
		KickMode = false;
		GrenadeMode = false;
		moveSpeed = 6f;
		Dead=false;
		score.text = "PLAYER2: " + Wins;
	}

	// Update is called once per frame
	void Update() {
		UpdateMovement();

	}
	private void UpdateMovement() {
		animator.SetBool("Walking", false);
		UpdatePlayer2Movement();
	}
	/// <summary>
	/// Updates Player 2's movement and facing rotation using the arrow keys and drops bombs using Enter or Return
	/// </summary>
	private void UpdatePlayer2Movement() {
		if (Input.GetKey(KeyCode.UpArrow)) { //Up movement
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
			myTransform.rotation = Quaternion.Euler(0, 0, 0);
			animator.SetBool("Walking", true);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) { //Left movement
			rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
			myTransform.rotation = Quaternion.Euler(0, 270, 0);
			animator.SetBool("Walking", true);
		}

		if (Input.GetKey(KeyCode.DownArrow)) { //Down movement
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
			myTransform.rotation = Quaternion.Euler(0, 180, 0);
			animator.SetBool("Walking", true);
		}

		if (Input.GetKey(KeyCode.RightArrow)) { //Right movement
			rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
			myTransform.rotation = Quaternion.Euler(0, 90, 0);
			animator.SetBool("Walking", true);
		}

		if (canDropBombs && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))) 
		{ //Drop Bomb. For Player 2's bombs, allow both the numeric enter as the return key or players without a numpad will be unable to drop bombs
			if (GrenadeMode == true&&!RPGmode) 
			{
				if (MarkScript.CanThrow == true) 
				{
					GrenadeFly ();
					Instantiate (FakeBomb, new Vector3 (Mark.transform.position.x, 0.5f, Mark.transform.position.z), Quaternion.identity);
					Grenade.SetActive (false);
					Mark.SetActive (false);
					GrenadeMode = false;
					GFirst = false;
				}
			}
			else if (GFirst) 
			{
				if (MarkScript.CanThrow == true) 
				{
					GrenadeFly ();
					Instantiate (FakeBomb, new Vector3 (Mark.transform.position.x, 0.5f, Mark.transform.position.z), Quaternion.identity);
					GrenadeMode = false;
					Grenade.SetActive (false);
					Mark.SetActive (false);
					GFirst = false;
					if (RPGmode)
						RPG.SetActive (true);
				}
			}
			//RPG mode
			else if (RPGmode == true) 
			{
				RPGfire ();
			}
			else if (icemode == true)
				starticemode ();
			else 
			{
				if (bombamount >= 1) 
				{
					DropBomb ();
					bombamount--;
				}
				else
					Debug.Log ("nobomb");
			}
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			transform.position = new Vector3 (Mathf.RoundToInt(transform.position.x),0.5f,Mathf.RoundToInt(transform.position.z));
		}
	}
	private void DropBomb() {
		if (bombPrefab) { //Check if bomb prefab is assigned first
			Instantiate(bombPrefab,new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z)),bombPrefab.transform.rotation);
		}
	}
	private void starticemode()
	{
		RaycastHit hit;
		Physics.Raycast (transform.position , transform.forward, out hit, 3.0f, blocklevel);
		if (!hit.collider) 
		{
			StartCoroutine ("iceattack");
		}
	}

	IEnumerator speedup()
	{
		moveSpeed += 3;
		yield return new WaitForSeconds (sprint);
		moveSpeed -= 3;
	}
	IEnumerator speeddown()
	{
		moveSpeed -= 2;
		yield return new WaitForSeconds (slow);
		moveSpeed += 2;
	}
	IEnumerator returnbomb()
	{
		RPGmode = false;
		yield return new WaitForSeconds (0.5f);
		RPG.SetActive(false);
		if (GrenadeMode) 
		{
			Grenade.SetActive (true);
			Mark.SetActive (true);
		}
	}
	IEnumerator iceattack()
	{
		RaycastHit hitblock;
		Physics.Raycast (transform.position , transform.forward, out hitblock, 1.0f, blocklevel);
		if (!hitblock.collider) 
			Instantiate (ice, new Vector3 (Mathf.RoundToInt (transform.position.x), transform.position.y, Mathf.RoundToInt (transform.position.z))+transform.forward+new Vector3(0.05f,0,-0.2f), ice.transform.rotation);
		yield return new WaitForSeconds (0.1f);
		Physics.Raycast (transform.position , transform.forward, out hitblock, 2.0f, blocklevel);
		if (!hitblock.collider)
			Instantiate (ice, new Vector3 (Mathf.RoundToInt (transform.position.x), transform.position.y, Mathf.RoundToInt (transform.position.z))+2*transform.forward+new Vector3(0.05f,0,-0.2f), ice.transform.rotation);
		yield return new WaitForSeconds (0.1f);
		Physics.Raycast (transform.position , transform.forward, out hitblock, 3.0f, blocklevel);
		if (!hitblock.collider)
			Instantiate (ice, new Vector3 (Mathf.RoundToInt (transform.position.x), transform.position.y, Mathf.RoundToInt (transform.position.z))+3*transform.forward+new Vector3(0.05f,0,-0.2f), ice.transform.rotation);
		yield return new WaitForSeconds (0.3f);
		icemode = false;
	}
	IEnumerator SecondLife()
	{
		GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.15f);
		GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.15f);
		GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.15f);
		GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.15f);
		GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.15f);
		GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
		invincible = false;
	}
	private void RPGfire()
	{
		Instantiate (Rocket,new Vector3 (Mathf.RoundToInt (transform.position.x), transform.position.y, Mathf.RoundToInt (transform.position.z))+transform.forward+new Vector3(0,0.3f,0),transform.rotation);
		Rocketexplode.IsFire ();
		StartCoroutine ("returnbomb");
	}
	private void GrenadeFly()
	{
		Rigidbody GTransform= Instantiate (GrenadeThrow,transform.position+new Vector3(0,0.5f,0),GrenadeThrow.transform.rotation)as Rigidbody;
		GTransform.AddForce ((transform.forward+new Vector3(0,1.5f,0))*ThrowForce);
	}
	public void OnTriggerEnter(Collider other) 
	{
		if (other.tag == ("Explosion")) 
		{
			if (invincible == true) 
			{
				StartCoroutine ("SecondLife");

			}
			else 
			{
				//Debug.Log ("P" + playerNumber + " hit by explosion!");
				Dead=true;
				Player.Win();
				gameObject.SetActive (false);
			}
		}
		else if (other.tag == ("shield")) 
		{
			invincible = true;
		}
		else if (other.tag == ("Hat")) 
		{
			KickMode = true;
			bombrigi.isKinematic = false;
		} 
		else if (other.tag == ("shoe")) 
		{
			//StartCoroutine ("speedup");
			moveSpeed++;
		} 
		else if (other.tag == ("ice")) 
		{
			StartCoroutine ("speeddown");
		}
		else if (other.tag == ("Grenade")) 
		{
			GrenadeMode = true;
			if (!RPGmode) 
			{
				Grenade.SetActive (true);
				Mark.SetActive (true);
				GFirst = true;//Grenade First
			}
		}
		else if (other.tag == ("RPG")&&!GrenadeMode) 
		{
			RPG.SetActive(true);
		}
	}
	public void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Bomb"&&KickMode) 
		{
			other.collider.GetComponent<Rigidbody> ().AddForce (transform.forward*force);
			//KickMode = false;
			//bombrigi.isKinematic = true;
		}
		if (other.collider.tag == "SF_Door") 
		{
			RaycastHit hitdoor;
			Physics.Raycast (transform.position , transform.forward, out hitdoor, 0.5f, blocklevel);
			if (hitdoor.collider) 
			{
				random = Random.Range (1,3);
				if(random==1)
				    transform.position = new Vector3 (5,0.5f,8);
				else if(random==2)
					transform.position = new Vector3 (16,0.5f,11);
			}
		}
		if (other.collider.tag == "Door") 
		{
			RaycastHit hitdoor;
			Physics.Raycast (transform.position , transform.forward, out hitdoor, 0.5f, blocklevel);
			if (hitdoor.collider) 
			{
				random = Random.Range (1,3);
				if(random==1)
					transform.position = new Vector3 (1,0.5f,2);
				else if(random==2)
					transform.position = new Vector3 (12,0.5f,5);
			}
		}
	}
}
