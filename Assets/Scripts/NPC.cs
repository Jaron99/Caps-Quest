using UnityEngine;
using UnityEngine.UI;

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
    /// Panel principal que se muestra al jugador.
    /// </summary>
    public GameObject MainPanel;

    /// <summary>
    /// Referencia al joystick virtual utilizado para el control del jugador.
    /// </summary>
    public Joystick joystick;

    /// <summary>
    /// Bandera que indica si el NPC ya ha sido activado para evitar múltiples activaciones.
    /// </summary>
    private bool activado = false;

    /// <summary>
    /// Referencia al objeto jugador que ha activado este NPC.
    /// </summary>
    private GameObject jugador;

    /// <summary>
    /// Se ejecuta cuando otro collider entra en la zona de colisión del NPC.
    /// Si el objeto es el jugador y aún no se ha activado, se muestra el panel correspondiente
    /// y se desactiva el movimiento del jugador.
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

            MainPanel.SetActive(false);
            joystick.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Activa nuevamente el movimiento del jugador cuando se cierra el panel de ejercicio.
    /// También vuelve a mostrar el panel principal y el joystick virtual.
    /// </summary>
    public void ActivarMovimiento()
    {
        jugador.GetComponent<Movimiento>().enabled = true;
        MainPanel.SetActive(true);
        joystick.gameObject.SetActive(true);
    }
}
