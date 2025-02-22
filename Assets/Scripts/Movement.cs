using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction SpaceButton;
    [SerializeField] InputAction rotation;
    [SerializeField] float upspeed = 500f;
    [SerializeField] float rotationspeed = 100f;



    Rigidbody rb;
    void Start()
    {
    rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        SpaceButton.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ForThrust();
        ForRotation();
    }

    private void ForThrust()
    {
        if (SpaceButton.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * upspeed * Time.fixedDeltaTime);
            Debug.Log("Basildi");
        }
    }

    void ForRotation()
    {
        float Rotasyonumuz = rotation.ReadValue<float>();
        if(Rotasyonumuz < 0)
        {
            ApplyRotation(rotationspeed);
        }
        else if(Rotasyonumuz > 0)
        {
            ApplyRotation(-rotationspeed);
        }
    }

    private void ApplyRotation(float RotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }

}




