using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance_Player : MonoBehaviour {

	public float distancePlayer;
	bool once;

	void LateUpdate()
	{
		distancePlayer = Vector3.Distance (this.transform.position,GamePlay_Script_Handler.gsh.fpsPlayer.transform.position);
		if (distancePlayer < 2 && !once) {
			once = true;
			GamePlay_Script_Handler.gsh.hideAll_gpButtons ();
			GamePlay_Script_Handler.gsh.caughtByBendyImage.SetActive (true);
			GamePlay_Script_Handler.gsh.caughtByBendy ();
			gameObject.SetActive (false);
		}
	}
}
