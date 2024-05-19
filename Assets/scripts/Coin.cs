using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 2.0f;
    public float lifetime = 1.4f;

    void Start()
    {
        StartCoroutine(MoveUpAndDestroy());
    }

    IEnumerator MoveUpAndDestroy()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < lifetime)
        {
            
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
