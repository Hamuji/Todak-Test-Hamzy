using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1_Spawner : MonoBehaviour
{
    public GameObject projectile,
                      skill1,
                      player;

    public float h,
                 v;

    public void skill1_Start()
    {
        skill1 = Instantiate(projectile, transform.position, transform.rotation);
    }

    public void Phase2nd()
    {
        player.transform.position = new Vector3(h, 1, v);
        Destroy(skill1);
    }
}
