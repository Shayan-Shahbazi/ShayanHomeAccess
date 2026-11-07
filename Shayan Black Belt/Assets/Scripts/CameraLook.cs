using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float mouseSensitivity = 1000f;
    private float xRotation = 0f;
    public Transform player;
    public bool CLWork;

    void Start()
    {
        LockCursor();
    }

    private void FixedUpdate()
    {
        if (CLWork == true)
        {
            Look();
        }
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }

    public void FreeCursor()
    {
        CLWork = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LockCursor()
    {
        CLWork = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
