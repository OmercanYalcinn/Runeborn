using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // This function gets called when the Play button is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene("City");
    }
}
