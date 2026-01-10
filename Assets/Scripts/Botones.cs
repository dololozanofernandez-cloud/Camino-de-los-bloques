using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
   public void Inicio()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Salir()
    {

        Application.Quit();
    }
}
