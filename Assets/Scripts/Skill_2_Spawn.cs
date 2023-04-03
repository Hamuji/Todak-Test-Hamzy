using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2_Spawn : MonoBehaviour
{
    public GameObject skill_2_hit,
                      skill_2_spawn,
                      indicator,
                      skill_center;

    public Transform player;

    public float h,
                 v;

    public void Skill_2_Start()
    {
        indicator = Instantiate(skill_2_hit, transform.position, transform.rotation, skill_center.transform);
    }

    public void Skill_2_Finish()
    {
        Destroy(indicator);
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, 1, player.position.z);
    }

    public void Spawn_Skill_2()
    {
        Instantiate(skill_2_spawn, new Vector3(h, 2, v), Quaternion.identity);
    }
}
