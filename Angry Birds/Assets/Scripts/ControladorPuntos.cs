using UnityEngine;
using TMPro; 

public class ControladorPuntos : MonoBehaviour
{
    public int puntos = 0;
    public TextMeshProUGUI textoPuntos; 

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        textoPuntos.text = "Puntos: " + puntos;
    }
}