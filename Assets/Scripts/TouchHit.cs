using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHit : MonoBehaviour
{
    private void OnEnable()
    {
        TouchManager.Instance.touchStartEvent += Touch;
    }

    private void OnDisable()
    {
        TouchManager.Instance.touchStartEvent -= Touch;
    }

    private void Touch(Vector2 position)
    {
        Debug.Log(position);

        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if (raycastHit.collider.gameObject == gameObject)
            {
                Debug.Log("Bruh");
                GetComponent<SpriteRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}