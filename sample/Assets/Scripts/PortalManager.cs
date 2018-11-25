using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HTC.UnityPlugin.StereoRendering;
using Valve.VR.InteractionSystem;

public class PortalManager : MonoBehaviour {

	[System.Serializable]
	public class PortalPair {
		public string name;
		public GameObject portalA;
		public GameObject portalB;
	}

	public List<PortalPair> portals = new List<PortalPair>();

	public Transform player;

	public GameObject teleportPointPrefab;

	// Use this for initialization
	void Start () {

		// 	CreateStereoRendererPair(pp);
		// }
		// for (int i = 0; i < 8; ++i) {
		foreach(PortalPair pp in portals) {
			// PortalPair pp = portals.ElementAt(i);
			if (!IsValidPortal(pp.portalA) ||
				!IsValidPortal(pp.portalB)) 
				continue;

			CreateStereoRendererPair(pp);
			// CreatePortalTeleporterPair(pp);
			// CreateSRTeleporterPair(pp);
			PairCreateTeleportPoint(pp);
		}
	}

	public bool IsValidPortal(GameObject portal) {
		return (GetRenderPlane(portal) != null) || (GetColliderPlane(portal) != null);
	}

	void CreateStereoRendererPair(PortalPair pp) {
		StereoRenderer srA = CreateStereoRenderer(pp.portalA);
		StereoRenderer srB = CreateStereoRenderer(pp.portalB);

		srA.canvasOrigin = pp.portalA.transform;
		srA.anchorTransform = pp.portalB.transform;

		srB.canvasOrigin = pp.portalB.transform;
		srB.anchorTransform = pp.portalA.transform;

		GetRenderPlane(pp.portalA).AddComponent<DisableOutOfView>();
		GetRenderPlane(pp.portalB).AddComponent<DisableOutOfView>();
	}

	StereoRenderer CreateStereoRenderer(GameObject portal) {
		GameObject renderPlane = GetRenderPlane(portal);

		StereoRenderer sr = renderPlane.GetComponent<StereoRenderer>();
		if (sr == null) {
			sr = renderPlane.AddComponent<StereoRenderer>();
		}

		sr.isUnlit = true;
		sr.shouldRender = true;
		sr.useScissor = false;
		sr.useObliqueClip = false;
		return sr;
	}

	void PairCreateTeleportPoint(PortalPair pp) {
		TeleportPoint tpA = CreateTeleportPoint(pp.portalA);
		TeleportPoint tpB = CreateTeleportPoint(pp.portalB);

		TeleportThroughPortal ttpA = CreateTeleportThroughPortal(pp.portalA);
		TeleportThroughPortal ttpB = CreateTeleportThroughPortal(pp.portalB);

		ttpA.otherPoint = tpB;
		ttpB.otherPoint = tpA;
	}

	TeleportThroughPortal CreateTeleportThroughPortal(GameObject portal) {
		GameObject colliderPlane = GetColliderPlane(portal);
		if (colliderPlane == null)
			Debug.Log(portal.name);
		Destroy(colliderPlane.GetComponent<PortalTeleporter>());
		return colliderPlane.AddComponent<TeleportThroughPortal>();
	}

	TeleportPoint CreateTeleportPoint(GameObject portal) {
		GameObject teleportPoint = Instantiate(teleportPointPrefab, portal.transform);
		Vector3 localPos = teleportPoint.transform.localPosition;
		localPos -= new Vector3(0.0f, 1.5f, 0.0f);
		teleportPoint.transform.localPosition = localPos;
		return teleportPoint.GetComponent<TeleportPoint>();
	}
	
	GameObject GetRenderPlane(GameObject portal) {
		return GetChildWithName(portal, "RenderPlane");
	}

	GameObject GetColliderPlane(GameObject portal) {
		return GetChildWithName(portal, "ColliderPlane");
	}

	GameObject GetChildWithName(GameObject go, string name) {
		GameObject child = null;
		foreach(Transform t in go.transform) {
			if (t.name == name) {
				child = t.gameObject;
				break;
			}
		}
		return child;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
