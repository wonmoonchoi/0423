using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnButtonClick_Start()
    {
        SceneManager.LoadScene("Openig");
    }

    public void OnButtonClick_Option()
    {

    }

    public void OnButtonClick_Exit()
    {
        Application.Quit();
    }
}
