using UnityEngine;

/// <summary>
/// Controla el movimiento de un objeto 2D utilizando entrada del jugador 
/// tanto por teclado como por joystick, y aplicando movimiento mediante Rigidbody2D.
/// También actualiza parámetros del Animator para controlar animaciones.
/// </summary>
public class Movimiento : MonoBehaviour
{
    /// <summary>
    /// Velocidad de movimiento del objeto.
    /// </summary>
    [SerializeField] private float velocidadMov;

    /// <summary>
    /// Dirección actual del movimiento, calculada a partir de la entrada del jugador.
    /// </summary>
    [SerializeField] private Vector2 direccion;

    /// <summary>
    /// Referencia al componente Rigidbody2D del objeto.
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Referencia al componente Animator del objeto para controlar animaciones.
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Referencia al joystick utilizado para controlar el movimiento (opcional).
    /// Puede ser FixedJoystick, FloatingJoystick o Joystick según el tipo usado.
    /// </summary>
    public Joystick joystick;

    /// <summary>
    /// Inicializa las referencias al Rigidbody2D y al Animator del objeto.
    /// Verifica también que el joystick haya sido asignado correctamente.
    /// </summary>
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (joystick == null)
        {
            Debug.LogError("¡El joystick no está asignado en el Inspector del script Movimiento!");
            // joystick = FindObjectOfType<Joystick>(); // Opcional si quieres buscarlo automáticamente
        }
    }

    /// <summary>
    /// Lee la entrada del jugador (teclado o joystick) y calcula la dirección del movimiento.
    /// Actualiza también los parámetros del Animator para reflejar la animación correspondiente.
    /// </summary>
    public void Update()
    {
        // Entrada desde joystick (si está presente)
        float inputX_Joystick = joystick != null ? joystick.Horizontal : 0f;
        float inputY_Joystick = joystick != null ? joystick.Vertical : 0f;

        // Entrada desde teclado (ideal para pruebas en PC)
        float inputX_Teclado = Input.GetAxisRaw("Horizontal");
        float inputY_Teclado = Input.GetAxisRaw("Vertical");

        // Si hay entrada por teclado, la usamos; si no, usamos joystick
        if (inputX_Teclado != 0 || inputY_Teclado != 0)
        {
            direccion = new Vector2(inputX_Teclado, inputY_Teclado).normalized;
        }
        else
        {
            direccion = new Vector2(inputX_Joystick, inputY_Joystick).normalized;
        }

        // Actualizar animación según dirección
        anim.SetFloat("MoveX", direccion.x);
        anim.SetFloat("MoveY", direccion.y);
        anim.SetBool("IsMoving", direccion.magnitude > 0);
    }

    /// <summary>
    /// Aplica el movimiento real al objeto utilizando el Rigidbody2D.
    /// Se llama en intervalos fijos, ideal para manejo físico.
    /// </summary>
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccion * velocidadMov * Time.fixedDeltaTime);
    }
}
