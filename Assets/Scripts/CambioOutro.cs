using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

/// <summary>
/// Clase que gestiona la transición automática a la escena del menú principal
/// después de que finaliza una secuencia tipo outro o créditos.
/// </summary>
public class CambioOutro : MonoBehaviour
{
    /// <summary>
    /// Método llamado al iniciar el script.
    /// Inicia una corrutina que espera un tiempo determinado antes de cambiar de escena.
    /// </summary>
    void Start()
    {
        StartCoroutine(Outro());
    }

    /// <summary>
    /// Corrutina que espera 65 segundos antes de cargar la escena del menú principal.
    /// </summary>
    /// <returns>Un enumerador que permite la espera asincrónica.</returns>
    IEnumerator Outro()
    {
        yield return new WaitForSeconds(65f);
        SceneManager.LoadScene("MainMenu");
    }
}

