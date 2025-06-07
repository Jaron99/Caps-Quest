using UnityEngine;

/// <summary>
/// Clase que permite salir del juego cuando se presiona la tecla Escape,
/// tanto en plataformas de escritorio como en Android.
/// </summary>
public class Salida : MonoBehaviour
{
    /// <summary>
    /// Verifica cada frame si se presionó la tecla Escape.
    /// Si es así, llama al método para salir del juego.
    /// Funciona en escritorio y en dispositivos Android.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SalirJuego();
        }

        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            SalirJuego();
        }
    }

    /// <summary>
    /// Cierra la aplicación y muestra un mensaje en la consola (solo visible en el editor).
    /// </summary>
    void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo de la Aplicacion");
    }
}

