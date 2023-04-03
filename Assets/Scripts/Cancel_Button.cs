using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cancel_Button : MonoBehaviour, IPointerEnterHandler
{
    public Skill_1_Joystick s1_Joystick;
    public Skill_2_Joystick s2_Joystick;
    public Skill_3_Button s3_Button;
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void enableCancel()
    {
        gameObject.SetActive(true);
    }
    public void disableCancel()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        s1_Joystick.isCancel = true;
        s2_Joystick.isCancel = true;
        s3_Button.isCancel = true;
        s1_Joystick.skill1_End();
        s2_Joystick.Skill_2_Ended();
        s3_Button.Cancel_Skill_3();
        gameObject.SetActive(false);
    }
}
