using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask)) {
                Debug.Log("We Hit " + hit.collider.name + " " + hit.point);

                //Move our player to what we hit
                motor.MoveToPoint(hit.point);
           
                //Stop focusing any objects

            }
        }

        if (Input.GetMouseButton(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask)) {
                Debug.Log("We Hit " + hit.collider.name + " " + hit.point);
                //Check if we hit an interactble
                //If we did, set it as our focus
            }
        }
    }
}
