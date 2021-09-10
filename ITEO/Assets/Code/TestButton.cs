using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestButton : MonoBehaviour, IPointerDownHandler
{
    public void OnMouseDown()
    {
        Debug.Log("Tap");
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
    }
}
