using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MouseLookSpeed = 3, verticalMouseLimit = 15f, MvmtSpeed = 0.1f;
    private Vector2 mouseRotation = Vector2.zero;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RotateView();
        //MovePlayer();
    }

    private void MovePlayer()
    {
        float moveVertical = Input.GetAxis("Vertical") * MvmtSpeed;
        float moveHorizontal = Input.GetAxis("Horizontal") * MvmtSpeed;

        transform.Translate(moveHorizontal, 0, moveVertical);
    }

    private void RotateView()
    {
        mouseRotation.y += Input.GetAxis("Mouse X");
        mouseRotation.x += Input.GetAxis("Mouse Y");
        mouseRotation.x = Mathf.Clamp(mouseRotation.x, (verticalMouseLimit * -1), verticalMouseLimit);

        transform.eulerAngles = new Vector2(0, mouseRotation.y) * MouseLookSpeed;
        cam.transform.localRotation = Quaternion.Euler(mouseRotation.x * MouseLookSpeed * -1, 0, 0);
    }
}
