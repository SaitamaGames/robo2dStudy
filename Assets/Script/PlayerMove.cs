using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	//すプレイとのベース
	SpriteRenderer sproteBase;

	[SerializeField] Sprite normalSprite;
	[SerializeField] Sprite JumpSprite;
	[SerializeField] Sprite DeadSprite;
	[SerializeField] Sprite	fallSprite;




	//地面の位置
	float minPoint = -2;

	//現在の行動
	int nowStatus = 0;

	const int Normal = 0;
	const int Jump   = 1;
	const int Fall   = 2;
	const int Dead   = 3;

	//ジャンプしている時間
	float JumpTimer = 0;
	//落下加算
	float fallTimer = 0;


	//

	// 最初に呼ばれる
	void Start () {
	
		sproteBase = GetComponent<SpriteRenderer>();

		nowStatus = Normal;

	}
	
	// 常に呼ばれる
	void Update () {
	
		//状態に応じて変化
		switch( nowStatus )
		{
			//ノーマルモード
			case Normal:
			{
				//絵を変えてる
				sproteBase.sprite = normalSprite;
				normalMode();
				break;
			}
			//じゃんぷモード
			case Jump:
			{
				//絵を変えてる
				sproteBase.sprite = JumpSprite;
				JumpMode();
				break;
			}
			//落下モード
			case Fall:
			{
				//絵を変えてる
				sproteBase.sprite = fallSprite;
				fallMode();
				break;
			}
			//死亡モード
			case Dead:
			{
				//絵を変えてる
				sproteBase.sprite = DeadSprite;
				DeadMode();
				break;
			}

		}
	}

	//ノーマルモード
	void normalMode()
	{
		if( Input.GetMouseButton(0))
		{
			//ボタン押したらジャンプモードへ
			nowStatus = Jump;
			JumpTimer = 0;

		}
	}

	//ジャンプモード
	void JumpMode()
	{
		//うえへいく
		Vector3 point = transform.localPosition;
		point.y += Time.deltaTime*(25 - JumpTimer * 60 );

		JumpTimer+= Time.deltaTime;

		if( Input.GetMouseButton(0) == false ||
		   JumpTimer >= 0.5f )
		{
			nowStatus = Fall;
		}

		transform.localPosition = point ;
	}


	//落下モードの処理
	void fallMode()
	{
		//位置が下がります
		Vector3 point = transform.localPosition;
		point.y -= Time.deltaTime*(2+fallTimer*20);

		if( Input.GetMouseButton (0) )
		{

		}else
		{
			fallTimer += Time.deltaTime;
		}

		//一定ラインまで
		if( point.y <= minPoint )
		{
			fallTimer = 0;
			point.y = minPoint;
			//おちたらノーマルモードへ
			nowStatus = Normal;
		}
		transform.localPosition = point ;
	}

	//しぼうモード
	void DeadMode()
	{
		//位置が下がります
		Vector3 point = transform.localPosition;
		point.y -= Time.deltaTime*3;		
		//一定ラインまで
		if( point.y <= minPoint )
		{
			point.y = minPoint;
		}
		transform.localPosition = point ;
	}

	//死にました
	public void hitChara()
	{
		//
		nowStatus = Dead ;
		GameOver.GameOverFlag = true;
	}


}