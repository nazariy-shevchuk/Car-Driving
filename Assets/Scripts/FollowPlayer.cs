using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;
    public Camera backCamera;
    private Vector3 offset = new Vector3(0, 5, -7);
    private Vector3 offsetback = new Vector3(0, 5, 7);

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        backCamera.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's position
        mainCamera.transform.position = player.transform.position + offset;
        backCamera.transform.position = player.transform.position + offsetback;

        // Switch camera view while C key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCamera.enabled = !mainCamera.enabled;
            backCamera.enabled = !backCamera.enabled;
        }
    }
}
