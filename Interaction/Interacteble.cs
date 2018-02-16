using UnityEngine;

public class Interacteble : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    bool hasInterracted = false;

    Transform player;

    public virtual void Interact() {
        Debug.Log("Interacting with " + transform.name);
    }

    void Update() {
        if (isFocus && !hasInterracted) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius) {
                Interact();
                hasInterracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
        hasInterracted = false;
    }

    public void OnDefocused() {
        isFocus = false;
        player = null;
        hasInterracted = false;
    }

    void OnDrawGizmosSelected() {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
