using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioControl : MonoBehaviour {

	public static audioControl Instance { set; get;}
	public AudioSource fightSound;
	public AudioSource clickSound;
	public AudioSource pikachuStartSound;
	public AudioSource charizardStartSound; 
	public AudioSource tackleSound;
	public AudioSource thundershockSound;
	public AudioSource flamethrowerSound;
	public AudioSource goPokeballSound;
	public AudioSource enemyInPokeballSound;
	public AudioSource enemyCaughtSound;
	public AudioSource standardSound;

	
	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	public void ClickSound()
	{
		clickSound.Play();
	}
}