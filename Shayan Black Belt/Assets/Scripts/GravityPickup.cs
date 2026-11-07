using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GravityPickup : MonoBehaviour
{
    public float maxRange = 5.0f;
    public LayerMask pickupLayer;
    public Transform itemHold;
    public float moveSpeed = 10f;

    private Rigidbody heldRigidbody;
    private bool isHolding = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickup();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Drop();
        }
    }

    private void FixedUpdate()
    {
        if (isHolding && heldRigidbody != null)
        {
            Vector3 targetPosition = itemHold.position;

            Vector3 newPosition = Vector3.Lerp(heldRigidbody.position, targetPosition, Time.fixedDeltaTime * moveSpeed);
            heldRigidbody.MovePosition(newPosition);
        }
    }

    private void TryPickup()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRange, pickupLayer))
        {
            heldRigidbody = hit.collider.GetComponent<Rigidbody>();

            if (heldRigidbody != null)
            {
                isHolding = true;
                heldRigidbody.useGravity = false;
                heldRigidbody.isKinematic = false;
                heldRigidbody.freezeRotation = true;
            }
        }
    }

    private void Drop()
    {
        if (isHolding)
        {
            if (heldRigidbody != null)
            {
                heldRigidbody.useGravity = true;
            }

            heldRigidbody.freezeRotation = false;
            heldRigidbody = null;
            isHolding = false;
        }
    }
}
