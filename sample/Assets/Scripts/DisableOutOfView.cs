using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HTC.UnityPlugin.StereoRendering;
using Valve.VR.InteractionSystem;

public class DisableOutOfView : MonoBehaviour {

	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsInView() && IsClose()) {
			EnablePortalRendering();
		} else {
			DisablePortalRendering();
		}
	}

	public void DisablePortalRendering() {
		StereoRenderer stereoRend = GetComponent<StereoRenderer>();
		if (stereoRend == null)
			return;

		stereoRend.enabled = false;

		foreach (Transform child in transform) {
			child.gameObject.SetActive(false);
		}
	}

	public void EnablePortalRendering() {
		StereoRenderer stereoRend = GetComponent<StereoRenderer>();
		if (stereoRend == null)
			return;

		stereoRend.enabled = true;

		foreach (Transform child in transform) {
			child.gameObject.SetActive(true);
		}
	}

	public bool IsInView() {
		Vector3 center = rend.bounds.center;
		Vector3 cameraPoint = Camera.main.WorldToViewportPoint(center);
		return cameraPoint.x >= 0 && cameraPoint.x <= 1 && cameraPoint.y >= 0 && cameraPoint.y <= 1;
	}

	public bool IsClose() {
		Vector3 distance = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
		return distance.magnitude <= 20;
	}
}
