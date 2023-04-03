using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Skill_2_Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private float _maxDisplacement;
    Vector2 startPos;
    Transform j_handle;

    public GameObject skill2_Button,
                      skill2_Range;

    public Image skill2_BG,
                 skill2_Joystick_,
                 skill2_Range_;

    public Skill_2_Spawn s2_Spawn;
    public Cancel_Button cancelButton;
    public bool isCancel = false;

    public static float Horizontal = 0,
                        Vertical = 0;
            

    void Start()
    {
        skill2_BG = GetComponent<Image>();
        skill2_Joystick_ = GameObject.Find("Joystick - Skill 2").GetComponent<Image>();
        skill2_Range_ = skill2_Range.GetComponent<Image>();

        var Col = skill2_BG.color;
        Col.a = 0;
        skill2_BG.color = Col;
        skill2_Joystick_.color = Col;
        skill2_Range_.color = Col;

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
        skill2_Button.SetActive(false);
        cancelButton.enableCancel();
        isCancel = false;

        var Col = skill2_BG.color;
        Col.a = 1;
        skill2_BG.color = Col;
        skill2_Joystick_.color = Col;
        skill2_Range_.color = Col;

        s2_Spawn.Skill_2_Start();

        UpdateJoystickHandlePosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateJoystickHandlePosition(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var Col = skill2_BG.color;
        Col.a = 0;
        skill2_BG.color = Col;
        skill2_Joystick_.color = Col;
        skill2_Range_.color = Col;

        if(isCancel == false)
        {
            s2_Spawn.Spawn_Skill_2();
            s2_Spawn.Skill_2_Finish();

        }

        cancelButton.disableCancel();
        skill2_Button.SetActive(true);
    }

    public void Skill_2_Ended()
    {
        var Col = skill2_BG.color;
        Col.a = 0;
        skill2_BG.color = Col;
        skill2_Joystick_.color = Col;
        skill2_Range_.color = Col;

        s2_Spawn.Skill_2_Finish();
        skill2_Button.SetActive(true);
    }

    
}
