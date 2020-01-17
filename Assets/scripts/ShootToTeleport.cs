using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToTeleport : MonoBehaviour
{
    public GameObject bullet;
    public GameObject club;
    public GameObject prism;
    public float bulletUp = .5f, bulletFwd = .75f, bulletSp = 20f;
    Camera cam;
    private GameObject nb;
    ClipCheck clip;
    bool clipRange;

    public Color Color1 = Color.green;
    public Color Color2 = Color.blue;
    public float LerpRate = 100f, ppRate = 10f;
    Renderer rend;
    Renderer pRend;
    Animator pAnim;

    private int downTime = 0;
    private bool held = false, released = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = Camera.main;
        pRend = prism.GetComponent<Renderer>();
        pAnim = club.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Input detection moved to Update()
        if (held)
        {
            downTime++;
            if (downTime > 30)
            {
                float pp = Mathf.PingPong(Time.time * ppRate, 1);
                bulletSp = Mathf.Lerp(1, 40, pp);
                pRend.material.color = Color.Lerp(Color1, Color2, pp);
            }
            held = false;
        }
        if (released)
        {
            // Destroy previous bullets
            if (GameObject.FindGameObjectsWithTag("bullets").Length > 0)
            {
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullets");
                for (int i = 0; i < bullets.Length; i++)
                {
                    Destroy(bullets[i]);
                }
            }
            Debug.Log("Lmouse");
            pAnim.Play("swing", 0, 0f);
            Shoot();
            clip = nb.GetComponentInChildren<ClipCheck>();
            rend = nb.GetComponentInChildren<Renderer>();
            downTime = 0;
        }
        released = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) held = true;
        else if (Input.GetMouseButtonUp(0)) released = true;
        // Teleport on rightclick
        if (nb && Input.GetMouseButtonDown(1) && clipRange == false)
        {
            Debug.Log("Rmouse + nb exists");
            // If ball safe from clipping out player
            Vector3 nbTF = nb.transform.position;
            //GetComponent<Rigidbody>().MovePosition(nbTF);
            transform.position = nbTF;
        }
        if (nb && Input.GetMouseButton(0) == false)
        {
            clipRange = clip.ClipRange;
            // Get distance and lerp color over certain distance
            Vector3 pos1 = transform.position;
            Vector3 pos2 = nb.transform.position;
            float dist = Vector3.Distance(pos1, pos2);
            if (clipRange == false)
            {
                rend.material.color = Color.Lerp(Color1, Color2, (dist / LerpRate));
            }
            else
            {
                rend.material.color = Color.red;
            }
            // Set prism color to ball color
            pRend.material.color = rend.material.color;
            // Debug.Log(dist);
        }
    }

    private void Shoot()
    {
        nb = (GameObject)Instantiate(bullet, transform.position + bulletFwd * transform.forward + bulletUp * transform.up, transform.rotation);
        nb.GetComponentInChildren<Rigidbody>().velocity = cam.transform.forward * bulletSp;
    }
}
