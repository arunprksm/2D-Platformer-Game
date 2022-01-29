using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButtton;

    public Button optionsButtton;

    //public Button playButtton;

    public GameObject levelSelection;

    public GameObject optionWindow;

    private void Start()
    {
        levelSelection.SetActive(false);
        optionWindow.SetActive(false);
    }

    public void PlayButton()
    {
        SoundManager.Instance.PlaySound(Sounds.ButtonClick);
        if (levelSelection.activeSelf)
        {
            //SoundManager.Instance.Play(Sounds.ButtonClick);
            levelSelection.SetActive(false);
        }
        else
        {
            levelSelection.SetActive(true);
            optionWindow.SetActive(false);
        }
    }

    public void OptionButton()
    {
        SoundManager.Instance.PlaySound(Sounds.ButtonClick);
        if (optionWindow.activeSelf)
        {
            optionWindow.SetActive(false);
        }
        else
        {
            optionWindow.SetActive(true);
            levelSelection.SetActive(false);
        }
    }
}