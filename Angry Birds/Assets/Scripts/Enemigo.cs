using UnityEngine;

public class Enemigo : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D choque)
    {
        if (choque.gameObject.CompareTag("Proyectil"))
        {
            FindObjectOfType<ControladorPuntos>().SumarPuntos(10);
            Destroy(gameObject);
        }
    }
}