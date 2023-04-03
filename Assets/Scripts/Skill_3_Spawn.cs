using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_3_Spawn : MonoBehaviour
{
    public GameObject ultimate,
                      player;
    public void Spawn_Ultimate()
    {
        GameObject Ultimate = Instantiate(ultimate, transform.position, Quaternion.identity, player.transform);
        Destroy(Ultimate, 4);
    }
}
