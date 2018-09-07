using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGrabber : MonoBehaviour {
	private float grabThreshold = 0.5f;
	private Vector3 holdOffsetPos = new Vector3(0f, 0f, 0f);
	private Quaternion holdOffsetRot = new Quaternion();
	private bool isHoldingObject = false;
	private GameObject holdTarget = null;

	public OVRInput.Controller touchHand;

	// Use this for initialization
	void OnTriggerEnter(Collider otherCollider) {
		if (otherCollider.gameObject.tag == "Capsule" && !isHoldingObject) {
			holdTarget = otherCollider.gameObject;
		}
	}

	void OnTriggerExit(Collider otherCollider) {
		if (holdTarget != null && otherCollider.gameObject.GetInstanceID() == holdTarget.GetInstanceID() && !isHoldingObject) {
			holdTarget = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float gripValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, touchHand);

		if (gripValue > grabThreshold) {
			if (!isHoldingObject && holdTarget != null) {
				isHoldingObject = true;
				holdOffsetPos = holdTarget.transform.position - transform.position;
				holdOffsetRot = Quaternion.Inverse(transform.rotation) * holdTarget.transform.rotation;
				Rigidbody rb = holdTarget.GetComponent<Rigidbody>();
				rb.isKinematic = true;
				rb.velocity = new Vector3(0f, 0f, 0f);
				rb.angularVelocity = new Vector3(0f, 0f, 0f);
			}
		} else {
			if (isHoldingObject) {
				Rigidbody rb = holdTarget.GetComponent<Rigidbody>();
				rb.isKinematic = false;
				isHoldingObject = false;
			}
		}

		if (isHoldingObject && holdTarget != null) {
			holdTarget.transform.position = transform.position + transform.rotation * holdOffsetPos;
			holdTarget.transform.rotation = transform.rotation * holdOffsetRot;
		}
	}
}
