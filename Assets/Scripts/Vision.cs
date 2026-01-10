using UnityEngine;
using UnityEngine.InputSystem;

public class Vision : MonoBehaviour
{

    [SerializeField] float sensibilidad;
    float rotacion = 0f;
    [SerializeField] Transform jugador;


    void Start()
    {
        //punto central
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

        float posicionRatonX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float posicionRatonY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        rotacion = rotacion - posicionRatonY;
        //Simula el movimiento del cuello
        rotacion = Mathf.Clamp(rotacion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacion, 0f, 0f);
        jugador.Rotate(Vector3.up * posicionRatonX);
    }
}