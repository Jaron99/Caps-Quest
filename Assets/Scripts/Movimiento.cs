using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidadMov;
    [SerializeField] private Vector2 direccion;

    private Rigidbody2D rb;
    private Animator anim;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        anim.SetFloat("MoveX", direccion.x);
        anim.SetFloat("MoveY", direccion.y);
        anim.SetBool("IsMoving", direccion.magnitude > 0);
    }
    
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccion * velocidadMov * Time.fixedDeltaTime);
    }
}
