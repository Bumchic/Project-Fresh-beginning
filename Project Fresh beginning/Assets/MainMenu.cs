
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //public void LoadGame()
    //{
    //    SceneManager.LoadScene("Demo FightSceen");
    //}
    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGame()
   {
        SceneManager.LoadScene("level");
   }

    //public void BackMenu()
    //{
    //    SceneManager.LoadScene("MainMenu");
    //}
    public void ExitGame()
    {
        Application.Quit(); 
    }
}
