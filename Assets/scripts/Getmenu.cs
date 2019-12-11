using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getmenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject otherInput;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menu.activeSelf == false)
            {
                otherInput.SetActive(false);
                menu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                otherInput.SetActive(true);
                menu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
