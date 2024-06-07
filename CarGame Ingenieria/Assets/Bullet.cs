using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] private GameObject bulletPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with " + collision.gameObject.name);
        bulletPrefab.SetActive(false);
    }
}