using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
   public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Load's named scene
        UnityEngine.Cursor.visible = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitted");
        Application.Quit(); // Closes the application
    }

}
