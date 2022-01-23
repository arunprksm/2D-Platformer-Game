using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContoller : MonoBehaviour
{

    public GameObject sceneObject;
    public string nextScene;
    internal string currentScene;

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
                SceneManager.LoadScene(nextScene);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sceneObject.SetActive(false);
    }

    public void ReloadScene(string currentScene)
    {
        SceneManager.LoadScene(currentScene);
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
