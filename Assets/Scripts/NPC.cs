using UnityEngine;

/// <summary>
/// Controlador de NPC que activa diferentes tipos de paneles de ejercicio al colisionar con el jugador.
/// También desactiva el movimiento del jugador mientras un panel está activo.
/// </summary>
public class NPC : MonoBehaviour
{
    /// <summary>
    /// Tipos de ejercicios que el NPC puede activar.
    /// </summary>
    public enum TipoEjercicio { VyF, Seleccion, Completar }

    /// <summary>
    /// Tipo de ejercicio asignado a este NPC.
    /// </summary>
    public TipoEjercicio tipo;

    /// <summary>
    /// Panel para el ejercicio de Verdadero y Falso.
    /// </summary>
    public GameObject panelvyf;

    /// <summary>
    /// Panel para el ejercicio de Selección.
    /// </summary>
    public GameObject panelseleccion;

    /// <summary>
    /// Panel para el ejercicio de Completar.
    /// </summary>
    public GameObject panelcompletar;

    /// <summary>
    /// Bandera que indica si el NPC ya ha sido activado.
    /// </summary>
    private bool activado = false;

    /// <summary>
    /// Referencia al jugador que ha activado el NPC.
    /// </summary>
    private GameObject jugador;

    /// <summary>
    /// Se ejecuta cuando otro collider entra en la zona de colisión del NPC.
    /// Si el objeto es el jugador y aún no se ha activado, se muestra el panel correspondiente y se desactiva el movimiento del jugador.
    /// </summary>
    /// <param name="other">Collider del objeto que entra en contacto con el NPC.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!activado && other.CompareTag("Player"))
        {
            activado = true;

            jugador = other.gameObject;
            jugador.GetComponent<Movimiento>().enabled = false;

            switch (tipo)
            {
                case TipoEjercicio.VyF:
                    panelvyf.SetActive(true);
                    break;

                case TipoEjercicio.Seleccion:
                    panelseleccion.SetActive(true);
                    break;

                case TipoEjercicio.Completar:
                    panelcompletar.SetActive(true);
                    break;
            }
        }
    }

    /// <summary>
    /// Cierra el panel activo y reactiva el movimiento del jugador.
    /// Este método puede ser llamado por botones en los paneles.
    /// </summary>
    public void CerrarPanel()
    {
        jugador.GetComponent<Movimiento>().enabled = true;
    }
}

