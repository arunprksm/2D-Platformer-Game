using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContoller : MonoBehaviour
{

    public GameObject sceneObject;
    public string sceneName;

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
                SceneManager.LoadScene(sceneName);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sceneObject.SetActive(false);
    }
}
