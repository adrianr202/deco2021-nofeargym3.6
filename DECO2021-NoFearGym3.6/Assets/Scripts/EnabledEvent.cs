using UnityEngine;

public class EnabledEvent : MonoBehaviour
{
    public GameObject targetGameObject; // Reference to the GameObject you want to activate/deactivate

    public void ToggleGameObject()
{
    Debug.Log("ToggleGameObject called");
    if (targetGameObject != null)
    {
        Debug.Log("Target GameObject active state: " + targetGameObject.activeSelf);
        targetGameObject.SetActive(!targetGameObject.activeSelf);
        Debug.Log("New active state: " + targetGameObject.activeSelf);
    }
}

}
