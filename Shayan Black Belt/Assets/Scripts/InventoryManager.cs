using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public RawImage itemShow1;
    public RawImage itemShow2;
    public RawImage itemShow3;
    public GameObject holdingContainer;

    public GameObject[] toolbarPrefabs;
    private RawImage[] toolbarSlots;
    private GameObject currentClone;
    private int currentActiveSlot = -1;

    void Start()
    {
        toolbarSlots = new RawImage[] { itemShow1, itemShow2, itemShow3 };

        foreach (RawImage slot in toolbarSlots)
        {
            ClearSlot(slot);
        }

        if (holdingContainer == null)
        {
            Debug.LogError("put holding in inspector", this);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) HandleNumberInput(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) HandleNumberInput(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) HandleNumberInput(2);
    }

    public bool AddItem(GameObject itemPrefab, Texture itemIcon)
    {
        for (int i = 0; i < toolbarSlots.Length; i++)
        {
            if (toolbarPrefabs[i] == null)
            {
                toolbarPrefabs[i] = itemPrefab;
                toolbarSlots[i].texture = itemIcon;
                toolbarSlots[i].color = new Color(1f, 1f, 1f, 1f);
                return true;
            }
        }
        Debug.Log("toolbar full");
        return false;
    }

    private void ClearSlot(RawImage slot)
    {
        slot.texture = null;
        slot.color = new Color(0f, 0f, 0f, 0f);
    }

    private void HandleNumberInput(int slotIndex)
    {
        if (holdingContainer == null) return;

        if (currentActiveSlot == slotIndex)
        {
            ClearHolding();
            return;
        }

        ClearHolding();

        if (slotIndex >= 0 && slotIndex < toolbarPrefabs.Length && toolbarPrefabs[slotIndex] != null)
        {
            currentClone = Instantiate(toolbarPrefabs[slotIndex], holdingContainer.transform, false);
            currentClone.name = "Clone_Slot_" + slotIndex;
            Rigidbody rb = currentClone.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            Collider[] colliders = currentClone.GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                col.enabled = false;
            }
            Rigidbody2D rb2d = currentClone.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.isKinematic = true;
                rb2d.velocity = Vector2.zero;
                rb2d.angularVelocity = 0f;
            }

            Collider2D[] colliders2D = currentClone.GetComponentsInChildren<Collider2D>();
            foreach (Collider2D col2d in colliders2D)
            {
                col2d.enabled = false;
            }

            Transform cloneTransform = currentClone.transform;
            cloneTransform.localPosition = Vector3.zero;
            cloneTransform.localRotation = Quaternion.identity;

            cloneTransform.localScale = new Vector3(0.2518633f, 0.2518633f, 0.2518633f);

            RectTransform cloneRect = currentClone.GetComponent<RectTransform>();
            if (cloneRect != null)
            {
                cloneRect.offsetMin = Vector2.zero;
                cloneRect.offsetMax = Vector2.zero;
            }

            currentActiveSlot = slotIndex;
        }
    }

    private void ClearHolding()
    {
        if (currentClone != null)
        {
            Destroy(currentClone);
        }
        currentActiveSlot = -1;
    }
}
