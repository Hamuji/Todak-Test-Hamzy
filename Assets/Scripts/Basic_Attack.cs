using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Attack : MonoBehaviour
{
    public GameObject projectile;
    
    public void Spawn_Basic_Attack()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
