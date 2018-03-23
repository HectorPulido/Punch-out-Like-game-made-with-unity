using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour 
{
	public Animator animPlayer;
	public Animator animEnemy;

	public int playerHealth;
	public int enemyHealth;

	public bool playerDodge;
	public bool enemyDodge;

	public Slider enemyHealthSlider;
	public Slider playerHealthSlider;

	public static FightManager singleton;
	public ParticleSystem marioExplosion;


	void Awake()
	{
		//!duelo
		if (singleton != null) {
			Destroy (this);
			return;
		}
		singleton = this;


		enemyHealthSlider.maxValue = enemyHealth;
		playerHealthSlider.maxValue = playerHealth;
		UpdateSliders ();
	}
	void UpdateSliders()
	{
		enemyHealthSlider.value = enemyHealth;
		playerHealthSlider.value = playerHealth;
	}

	public void StartEnemyAnimation(string anim)
	{
		if (!playerDodge) {

			if (anim == "Punch1") {
				StartCoroutine (Delay (() => {
					StartPlayerAnimation ("GetPunch");
					playerHealth -= 1;
					UpdateSliders ();
				},
					1f));				
	
			} else if (anim == "Punch2") {
				StartCoroutine (Delay (() => {
					StartPlayerAnimation ("GetPunch");
					playerHealth -= 1;
					UpdateSliders ();
				},
					0.5f));
			} else if (anim == "Punch3") {

				StartCoroutine (Delay (() => {
					StartPlayerAnimation ("GetPunch");
					playerHealth -= 2;
					UpdateSliders ();
				},
					0.7f));			

			}
		}
		animEnemy.Play (anim, 0);
	}



	public void StartPlayerAnimation(string anim)
	{
		if (anim == "LeftPunch") 
		{
			enemyDodge = Random.Range (0, 100) > 50;

			if (!enemyDodge) {
				StartCoroutine (Delay (() =>
					{
						StartEnemyAnimation ("GetStomachPunch");
						marioExplosion.Play ();
						enemyHealth -= 1;
						UpdateSliders ();

					},0.5f));
						
			} else {
				StartCoroutine (Delay (() =>
					StartEnemyAnimation ("GuardDown"),
					0.5f));
			
			}
		} 
		else if (anim == "LeftUpPunch") 
		{
			enemyDodge = Random.Range (0, 100) > 50;
			if (!enemyDodge) {
				StartCoroutine (Delay (() =>
					{
						StartEnemyAnimation ("GetStomachPunch");
						marioExplosion.Play ();
						enemyHealth -= 1;
						UpdateSliders ();
					}
					,0.5f));
			} else {			
				StartCoroutine (Delay (() =>
					StartEnemyAnimation ("GuardDown"),
					0.5f));
			}
		}
		else if (anim == "UltimateHiperXtremePunch") 
		{
			enemyDodge = Random.Range (0, 100) > 10;
			if (!enemyDodge) {
				StartCoroutine (Delay (() =>{
					StartEnemyAnimation ("GetFacePunch");
					marioExplosion.Play ();
					enemyHealth -= 2;
					UpdateSliders ();
				},
					1f));

			} else {
				StartCoroutine (Delay (() =>
					StartEnemyAnimation ("GuardUp"),
					1f));
			}
		}
		animPlayer.Play (anim, 0);
	}

	IEnumerator Delay(System.Action action, float delay)
	{
		yield return new WaitForSeconds (delay);
		action.Invoke ();
	}
}
