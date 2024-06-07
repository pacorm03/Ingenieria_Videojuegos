using UnityEngine;

public class addMeshColliders : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Script iniciado, a�adiendo MeshColliders...");

        // A�adir MeshCollider al objeto padre si tiene un MeshFilter
        if (transform.GetComponent<MeshFilter>() != null && transform.GetComponent<MeshCollider>() == null)
        {
            transform.gameObject.AddComponent<MeshCollider>();
            Debug.Log("MeshCollider a�adido al objeto padre: " + transform.name);
        }

        // A�adir MeshColliders a todos los hijos
        AddMeshCollidersToChildren(transform);
    }

    void AddMeshCollidersToChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Debug.Log("Revisando: " + child.name);

            if (child.GetComponent<MeshFilter>() != null && child.GetComponent<MeshCollider>() == null)
            {
                child.gameObject.AddComponent<MeshCollider>();
                Debug.Log("MeshCollider a�adido a " + child.name);
            }

            // Recursivamente a�adir MeshColliders a todos los hijos
            AddMeshCollidersToChildren(child);
        }
    }
}
