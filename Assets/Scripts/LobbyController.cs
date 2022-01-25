using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButtton;
    public GameObject levelSelection;

    private void Start()
    {
        levelSelection.SetActive(false);
    }

    public void PlayGame()
    {
        levelSelection.SetActive(true);
    }

}


