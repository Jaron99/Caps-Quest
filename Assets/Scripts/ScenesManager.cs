using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Controlador de escenas que permite cargar distintas escenas según interacción del jugador
/// o mediante métodos públicos para ser utilizados desde la interfaz o botones.
/// </summary>
public class ScenesManager : MonoBehaviour
{
    /// <summary>
    /// Enum que define las escenas disponibles para ser cargadas.
    /// </summary>
    public enum escena { Forest, ArventisCity, ArventisCastle, Outro }

    /// <summary>
    /// Escena seleccionada para ser cargada automáticamente al entrar en el trigger.
    /// </summary>
    public escena nombreescena;

    /// <summary>
    /// Detecta si el jugador entra en el área de colisión del objeto.
    /// Si lo hace, carga la escena especificada en <c>nombreescena</c>.
    /// </summary>
    /// <param name="other">El collider que entra en contacto con el trigger.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nombreescena.ToString());
        }
    }

    /// <summary>
    /// Carga manualmente la escena del bosque ("Forest").
    /// </summary>
    public void EscenaBosque()
    {
        SceneManager.LoadScene("Forest");
    }

    /// <summary>
    /// Carga manualmente la escena de la ciudad ("ArventisCity").
    /// </summary>
    public void EscenaCuidad()
    {
        SceneManager.LoadScene("ArventisCity");
    }

    /// <summary>
    /// Carga manualmente la escena del castillo ("ArventisCastle").
    /// </summary>
    public void EscenaCastillo()
    {
        SceneManager.LoadScene("ArventisCastle");
    }
}

