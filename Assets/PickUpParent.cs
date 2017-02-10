using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickUpParent : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	// Use this for initialization
	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		device = SteamVR_Controller.Input((int) trackedObj.index);
		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)){
			Debug.Log("You are holding down");
		}
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)){
			Debug.Log("You are holding");
		}
		//release trigger
		if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)){
			Debug.Log("You are holding up");
		}

		if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger)){
			Debug.Log("You are pressing");
		}
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)){
			Debug.Log("You are pressing down");
		}
		//release trigger
		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)){
			Debug.Log("You are pressing up");
		}
	}
	//sphere's transfrom needs to be child of controller's transform
	void OnTriggerStay(Collider col){
		Debug.Log("Collided");
		if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)){
			col.attachedRigidbody.isKinematic=true;
			col.gameObject.transform.SetParent(this.gameObject.transform);
		}
	}
}
