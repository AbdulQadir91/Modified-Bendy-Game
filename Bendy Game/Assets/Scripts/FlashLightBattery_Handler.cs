using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightBattery_Handler : MonoBehaviour {

	[Header("How many Batteries player has")]
	public int totalBatteries;
	[Header("Battery Slide Notifier")]
	public Image batterySlider;
	bool once;
	public WeaponBehavior flashLight;

	void Start()
	{
		totalBatteries = PlayerPrefs.GetInt("userBatteries",0);
		if (totalBatteries > 0) {
			StartCoroutine (GamePlay_Script_Handler.gsh.returnLevelModelHandler ().fpsWeapons.SelectWeapon(0));
		}
	}

	void LateUpdate()
	{
		if (totalBatteries > 0 && flashLight.lightOn) {
			batterySlider.fillAmount -= 0.00005f;
		}
		batterySlider.transform.GetChild (0).GetComponent<Text> ().text = totalBatteries.ToString ();

		if (totalBatteries == 0) {
			flashLight.lightOn = false;
		}
		if (batterySlider.fillAmount < 0.01f) {
			if (!once) {
				once = true;
				totalBatteries = PlayerPrefs.GetInt ("userBatteries", 1);
				totalBatteries -= 1;
				PlayerPrefs.SetInt ("userBatteries", totalBatteries);
				StartCoroutine (batteryFillAmount());
			}
			batterySlider.fillAmount = 1;
			if (PlayerPrefs.GetInt("userBatteries",1) < 1) {
				batterySlider.gameObject.SetActive (false);
				GamePlay_Script_Handler.gsh.returnLevelModelHandler ().flashLight.haveWeapon = false;
				StartCoroutine (GamePlay_Script_Handler.gsh.returnLevelModelHandler ().fpsWeapons.SelectWeapon(0));
			}
		}
	}

	IEnumerator batteryFillAmount()
	{
		yield return new WaitForSeconds (6f);
		once = false;
	}

	public void updateBatteryCount()
	{
		totalBatteries = PlayerPrefs.GetInt("userBatteries",1);
		totalBatteries += 1;
		PlayerPrefs.SetInt("userBatteries",totalBatteries);
		if (totalBatteries < 0) {
			batterySlider.gameObject.SetActive (true);
		}
	}
}
