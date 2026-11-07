
using UnityEngine;

public class PowerupCanvasToggle : MonoBehaviour
{
    public GameObject PowerupCanvas;
    private bool isOpen = false;

    void Start()
    {
        if (PowerupCanvas != null)
        {
            PowerupCanvas.SetActive(false);
        }

        SetCursorState(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOpen = !isOpen;

            PowerupCanvas.SetActive(isOpen);
            SetCursorState(isOpen);

            Debug.Log("Canvas is " + (isOpen ? "open" : "closed"));
        }
    }

    void SetCursorState(bool unlocked)
    {
        if (unlocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
