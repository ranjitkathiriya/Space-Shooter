using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public GameObject enimies;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restarttext;
	public GUIText gameovertext;

	private bool gameover;
	private bool restart;
	private int score;

	void Start(){
		gameover = false;
		restart = false;
		gameovertext.text=" ";
		restarttext.text=" ";

		score = 0;

		UpdateScrore ();
		StartCoroutine(SpawnWaves());
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true){ 
			for(int i=0;i<hazardCount;i++){
				Vector3 spawnposition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnrotation = Quaternion.identity;
				Instantiate (hazard, spawnposition, spawnrotation);
				Instantiate (enimies, spawnposition, spawnrotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);


			if (gameover)
			{
				restarttext.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}


	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScrore ();
	
	
	}

	void UpdateScrore(){

		scoreText.text = "Score : " + score;
	}

	public void GameOver ()
	{
		gameovertext.text = "Game Over!";
		gameover = true;
	}
}
