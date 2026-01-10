using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("juego");
    }
}
