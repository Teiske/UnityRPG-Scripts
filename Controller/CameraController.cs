using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    public float pitch = 2f;
    public float yawSpeed = 100f;

    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    private float currentZoom = 10f;
    private float currentYaw = 0f;

    void Update() {
        //Zoom the camera in or out on the player
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        //Debug.Log(currentZoom);

        //Rotate the camera around the player
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        //Debug.Log(currentYaw);
    }

    void LateUpdate() {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
