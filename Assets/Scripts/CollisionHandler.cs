using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

AudioSource audioSource;
[SerializeField] AudioClip crashsound;
[SerializeField] AudioClip successound;
[SerializeField] ParticleSystem succesParticle;
[SerializeField] ParticleSystem crashParticle;

    bool isControllable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        RespondToDebugKeys();
    }


    void OnCollisionEnter(Collision other)
    {
        if(isControllable == false)
        {
        return;
        }
        
        switch (other.gameObject.tag)
        {
            case "Friend":
            Debug.Log("Tebrikler Indiniz");
            break;

            case "Finish":
            StartFinishSequence();
            break;

            default:
            StartCrashSequence();
            break;
        }
    }

    void StartFinishSequence()
    {
    isControllable = false;
    audioSource.Stop();
    audioSource.PlayOneShot(successound);
    succesParticle.Play();
    GetComponent<Movement>().enabled = false;
    Invoke("NextLevel", 2f);
    }

    void StartCrashSequence()
    {
    isControllable = false;
    audioSource.Stop();
    audioSource.PlayOneShot(crashsound);
    crashParticle.Play();
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel" , 2f);
    }


    void ReloadLevel()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }

    void NextLevel(){
    int currentscene = SceneManager.GetActiveScene().buildIndex;
    int nextScene = currentscene + 1;
    if(nextScene == SceneManager.sceneCountInBuildSettings){
        
        nextScene = 0;
    }
    SceneManager.LoadScene(nextScene);
    }

    void RespondToDebugKeys(){
        if(Keyboard.current.lKey.IsPressed()){
            NextLevel();
        }
    }
}

