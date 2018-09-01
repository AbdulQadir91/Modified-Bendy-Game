using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowlingSoundEffect : MonoBehaviour {
	
	void Start () {
		StartCoroutine (delayedGrowlingStartUp());	
	}
	
	IEnumerator delayedGrowlingStartUp()
	{
		yield return new WaitForSeconds (Random.Range(4,10));
		GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (Random.Range(4,10));
		StartCoroutine (delayedGrowlingStartUp());
	}
}
