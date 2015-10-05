using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	SpriteRenderer sproteBase;

	[SerializeField] Sprite[] bomb;

	int indexBomb = 0;
	float timer = 0;

	// Use this for initialization
	void Start () {
	
		sproteBase = GetComponent<SpriteRenderer>();

		sproteBase.sprite = bomb[0];
	}
	
	// Update is called once per frame
	void Update () {
	

		timer += Time.deltaTime;

		if( timer >= 0.1f)
		{
			timer = 0;
			indexBomb++;
			if( indexBomb >= bomb.Length)
			{
				Destroy(gameObject);
				return;
			}
			sproteBase.sprite = bomb[indexBomb];
		}


	}
}
