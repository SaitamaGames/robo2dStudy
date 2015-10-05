using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	[SerializeField] AudioSource[] audios;
	public static Sound main ;

	void Start () {
		main = this;
	}

	public void PlaySound(int no)
	{
		audios[no].Play();
	}
}
