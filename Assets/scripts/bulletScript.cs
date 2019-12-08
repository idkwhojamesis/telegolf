using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    void Start()
    {
        Collider player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
        Physics.IgnoreCollision(GetComponent<Collider>(), player, true);
        Physics.IgnoreCollision(player, GetComponent<Collider>(), true);
    }
}
