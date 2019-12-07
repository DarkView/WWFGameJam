using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Camera mainCamera;
    public Rigidbody playerPhysics;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerLookAtMouse();
        HandleShootInput();

        mainCamera.transform.position = GameObject.Find("CamHolder").transform.position;
        mainCamera.transform.rotation = GameObject.Find("CamHolder").transform.rotation;


    }
    void PlayerLookAtMouse()
    {
        //Generiert eine Line von der Kammera zur Position der Maus
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        //Der Spieler schaut auf die oben generierte Line
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            this.transform.LookAt(new Vector3(pointToLook.x, this.playerPhysics.transform.position.y, pointToLook.z));
        }
    }
    void HandleShootInput()
    {
        if (Input.GetButton("Fire1"))
        {
            GameObject.Find("Weapon").GetComponent<Weapon>().Shoot();
        }
    }

}
