using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnPoint; // El punto de generación de las balas
    public float shotForce = 500f; // Reducir la fuerza de disparo para hacer que las balas se muevan más lentamente
    public float shotRate = 0.5f; // La tasa de disparo

    private float shotRateTime = 0f; // Tiempo entre disparos
    private Camera mainCamera; // Referencia a la cámara principal

    void Start()
    {
        mainCamera = Camera.main; // Inicializa la cámara principal
    }

    void Update()
    {
        AimAtMouse(); // Apunta hacia el ratón

        if (Input.GetButtonDown("Fire1") && Time.time > shotRateTime)
        {
            Shoot(); // Dispara
            shotRateTime = Time.time + shotRate; // Actualiza el tiempo de disparo
        }
    }

    void AimAtMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // Proyecta un rayo desde la cámara hacia la posición del ratón
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 targetPosition = hitInfo.point; // La posición donde el rayo colisiona con un objeto
            Vector3 direction = targetPosition - spawnPoint.position; // Calcula la dirección desde el punto de generación hacia el objetivo
            direction.y = 0; // Opcional: Mantén la dirección en un plano horizontal
            spawnPoint.forward = direction; // Ajusta la orientación del punto de generación
        }
    }

    void Shoot()
    {
        GameObject bullet = BulletPool.Instance.bulletCall(); // Obtén una bala del pool
        if (bullet != null)
        {
            bullet.transform.position = spawnPoint.position; // Posiciona la bala en el punto de generación
            bullet.transform.rotation = spawnPoint.rotation; // Alinea la rotación de la bala con la del punto de generación
            bullet.SetActive(true); // Activa la bala
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = spawnPoint.forward * shotForce * Time.fixedDeltaTime; // Asigna una velocidad constante a la bala

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.ResetLifeTimer(); // Reinicia el temporizador de vida
        }
    }
}
