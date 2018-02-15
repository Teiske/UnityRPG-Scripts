using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;

    public Interacteble focus;

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
                RemoveFocus();

            }
        }

        if (Input.GetMouseButton(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                Debug.Log("We Hit " + hit.collider.name + " " + hit.point);
                //Check if we hit an interactble
                Interacteble interacteble = hit.collider.GetComponent<Interacteble>();
                //If we did, set it as our focus
                if (interacteble != null) {
                    SetFocus(interacteble);
                }
            }
        }
    }

    void SetFocus(Interacteble newFocus) {
        if (newFocus != focus) {
            if (focus != null) {
                focus.OnDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus() {
        if (focus != null) {
            focus.OnDefocused();
        }
        focus = null;
        motor.StopFollowingTarget();
    }
}
