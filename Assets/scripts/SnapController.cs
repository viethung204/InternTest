using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public float SnapRadius = 0.5f;

    public void OnDraggable(DragTransform draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;


        foreach (Transform snap in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snap.localPosition);
            if(closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snap;
                closestDistance = currentDistance;
            }
        }

        if(closestSnapPoint != null && closestDistance <= SnapRadius)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
            draggable.isSnapped = true;
        }
        else
        {
            draggable.transform.localPosition = draggable.originalPosition;
            draggable.isSnapped = false;
        }
    }
}
