﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Camera_Control : NetworkManager {

    [Header("Scene Camera Properties")]
    [SerializeField]
    Transform sceneCamera;
    [SerializeField] float cameraRotationRadius = 24f;
    [SerializeField]
    float cameraRotationSpeed = 3f;
    [SerializeField]
    bool canRotate = true;

    float rotation;

    public override void OnStartClient(NetworkClient client)
    {
        canRotate = false;
    }

    public override void OnStartHost()
    {
        canRotate = false;
    }

    public override void OnStopClient()
    {
        canRotate = true;
    }

    public override void OnStopHost()
    {
        canRotate = true;
    }
	// Update is called once per frame
	void Update () {
        if (canRotate)
        {
            rotation += cameraRotationSpeed * Time.deltaTime;
            if (rotation >= 360f)
            {
                rotation -= 360f;
            }
            sceneCamera.position = Vector3.zero;
            sceneCamera.rotation = Quaternion.Euler(0f, rotation, 0f);
            sceneCamera.Translate(0f, cameraRotationRadius, -cameraRotationRadius);
            sceneCamera.LookAt(Vector3.zero);
        }
        else
        {

        }
	}
}
