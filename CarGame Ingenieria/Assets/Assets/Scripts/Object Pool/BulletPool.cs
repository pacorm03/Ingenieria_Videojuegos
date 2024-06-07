using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 20; //numero de objetos en el objectpool
    [SerializeField] private List<GameObject> bulletsList; //lista de objetos del object pull

    private static BulletPool instance;
    public static BulletPool Instance { get { return instance; } } // con el patron singleton hacemos que 
    //solo tengamos una unica instancia de bulletpool y nos permite acceder más fácilmente a sus metodos
    // y campos desde otros scripts

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        //Añado los lasers al pool
        AddBulletsToPool(poolSize);
    }

    private void AddBulletsToPool(int size)
    {
        //primero vamos a instanciar todos los games objects del pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletsList.Add(bullet);
            bullet.transform.parent = transform;
            //al principio todas las instancias estan inactivas
        }
    }

    public GameObject bulletCall()
    {
        //cuando le pulsamos al boton disparar si hay balas inactivas en la lista de balas ( es decir
        //si hay balas que no se esten usando), se activa una.

        for (int i= 0; i < bulletsList.Count; i++)
        {
            if (!bulletsList[i].activeSelf)
            {
                bulletsList[i].SetActive(true);
                return bulletsList[i];
            }
        }
        return null;

    }
    

    
}
