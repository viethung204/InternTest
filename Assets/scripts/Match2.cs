using System.Collections;
using System.Net;
using UnityEngine;

public class Match2 : MonoBehaviour
{
    public float rayDistance; // Distance the ray will cast
    public string targetObjectTag; // Name of the objects to detect and destroy

    public DragTransform dragTransform;

    public Point point;

    public GameObject coin;

    private void Start()
    {
        dragTransform = gameObject.GetComponent<DragTransform>();
        point = GameObject.Find("ScoreManager").GetComponent<Point>();
    }

    void Update()
    {
        CastRay(Vector2.up);
        CastRay(Vector2.down);
        CastRay(Vector2.left);
        CastRay(Vector2.right);
    }

    public void CastRay(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance);
        if (hit.collider != null && hit.collider.gameObject.tag == targetObjectTag && dragTransform.isSnapped == true)
        {
            DragTransform targetDT = hit.collider.gameObject.GetComponent<DragTransform>();
            if(dragTransform.isSnapped == true && targetDT.isSnapped == true)
            {
                Vector3 hitPosition = hit.collider.transform.position;
                Vector3 midpoint = (transform.position + hitPosition) / 2;
                StartCoroutine(WaitAndPerformAction());

                IEnumerator WaitAndPerformAction()
                {
                    

                    // Wait for 0.5 seconds
                    yield return new WaitForSeconds(0.15f);
                    point.hasIncremented = true;
                    Instantiate(coin, midpoint, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    Destroy(gameObject);
                }

            }
            else
            {
                return;
            }

        }
        
    }

}
