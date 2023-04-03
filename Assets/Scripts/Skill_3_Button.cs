using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skill_3_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Skill_3_Spawn s3_Spawn;
    public GameObject skillRange;

    public Cancel_Button cancelButton;
    public bool isCancel = false;
    void Start()
    {
        skillRange.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        skillRange.SetActive(true);
        cancelButton.enableCancel();
        isCancel = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        skillRange.SetActive(false);
        if (isCancel == false)
        {
            s3_Spawn.Spawn_Ultimate();
        }

        cancelButton.disableCancel();
    }

    public void Cancel_Skill_3()
    {
        skillRange.SetActive(false);
    }
}
