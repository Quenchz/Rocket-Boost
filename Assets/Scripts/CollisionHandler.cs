using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{





    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friend":
            Debug.Log("Tebrikler Indiniz");
            break;

            case "Finish":
            NextLevel();
            break;

            default:
            ReloadLevel();
            break;
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
    }
}
