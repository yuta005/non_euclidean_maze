using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class TeleportThroughPortal : MonoBehaviour {

	public TeleportPoint otherPoint;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!Teleport.instance.justWentThroughPortal) {
			Vector3 playerPosition = Camera.main.transform.position;
			if (CloseEnough(transform.position.x, playerPosition.x) &&
				CloseEnough(transform.position.z, playerPosition.z)) {
				Teleport.instance.teleportingToMarker = otherPoint;
				Teleport.instance.TeleportPlayer();
				Teleport.instance.justWentThroughPortal = true;
			}
		}
	}

	bool CloseEnough(float x, float y) {
		return Mathf.Abs(x - y) <= 0.05;
	}
}
