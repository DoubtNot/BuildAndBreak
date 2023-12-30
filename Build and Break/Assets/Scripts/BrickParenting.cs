using UnityEngine;

public class BrickParenting : MonoBehaviour
{
    public GameObject parentCube;

    // Components to disable on the targetObject
    public Behaviour[] componentsToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {

            // Set the entering object as a child of the specified parentCube
            parentCube.transform.parent = other.transform;

            Rigidbody parentRigidbody = parentCube.GetComponent<Rigidbody>();

            parentRigidbody.isKinematic = true;

            BoxCollider boxCollider = parentCube.GetComponent<BoxCollider>();
                            
            boxCollider.enabled = true;

            DisableComponents();

            Destroy(this.gameObject,1);
        }
    }

    private void DisableComponents()
    {
        // Disable each component in the componentsToDisable array
        foreach (var component in componentsToDisable)
        {
            component.enabled = false;
        }
    }
}
