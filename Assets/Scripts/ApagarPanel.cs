using UnityEngine;

/// <summary>
/// Clase responsable de desactivar el panel actual después de un retraso determinado.
/// </summary>
public class ApagarPanel : MonoBehaviour
{
    /// <summary>
    /// Tiempo de espera antes de ocultar el panel (en segundos).
    /// </summary>
    private float delay = 4f;

    /// <summary>
    /// Método llamado automáticamente cuando el objeto se activa.
    /// Inicia una invocación para ocultar el panel después del tiempo especificado.
    /// </summary>
    void OnEnable()
    {
        Invoke("HidePanel", delay);
    }

    /// <summary>
    /// Oculta el panel desactivando el GameObject asociado.
    /// </summary>
    void HidePanel()
    {
        gameObject.SetActive(false);
    }
}

