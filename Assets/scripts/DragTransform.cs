using System.Collections;
using UnityEngine;

public class DragTransform : MonoBehaviour
{
    public SnapController snapController;

    public Vector3 originalPosition;

    private bool isDragged = false;
    public bool isSnapped = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    private void Start()
    {
        originalPosition = gameObject.transform.localPosition;
        snapController = GameObject.Find("SnapController").GetComponent<SnapController>();
    }

    private void OnMouseDown()
    {
        isDragged = true;
        isSnapped = false;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
        snapController.OnDraggable(this);
    }
}
