using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text countdownText; // El texto de la UI para mostrar la cuenta atrás
    public GameObject playerCar; // El coche del jugador
    public GameObject temporizador; 

    private Controller playerController;

    void Start()
    {
        playerController = playerCar.GetComponent<Controller>();
        playerController.enabled = false; // Desactiva el control del coche al principio
        StartCoroutine(CountdownStart());
    }

    IEnumerator CountdownStart()
    {
        int countdown = 3; // Tiempo inicial de la cuenta atrás
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1);
            countdown--;
        }

        countdownText.text = "GO!";
        playerController.enabled = true; // Activa el control del coche
        temporizador.SetActive(true);

        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false); // Oculta el texto de la cuenta atrás

    }
}
