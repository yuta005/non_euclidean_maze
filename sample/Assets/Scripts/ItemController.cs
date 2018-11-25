using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemController: MonoBehaviour {

    // public GameObject playerCamera;
    // public EventSystem eventSystem;

    public Ray ray;
    public Ray rayItem;
    public RaycastHit hit;
    public GameObject selectedGameObject;

    public GameObject key0, key1, key2, key3;

    public string standName;
    public string myItem;

    public GameObject itemBtn_key0, itemBtn_key1, itemBtn_key2, itemBtn_key3;

    private GameObject goalDoor;

	// Use this for initialization
	void Start () {
        // eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        key0 = GameObject.Find("key0");
        key1 = GameObject.Find("key1");
        key2 = GameObject.Find("key2");
        key3 = GameObject.Find("key3");

        GameObject.Find("itemBtn_key0_plane").GetComponent<Renderer>().enabled = false;
        itemBtn_key0 = GameObject.Find("itemBtn_key0");
        itemBtn_key0.SetActive(false);

        GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
        itemBtn_key1 = GameObject.Find("itemBtn_key1");
        itemBtn_key1.SetActive(false);

        GameObject.Find("itemBtn_key2_plane").GetComponent<Renderer>().enabled = false;
        itemBtn_key2 = GameObject.Find("itemBtn_key2");
        itemBtn_key2.SetActive(false);

        GameObject.Find("itemBtn_key3_plane").GetComponent<Renderer>().enabled = false;
        itemBtn_key3 = GameObject.Find("itemBtn_key3");
        itemBtn_key3.SetActive(false);

        myItem = "noitem";

        goalDoor = GameObject.Find("GoalDoor0");
	}
	
	// Update is called once per frame
	void Update () {

        // if (Input.GetMouseButtonUp(1))
        // {
        //     if (eventSystem.currentSelectedGameObject == null)
        //     {
        //         searchRoom();
        //     }
        // }

        if (itemBtn_key0.activeSelf && itemBtn_key1.activeSelf && itemBtn_key2.activeSelf)
            goalDoor.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            CollectKey(key0.GetComponent<BoxCollider>());
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            CollectKey(key1.GetComponent<BoxCollider>());
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            CollectKey(key2.GetComponent<BoxCollider>());
        }
	
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            CollectKey(key3.GetComponent<BoxCollider>());
        }
    }

    public void searchRoom()
    {
        selectedGameObject = null;
        /*ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000000, 1 << 8))
        {
            selectedGameObject = hit.collider.gameObject;
            switch (selectedGameObject.name)
            {
                case "key0_plane":
                    key0.SetActive(false);
                    itemBtn_key0.SetActive(true);
                    break;
                case "key1_plane":
                    key1.SetActive(false);
                    itemBtn_key1.SetActive(true);
                    break;
                case "key2_plane":
                    key2.SetActive(false);
                    itemBtn_key2.SetActive(true);
                    break;
                case "key3_plane":
                    key3.SetActive(false);
                    GameObject.Find("key3r").SetActive(false);
                    itemBtn_key3.SetActive(true);
                    break;
                case "door0":
                    if (myItem == "key0")
                    {                        
                        iTween.MoveTo(GameObject.Find("door0"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                    }
                    break;
                case "door1":
                    if (myItem == "key1")
                    {
                        iTween.MoveTo(GameObject.Find("door1"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                    }
                    break;
                case "door2":
                    if (myItem == "key2")
                    {
                        iTween.MoveTo(GameObject.Find("door2"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                    }
                    break;
                case "door3":
                    if (myItem == "key3")
                    {
                        iTween.MoveTo(GameObject.Find("door3"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                    }
                    break;
            }
        }*/

        rayItem = GameObject.Find("itemListCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayItem, out hit, 10000000, 1 << 9))
        {
            selectedGameObject = hit.collider.gameObject;
            switch (selectedGameObject.name)
            {
                case "itemBtn_key0_plane":
                    if (myItem == "key0")
                    {
                        GameObject.Find("itemBtn_key0_plane").GetComponent<Renderer>().enabled = false;
                        myItem = "noitem";
                    }
                    else
                    {
                        GameObject.Find("itemBtn_key0_plane").GetComponent<Renderer>().enabled = true;
                        myItem = "key0";
                    }
                    break;
                case "itemBtn_key1_plane":
                    if (myItem == "key1")
                    {
                        GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
                        myItem = "noitem";
                    }
                    else
                    {
                        GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = true;
                        myItem = "key1";
                    }
                    break;
                case "itemBtn_key2_plane":
                    if (myItem == "key2")
                    {
                        GameObject.Find("itemBtn_key2_plane").GetComponent<Renderer>().enabled = false;
                        myItem = "noitem";
                    }
                    else
                    {
                        GameObject.Find("itemBtn_key2_plane").GetComponent<Renderer>().enabled = true;
                        myItem = "key2";
                    }
                    break;
                case "itemBtn_key3_plane":
                    if (myItem == "key3")
                    {
                        GameObject.Find("itemBtn_key3_plane").GetComponent<Renderer>().enabled = false;
                        myItem = "noitem";
                    }
                    else
                    {
                        GameObject.Find("itemBtn_key3_plane").GetComponent<Renderer>().enabled = true;
                        myItem = "key3";
                    }
                    break;
            }
        }
    }

    // void OnTriggerEnter(Collider other)
    public void CollectKey(Collider other)
    {
        Debug.Log(other.gameObject.name);
        switch (other.gameObject.name)
        {
            case "key0":
                key0.SetActive(false);
                itemBtn_key0.SetActive(true);
                break;
            case "key1":
                key1.SetActive(false);
                itemBtn_key1.SetActive(true);
                break;
            case "key2":
                key2.SetActive(false);
                itemBtn_key2.SetActive(true);
                break;
            case "key3":
                key3.SetActive(false);
                GameObject.Find("key3r").SetActive(false);
                itemBtn_key3.SetActive(true);
                break;
            case "door0_plane":
                if (myItem == "key0")
                {
                    iTween.MoveTo(GameObject.Find("door0"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                }
                break;
            case "door1_plane":
                if (myItem == "key1")
                {
                    iTween.MoveTo(GameObject.Find("door1"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                }
                break;
            case "door2_plane":
                if (myItem == "key2")
                {
                    iTween.MoveTo(GameObject.Find("door2"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                }
                break;
            case "door3_plane":
                if (myItem == "key3")
                {
                    iTween.MoveTo(GameObject.Find("door3"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                }
                break;
        }
    }
}
