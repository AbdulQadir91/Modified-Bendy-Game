using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMode_Handler : MonoBehaviour {

	[Header("Primary Objective")]
	public string levelPrimaryObjectives;

	[Header("Secondary Objectives")]
	public string[] levelSecondaryObjectives;

	[Header("Contain CutScene?")]
	public bool hasCutScene;
	[Header("CutScene Object")]
	public GameObject cutSceneObject;
	public float cutSceneTime;
	public bool skipCutScene;
	[Header("FPS spawn point and Ref")]
	public Transform spawnPoint;
	public Transform fpsPlayer;
	public WeaponBehavior flashLight;
	public PlayerWeapons fpsWeapons;
	[Header("Inventory")]
	public bool hasFlashLight;
	public bool hasMap;
	[Header("Helping item Picked up")]
	public int helpItem;
	public int minPickUpHelpItem;
	public UnityEngine.Events.UnityEvent actionToPerformAfterMinPickups;


	void Start()
	{
		fpsPlayer.transform.position = spawnPoint.transform.position;
		fpsPlayer.transform.rotation = spawnPoint.transform.rotation;
		flashLight.haveWeapon = hasFlashLight;
		if (hasMap) {
			GamePlay_Script_Handler.gsh.miniMap.SetActive (true);
		}
		enableFlashLight ();
	}

	public void enableFlashLight()
	{
		StartCoroutine (delayedCallFlashLight());
	}

	public IEnumerator delayedCallFlashLight()
	{
		yield return new WaitForSeconds (2f);
		if (hasFlashLight) {
			StartCoroutine (fpsWeapons.SelectWeapon(1));
		}
	}


	public IEnumerator cutSceneInit()
	{
		cutSceneObject.SetActive (true);
		yield return new WaitForSeconds (cutSceneTime);
		if (!skipCutScene) {
			GamePlay_Script_Handler.gsh.initLevelObjectives ();
		}
	}

	public void skipCutScene_Event()
	{
		StopCoroutine (cutSceneInit());
		GamePlay_Script_Handler.gsh.initLevelObjectives ();
	}

	public void addHelpingItemsPickedUp()
	{
		helpItem++;
		if (helpItem >= minPickUpHelpItem) {
			actionToPerformAfterMinPickups.Invoke ();
		}
	}

	public void updateTransforms(Transform temp)
	{
		fpsPlayer.transform.position = temp.position;
		fpsPlayer.transform.rotation = temp.rotation;
	}

	public void pickupKeycards(int temp)
	{
		PlayerPrefs.SetInt ("keycards",temp);
	}
}
