using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderAnim : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public static event Action SliderMoved;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = transform.localPosition;
        transform.localPosition = new Vector3(Math.Clamp(position.x + eventData.delta.x, -32, 32), position.y, position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 position = transform.localPosition;
        if (position.x < 32 && position.x > -32)
        {
            transform.localPosition = new Vector3(-32, position.y, position.z);
            return;
        }

        SliderMoved?.Invoke();
    }
}
