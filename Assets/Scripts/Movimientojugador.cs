using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] float velocidadSalto;

    [SerializeField] Transform comprobadorSuelo; 
    [SerializeField] float radioEsfera = 0.3f;   
    [SerializeField] LayerMask capaSuelo;

    InputAction actionMoverse;
    InputAction actionSaltar;
    Rigidbody rb;
    bool estaEnSuelo;

    void Start()
    {
        actionMoverse = InputSystem.actions.FindAction("Move");
        actionSaltar = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody>();

    }

   


    void Update()
    {
        estaEnSuelo = Physics.CheckSphere(comprobadorSuelo.position, radioEsfera, capaSuelo);
        if (actionSaltar.WasPressedThisFrame()  && estaEnSuelo)
        {
            Saltar();
        }
    }

    void FixedUpdate()
    {
        Mover();
    }

    void Mover()
    {
        Vector2 input = actionMoverse.ReadValue<Vector2>();

        if (input.sqrMagnitude > 0.01f)
        {
            Vector3 movimiento = transform.right * input.x + transform.forward * input.y;
            float X = movimiento.x * velocidad;
            float Z = movimiento.z * velocidad;

            rb.linearVelocity = new Vector3(X, rb.linearVelocity.y, Z);
        }
        else
        {
            if (transform.parent != null)
            {
                
                 rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.fixedDeltaTime);
            }
            else
            {
                
                rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            }

        }
    }

    void Saltar()
    {

        rb.AddForce(Vector3.up * velocidadSalto, ForceMode.Impulse);
    }

   
}


