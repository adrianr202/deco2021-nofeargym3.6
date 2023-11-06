using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic; 

public class ObjectTriggerEvent : MonoBehaviour
{
    public List<GameObject> objectToActivate; // Reference to the game objects you want to activate

    private InputAction tapAction;

    private void OnEnable()
    {
        tapAction.Enable();
        tapAction.started += _ => HandleInput();
    }

    private void OnDisable()
    {
        tapAction.Disable();
        tapAction.started -= _ => HandleInput();
    }

    private void Awake()
    {
        tapAction = new InputAction(binding: "<Pointer>/press");
    }

    private void HandleInput()
    {
        // Debug.Log("Input Detected");

        // Create a ray from the camera through the touch position or mouse position
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        // Add a debug line to visualize the ray
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        RaycastHit hit;

        // Check if the ray hits this game object
        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            Debug.Log("Raycast hit object: " + hit.collider.gameObject.name);

            // The game object was tapped or clicked, activate the other game objects
            foreach (var obj in objectToActivate)
            {
                obj.SetActive(true);
            }
        }
    }
}
