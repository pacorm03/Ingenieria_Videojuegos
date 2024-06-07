using UnityEngine;

public class addMeshColliders : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Script iniciado, añadiendo MeshColliders...");

        // Añadir MeshCollider al objeto padre si tiene un MeshFilter
        if (transform.GetComponent<MeshFilter>() != null && transform.GetComponent<MeshCollider>() == null)
        {
            transform.gameObject.AddComponent<MeshCollider>();
            Debug.Log("MeshCollider añadido al objeto padre: " + transform.name);
        }

        // Añadir MeshColliders a todos los hijos
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
                Debug.Log("MeshCollider añadido a " + child.name);
            }

            // Recursivamente añadir MeshColliders a todos los hijos
            AddMeshCollidersToChildren(child);
        }
    }
}
