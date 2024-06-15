using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnPoint; // El punto de generaci�n de las balas
    public float shotForce = 10f; // Reducir la fuerza de disparo para hacer que las balas se muevan m�s lentamente
    public float shotRate = 0.5f; // La tasa de disparo

    private float shotRateTime = 0f; // Tiempo entre disparos
    private Camera mainCamera; // Referencia a la c�mara principal
    private Rigidbody carRigidbody; // Referencia al Rigidbody del coche

    void Start()
    {
        mainCamera = Camera.main; // Inicializa la c�mara principal
        carRigidbody = GetComponent<Rigidbody>(); // Obt�n el Rigidbody del coche
    }

    void Update()
    {
        AimAtMouse(); // Apunta hacia el rat�n

        if (Input.GetButtonDown("Fire1") && Time.time > shotRateTime)
        {
            Shoot(); // Dispara
            shotRateTime = Time.time + shotRate; // Actualiza el tiempo de disparo
        }
    }

    void AimAtMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // Proyecta un rayo desde la c�mara hacia la posici�n del rat�n
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 targetPosition = hitInfo.point; // La posici�n donde el rayo colisiona con un objeto
            Vector3 direction = targetPosition - spawnPoint.position; // Calcula la direcci�n desde el punto de generaci�n hacia el objetivo
            direction.y = 0; // Opcional: Mant�n la direcci�n en un plano horizontal
            // Ajusta la direcci�n para tener en cuenta la velocidad del coche
            direction += carRigidbody.velocity * (direction.magnitude / shotForce);

            spawnPoint.forward = direction.normalized; // Normaliza y ajusta la orientaci�n del punto de generaci�n
        }
    }
    

    void Shoot()
    {
        GameObject bullet = BulletPool.Instance.bulletCall(); // Obt�n una bala del pool
        if (bullet != null)
        {
            bullet.transform.position = spawnPoint.position; // Posiciona la bala en el punto de generaci�n
            bullet.transform.rotation = spawnPoint.rotation; // Alinea la rotaci�n de la bala con la del punto de generaci�n
            bullet.SetActive(true); // Activa la bala
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            // Ajusta la velocidad de la bala seg�n la velocidad del coche y la fuerza de disparo
             rb.velocity = spawnPoint.forward * (carRigidbody.velocity.magnitude + shotForce) * Time.fixedDeltaTime;
      

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.ResetLifeTimer(); // Reinicia el temporizador de vida
        }
    }
}
