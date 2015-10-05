using UnityEngine;
using System.Collections;

public class MissileMove : MonoBehaviour {
	
	[SerializeField] bool moveRight = false ;
	[SerializeField] GameObject BomEf;

	[SerializeField] bool Item = false;

	AudioSource audioData;

	void Awake()
	{
		Vector3 point = transform.localPosition;
		point.y = Random.Range(4.4f,-2.0f);
		if(moveRight)
		{
			point.x = -9;
		}else
		{
			point.x = 9;
		}
		transform.localPosition = point ;

		audioData = GetComponent<AudioSource>();


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 point = transform.localPosition;

		if( moveRight )
		{
			point.x += Time.deltaTime*5;
		}else
		{
			point.x -= Time.deltaTime*5;
		}

		//消滅
		{
			float max= 9f;
			if( moveRight )
			{
				if( point.x >= max )
				{
					Destroy(gameObject);
				}
			}
			else
			{
				if( point.x <= -max )
				{
					Destroy(gameObject);
				}
			}
		}
		transform.localPosition = point ;
	}

	//ぶつかったとき
	void OnCollisionEnter2D(Collision2D col)
	{
		//アイテムの場合
		if( Item )
		{
			PlayerMove pl = col.gameObject.GetComponent<PlayerMove>();
			if( pl != null )
			{
				Score.ScorePoint += 10;


				if( Sound.main != null )
				{
					Sound.main.PlaySound(1);
				}
			}
		}else
		{
			if( BomEf != null )
			{
				GameObject Bom = (GameObject)Instantiate( BomEf );
				Bom.transform.localPosition = transform.localPosition;
			}

			if( Sound.main != null )
			{
				Sound.main.PlaySound(0);
			}

			PlayerMove pl = col.gameObject.GetComponent<PlayerMove>();
			if( pl != null )
			{
				pl.hitChara();
			}
		}
		transform.localScale = new Vector3(0,0,0);
		Destroy( gameObject );
	}



}
