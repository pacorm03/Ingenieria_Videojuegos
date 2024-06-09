using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeTime = 2f; // Duración de vida de la bala en segundos
    private Coroutine lifeTimerCoroutine;

    private void OnEnable()
    {
        ResetLifeTimer(); // Reinicia el temporizador cuando se activa la bala
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with " + collision.gameObject.name);
        gameObject.SetActive(false); // Desactiva la bala al colisionar
    }

    public void ResetLifeTimer()
    {
        if (lifeTimerCoroutine != null)
        {
            StopCoroutine(lifeTimerCoroutine); // Detén el temporizador anterior si existe
        }
        lifeTimerCoroutine = StartCoroutine(LifeTimer()); // Inicia un nuevo temporizador
    }

    private IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime); // Espera el tiempo de vida
        gameObject.SetActive(false); // Desactiva la bala después del tiempo de vida
    }
}
