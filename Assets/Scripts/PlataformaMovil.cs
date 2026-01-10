using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    [SerializeField] float velocidad;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    { 
        float avance = Mathf.PingPong(Time.time * velocidad, 1f);
        Vector3 proximaPosicion = Vector3.Lerp(puntoA.position, puntoB.position, avance);

        rb.MovePosition(proximaPosicion);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }


}
