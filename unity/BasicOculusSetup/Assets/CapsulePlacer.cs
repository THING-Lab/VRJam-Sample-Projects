using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class CapsulePlacer : MonoBehaviour {
	public GameObject capsulePrefab;
	private bool wasButtonPressed = false;
	
	// Update is called once per frame
	void Update () {
		// Before Showing Grab
		bool buttonDown = OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch);
		if (buttonDown) {
			if (!wasButtonPressed) {
				wasButtonPressed = true;
				GameObject newCapusle = (GameObject)Instantiate(capsulePrefab);
				newCapusle.transform.position = transform.position;
			}
		} else {
			wasButtonPressed = false;
		}
	}
}
