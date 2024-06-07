// AbejaFlyweight.cs
using UnityEngine;

    public class AbejaFlyweight : IAbejaFlyweight
    {
        private AbejaData data;

        public AbejaFlyweight(AbejaData data)
        {
            this.data = data;
        }

        public void Operar(Vector3 posicion, float velocidad)
        {
            // Instancia el modelo 3D en la posición dada y ajusta su velocidad
            if (data.modelo3D != null)
            {
                GameObject abejaInstancia = GameObject.Instantiate(data.modelo3D, posicion, Quaternion.identity);
                // Suponiendo que el modelo tiene un componente que maneja el movimiento, podemos pasarle la velocidad
                MovimientoAbeja movimiento = abejaInstancia.GetComponent<MovimientoAbeja>();
                if (movimiento != null)
                {
                    movimiento.SetVelocidad(velocidad);
                }
            }
            else
            {
                Debug.LogWarning("El modelo 3D de la abeja no está asignado.");
            }
        }
    }
