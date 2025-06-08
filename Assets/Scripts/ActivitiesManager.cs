using UnityEngine;
using TMPro;
using System.Linq;

/// <summary>
/// Carga y muestra dinámicamente el texto de una actividad individual desde un archivo de texto.
/// Este script debe estar en un GameObject con un componente TextMeshProUGUI.
/// </summary>
public class TextoActividadIndividual : MonoBehaviour
{
    /// <summary>
    /// Componente de texto donde se mostrará el contenido de la actividad.
    /// </summary>
    private TextMeshProUGUI textoUI;

    [Header("Configuración de Actividad")]

    /// <summary>
    /// Número identificador de la actividad que se desea mostrar.
    /// Debe coincidir con la primera columna del archivo de texto.
    /// </summary>
    public string numeroActividad = "1";

    /// <summary>
    /// Índice del campo que se desea mostrar de la línea correspondiente.
    /// Por ejemplo, 0 = número, 1 = enunciado, 2 = opciones o respuesta.
    /// </summary>
    [Range(0, 2)] 
    public int indiceCampo = 0; 

    [Header("Configuración del Archivo Global")]

    /// <summary>
    /// Nombre del archivo dentro de la carpeta Resources (sin extensión).
    /// </summary>
    public string nombreArchivo = "Actividades";

    /// <summary>
    /// Carácter delimitador usado en el archivo de texto para separar campos.
    /// </summary>
    public char delimitador = '|';

    /// <summary>
    /// Inicializa el componente y carga el texto correspondiente a la actividad.
    /// </summary>
    void Awake()
    {
        textoUI = GetComponent<TextMeshProUGUI>();
        if (textoUI == null)
        {
            Debug.LogError($"El GameObject '{gameObject.name}' no tiene un componente TextMeshProUGUI (o Text) adjunto. Este script requiere uno.", this);
            enabled = false;
            return;
        }

        CargarTexto();
    }

    /// <summary>
    /// Carga el archivo de texto desde Resources y asigna el texto al campo UI
    /// según el número de actividad y el índice de campo especificado.
    /// </summary>
    public void CargarTexto()
    {
        TextAsset archivoActividades = Resources.Load<TextAsset>(nombreArchivo);

        if (archivoActividades != null)
        {
            string[] lineas = archivoActividades.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

            string lineaEncontrada = lineas.FirstOrDefault(linea =>
            {
                string trimmedLine = linea.Trim();
                if (string.IsNullOrEmpty(trimmedLine)) return false;

                string[] campos = trimmedLine.Split(delimitador);
                return campos.Length > 0 && campos[0].Trim() == numeroActividad;
            });

            if (!string.IsNullOrEmpty(lineaEncontrada))
            {
                string[] campos = lineaEncontrada.Trim().Split(delimitador);

                if (campos.Length > indiceCampo)
                {
                    string textoFinal = campos[indiceCampo].Trim();
                    if (indiceCampo == 0)
                    {
                        textoUI.text = $"Actividad {textoFinal}";
                    }
                    else
                    {
                        textoUI.text = textoFinal;
                    }
                }
                else
                {
                    Debug.LogWarning($"La línea de la actividad '{numeroActividad}' no tiene suficientes campos para el índice {indiceCampo}.", this);
                    textoUI.text = "ERROR: Campo no encontrado";
                }
            }
            else
            {
                Debug.LogWarning($"Actividad con número '{numeroActividad}' no encontrada en el archivo '{nombreArchivo}.txt'.", this);
                textoUI.text = "ERROR: Actividad no encontrada";
            }
        }
        else
        {
            Debug.LogError($"Archivo de actividades '{nombreArchivo}.txt' no encontrado en la carpeta Resources. Asegúrate de que está ahí y que el nombre es correcto (sin la extensión .txt).", this);
            textoUI.text = "ERROR: Archivo no encontrado";
        }
    }
}
