using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject itemPrefab;
    private CanvasGroup canvasGroup;
    private GameObject itemClone;
    private Rigidbody2D itemRigidbody;
    private Collider2D itemCollider;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        itemClone = Instantiate(itemPrefab, transform.position, transform.rotation);
        itemRigidbody = itemClone.GetComponent<Rigidbody2D>();
        itemCollider = itemClone.GetComponent<Collider2D>();
        if (itemRigidbody != null) itemRigidbody.simulated = false;
        if (itemCollider != null) itemCollider.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector3 screenPosition = eventData.position;
        screenPosition.z = 10; // Distance from the camera
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0; // Set z-value to 0
        itemClone.transform.position = worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (itemRigidbody != null) itemRigidbody.simulated = true;
        if (itemCollider != null) itemCollider.enabled = true;
    }
}