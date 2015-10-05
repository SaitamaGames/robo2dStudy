using UnityEngine;
using System.Collections;

public class CreateMissile : MonoBehaviour {


	[SerializeField] GameObject[] missiles;
	float timer = 0;
	float maxTimer = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if( GameOver.GameOverFlag )
		{
			return;
		}

		timer += Time.deltaTime;

		if( timer >= maxTimer)
		{
			Score.ScorePoint++;

			//だんだんゲームを早く
			Time.timeScale = 1 + (float)Score.ScorePoint / 250 ;


			maxTimer = Random.Range(0.8f,1.5f);
			timer = 0;


		 	GameObject.Instantiate( missiles[ Random.Range(0,missiles.Length) ] );

		}
	}
}
