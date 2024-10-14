using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera playerCamera;
    public float distanceRaycast = 7;

    void Update()
    {
        playerCamera = Camera.main;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit, distanceRaycast) && hit.collider.CompareTag("Trigger"))
        {
            Debug.Log("Игрок смотрит на объект" + hit.collider.gameObject.name);
        }
    }
}
