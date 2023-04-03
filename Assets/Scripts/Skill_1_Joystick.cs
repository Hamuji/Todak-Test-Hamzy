using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Skill_1_Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private float _maxDisplacement;
    Vector2 startPos;
    Transform j_handle;

    public GameObject skill1_Button,
                      skill1_2ndPhase,
                      skill1,
                      skillRange,
                      skillDir;

    public Image skill1_Joystick,
                 skill1_JoystickBG,
                 skill1_Range,
                 skill1_Dir;

    public static float Horizontal = 0,
                        Vertical = 0;

    public Skill_1_Spawner skillSpawn;
    
    public Cancel_Button cancelButton;
    public bool isCancel = false;

    void Start()
    {
        skill1_Joystick = GetComponent<Image>();
        skill1_JoystickBG = skill1.GetComponent<Image>();
        skill1_Range = skillRange.GetComponent<Image>();
        skill1_Dir = skillDir.GetComponent<Image>();

        //Get alpha value for the Joystick image and set it to 0 (joystick hidden at start)
        var Col = skill1_Joystick.color;
        Col.a = 0;
        skill1_JoystickBG.color = Col;
        skill1_Range.color = Col;
        skill1_Joystick.color = Col;
        skill1_Dir.color = Col;

        skill1_2ndPhase.SetActive(false);

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
        var Col = skill1_Joystick.color;
        Col.a = 1;
        skill1_JoystickBG.color = Col;
        skill1_Range.color = Col;
        skill1_Joystick.color = Col;
        skill1_Dir.color = Col;

        cancelButton.enableCancel();
        isCancel = false;

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
        var Col = skill1_Joystick.color;
        Col.a = 0;
        skill1_JoystickBG.color = Col;
        skill1_Range.color = Col;
        skill1_Joystick.color = Col;
        skill1_Dir.color = Col;
        
        if(isCancel == false)
        {
            skill1_2ndPhase.SetActive(true);

            skillSpawn.skill1_Start();
            Invoke("skill1_End", 2);
        }
        else
        {
            Invoke("skill1_End", 0);
        }

        cancelButton.disableCancel();
        
        UpdateJoystickHandlePosition(startPos);
    }

    public void skill1_End()
    {
        var Col = skill1_Joystick.color;
        Col.a = 0;
        skill1_JoystickBG.color = Col;
        skill1_Range.color = Col;
        skill1_Joystick.color = Col;
        skill1_Dir.color = Col;

        CancelInvoke();
        skill1_2ndPhase.SetActive(false);
        skill1_Button.SetActive(true);
    }
}
