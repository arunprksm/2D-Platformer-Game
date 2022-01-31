using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContoller : MonoBehaviour
{

    public GameObject sceneObject;
    //public string nextScene;
    
    private void Start()
    {
        sceneObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            sceneObject.SetActive(true);

            //if(sceneObject.activeInHierarchy == true && Input.GetButton("Interact"))
            if (sceneObject.activeInHierarchy == true && Input.GetKey(KeyCode.E))
            {
                NextScene();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sceneObject.SetActive(false);
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
