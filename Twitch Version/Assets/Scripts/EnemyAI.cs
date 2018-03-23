using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public float attackPeriod;
	public int attackProbability;
	public string[] punches;

	// Use this for initialization
	IEnumerator Start () 
	{
		while (true) {
			
			yield return new WaitForSeconds (attackPeriod);

			bool attack = Random.Range (0, 100) > attackProbability;

			if(attack)
				FightManager.singleton.StartEnemyAnimation(
					punches [Random.Range (0, punches.Length)]);

		}	
	}

}
