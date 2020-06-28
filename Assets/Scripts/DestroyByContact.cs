 using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerexplosion;
	public int ScoreValue;
	private GameController gamecontroller;


	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gamecontroller = gameControllerObject.GetComponent <GameController>();
		}
		if (gamecontroller == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		//Debug.Log ("Result>> "+other.name);
		if (other.tag == "Boundary")
		{
			return;
		}


		Instantiate(explosion,transform.position,transform.rotation);

		if (other.tag == "Player") {

			Instantiate (playerexplosion, other.transform.position, other.transform.rotation);
			gamecontroller.GameOver();
		}  
		gamecontroller.AddScore (ScoreValue);

		Destroy(other.gameObject);
		Destroy(gameObject);
		//Debug.Log ("Result>> "+other.gameObject +"  "+gameObject);
	}
}
