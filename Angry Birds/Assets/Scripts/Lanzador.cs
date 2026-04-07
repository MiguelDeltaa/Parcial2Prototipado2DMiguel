using UnityEngine;

public class Lanzador : MonoBehaviour
{
    public float fuerzaLanzamiento = 3f;
    private Vector2 puntoInicio;
    private Rigidbody2D rb;
    private LineRenderer linea;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        linea = GetComponent<LineRenderer>();
        linea.positionCount = 0;
        anim = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        puntoInicio = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (anim != null)
        {
            anim.SetBool("estaArrastrando", true);
        }
    }

    void OnMouseDrag()
    {
        Vector2 puntoActual = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = puntoInicio - puntoActual;
        Vector2 velocidadInicial = direccion * fuerzaLanzamiento;

        DibujarTrayectoria(velocidadInicial);
    }

    void OnMouseUp()
    {
        if (anim != null)
        {
            anim.SetBool("estaArrastrando", false);
        }

        linea.positionCount = 0;

        Vector2 puntoActual = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = puntoInicio - puntoActual;

        rb.AddForce(direccion * fuerzaLanzamiento, ForceMode2D.Impulse);
        rb.gravityScale = 1;
    }

    void DibujarTrayectoria(Vector2 velocidad)
    {
        int cantidadPuntos = 15;
        linea.positionCount = cantidadPuntos;
        Vector2 posicionActual = transform.position;

        for (int i = 0; i < cantidadPuntos; i++)
        {
            float tiempo = i * 0.1f;
            Vector2 posicionEnCurva = posicionActual + velocidad * tiempo + 0.5f * Physics2D.gravity * 1f * (tiempo * tiempo);
            linea.SetPosition(i, posicionEnCurva);
        }
    }
}