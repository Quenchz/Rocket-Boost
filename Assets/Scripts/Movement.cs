using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction SpaceButton;
    [SerializeField] InputAction rotation;
    [SerializeField] float upspeed = 500f;
    [SerializeField] float rotationspeed = 100f;
    [SerializeField] AudioClip mainEngine;
    
    AudioSource audioSource;
    Rigidbody rb;

    void Start()
    {
    rb = GetComponent<Rigidbody>();
    audioSource = GetComponent<AudioSource>();
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

            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngine);
            }
            
        }else{
            audioSource.Stop();
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

    void ApplyRotation(float RotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }


}




