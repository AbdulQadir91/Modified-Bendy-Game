using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSimpleLookAt : MonoBehaviour {

	public Transform lookAtThing;


	void FixedUpdate()
	{
		if (lookAtThing) {
			GamePlay_Script_Handler.gsh.fpsPlayer.CameraControlComponent.transform.LookAt (lookAtThing);
		}
	}

	public void _lookAtThing(Transform temp)
	{
		lookAtThing = temp;
	}
	public void _lookAtThingNull()
	{
		lookAtThing = null;
	}
}
