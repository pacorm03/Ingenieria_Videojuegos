using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;

    public float shotForce= 1500;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time > shotRateTime)
            {
                //GameObject newBullet;
                //newBullet = Instanaciate(bullet,spawnPoint.position, spawnPoint.rotation);
                GameObject bullet = BulletPool.Instance.bulletCall();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                shotRateTime = Time.time + shotRate;

                

            }

        }
        
    }

  
}
