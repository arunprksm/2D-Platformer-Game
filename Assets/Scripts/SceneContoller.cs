using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContoller : MonoBehaviour
{

    public GameObject sceneObject;

    private void Start()
    {
        sceneObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            sceneObject.SetActive(true);
            if(sceneObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sceneObject.SetActive(false);
    }
}
