using UnityEngine;

/// <summary>
/// Controla el movimiento del objeto 2D usando entrada del jugador y Rigidbody2D.
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
    private Animator anim;

    /// <summary>
    /// Inicializa el componente Rigidbody2D.
    /// </summary>
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Actualiza la dirección del movimiento según la entrada del usuario cada frame.
    /// </summary>
    public void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        anim.SetFloat("MoveX", direccion.x);
        anim.SetFloat("MoveY", direccion.y);
        anim.SetBool("IsMoving", direccion.magnitude > 0);
    }
    
    /// <summary>
    /// Aplica el movimiento físico al objeto en intervalos fijos.
    /// </summary>
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccion * velocidadMov * Time.fixedDeltaTime);
    }
}
