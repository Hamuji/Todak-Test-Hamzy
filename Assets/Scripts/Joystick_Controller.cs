using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick_Controller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private float _maxDisplacement;
    Vector2 startPos;
    Transform j_handle;

    public GameObject indicator_Rotation;

    public static float Horizontal = 0,
                        Vertical = 0;

    void Start()
    {
        indicator_Rotation.SetActive(false);
        j_handle = transform.GetChild(0);
        startPos = j_handle.position;
    }

    void UpdateJoystickHandlePosition(Vector2 position)
    {
        var delta = position - startPos;
        delta = Vector2.ClampMagnitude(delta, _maxDisplacement);
        j_handle.position = startPos + delta;
        Horizontal = delta.x;
        Vertical = delta.y;
    }

    // Input when joystick is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        indicator_Rotation.SetActive(true);
        UpdateJoystickHandlePosition(eventData.position);
    }

    // Input when dragging the joystick
    public void OnDrag(PointerEventData eventData)
    {
        UpdateJoystickHandlePosition(eventData.position);
    }

    // When the joystick is released
    public void OnPointerUp(PointerEventData eventData)
    {
        indicator_Rotation.SetActive(false);
        UpdateJoystickHandlePosition(startPos);
    }

}
