using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coleccionables : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI texto;
  int numEsferas = 0;

    private void Start()
    {
        texto.text = "Esferas: 0";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Moneda"))
        {
            numEsferas++;
            texto.text = "Esferas: " + numEsferas.ToString();

            other.gameObject.SetActive(false);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fin"))
        {
            if (numEsferas > 55)
            {
      
                SceneManager.LoadScene("Fin");
            }


        }
    }
}
