using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ParentFixedJoint : MonoBehaviour {
	public Rigidbody rigidBodyAttachPoint;

	public Transform sphere;
	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	FixedJoint fixedJoint;
	// Use this for initialization
	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		device = SteamVR_Controller.Input((int) trackedObj.index);
	}

	void onTriggerStay(Collider col){
		if ((fixedJoint ==null) && (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))){
			fixedJoint = col.gameObject.AddComponent<FixedJoint>();
			fixedJoint.connectedBody = rigidBodyAttachPoint;
		}else if((fixedJoint !=null)&& (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))){
			GameObject go = fixedJoint.gameObject;
			Rigidbody rigidBody = go.GetComponent<Rigidbody>();
			Object.Destroy(fixedJoint);
			fixedJoint = null;
		}
	}
}
