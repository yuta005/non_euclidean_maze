using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleporter : MonoBehaviour {

    public Transform player;
    public Transform reciever;

    private bool playerIsOverlapping = false;
    private bool rotateFlag = false;

    // Update is called once per frame
    void Update () {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {
                // Teleport him!
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);
                if (SceneManager.GetActiveScene().name == "Portal1")
                {
                    rotateFlag = true;
                }


                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }

        }

        /*if (rotateFlag)
        {
            if (Mathf.Abs(reciever.rotation.x - player.rotation.x) > 0.1)
            {
                player.Rotate(new Vector3(90f, 0f, 0f));
                if (Mathf.Abs(reciever.rotation.z - player.rotation.z) > 0.1) player.Rotate(new Vector3(0f, 0f, 90f));
            }
            else
            {
                if (Mathf.Abs(reciever.rotation.z - player.rotation.z) > 0.1) player.Rotate(new Vector3(0f, 0f, 90f));
                else
                {
                    Physics.gravity = -Physics.gravity;
                    rotateFlag = false;
                }
            }
        }*/
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
