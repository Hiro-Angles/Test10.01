using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoovment : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float lookSpeed = 2f;
    private float rotation_x = 0f;
    private float rotation_y = 0f;

    void Start()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation_y = rotation.x;
    }

    void Update()
    {
        // ”правление мышью
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;
        rotation_x += mouseX;
        rotation_y = Mathf.Clamp(rotation_y, -90, 90);
        rotation_y -= mouseY;
        transform.localEulerAngles = new Vector3(rotation_y, rotation_x, 0);

        //transform.Rotate(Vector3.up, mouseX);
        //transform.Rotate(Vector3.left, mouseY);

        // ƒвижение
        float moveForward = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float moveRight = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float moveUp = 0;

        if (Input.GetKey(KeyCode.E)) moveUp = movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)) moveUp = -movementSpeed * Time.deltaTime;

        transform.Translate(new Vector3(moveRight, moveUp, moveForward));
    }
}