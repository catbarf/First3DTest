using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class spectatorcamera : MonoBehaviour
{
    [Range(0.1f, 8f)]
    public float moveSpeed = 8f;

    [Range(0.01f, 100)]
    public float sensitivity = 1f;

    private Camera cam;

    [Range(5f, 60f)]
    public float zoomedInFov = 25f;
    private float defaultFov;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        defaultFov = cam.fieldOfView;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = zoomedInFov;
        }
        if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = defaultFov;
        }

        transform.position +=
            transform.forward * moveSpeed *
            Time.deltaTime * Input.GetAxis("Vertical");

        transform.position +=
            transform.up * moveSpeed *
            Time.deltaTime * Input.GetAxis("Lift");

        transform.position +=
            transform.right * moveSpeed *
            Time.deltaTime * Input.GetAxis("Horizontal");

        transform.Rotate(
            Vector3.up * sensitivity * Input.GetAxis("Mouse X"), Space.World);

        transform.Rotate(
            Vector3.right * sensitivity * -Input.GetAxis("Mouse Y"), Space.Self);
    }
}