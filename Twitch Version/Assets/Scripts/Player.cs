using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	void Update ()
	{
		//Golpear
		if (Input.GetKeyDown (KeyCode.Space)) {
			FightManager.singleton.StartPlayerAnimation (
				"LeftPunch");
		}
		if (Input.GetKey (KeyCode.LeftArrow) && Input.GetKeyDown (KeyCode.Space)) {
			
			FightManager.singleton.StartPlayerAnimation (
				"LeftUpPunch");
		}
		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKeyDown (KeyCode.Space)) {

			FightManager.singleton.StartPlayerAnimation (
				"UltimateHiperXtremePunch");
		}
		//Cubrirse
		if (Input.GetKeyDown (KeyCode.DownArrow)) {

			FightManager.singleton.playerDodge = true;
			FightManager.singleton.animPlayer.SetBool ("Dodge", true);
			FightManager.singleton.StartPlayerAnimation (
				"IdleDodge");
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {

			FightManager.singleton.playerDodge = false;
			FightManager.singleton.animPlayer.SetBool ("Dodge", false);
		}
		//Esquivar
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			FightManager.singleton.playerDodge = true;
			Invoke ("SetDodgeFalse", 0.5f);
			FightManager.singleton.StartPlayerAnimation (
				"LeftDodge");
		}

	
	}


	void SetDodgeFalse()
	{
		FightManager.singleton.playerDodge = false;
	}
}
