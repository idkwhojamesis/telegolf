using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipCheck : MonoBehaviour
{
    // Use with ClipCollider on bullet to avoid teleporting out of bounds.
    public bool ClipRange = false;
    private void OnTriggerEnter(Collider other)
    {
        ClipRange = true;
        Debug.Log("ClipRange enter = " + ClipRange);
    }

    private void OnTriggerExit(Collider other)
    {
        ClipRange = false;
        Debug.Log("ClipRange exit = " + ClipRange);
    }
}
