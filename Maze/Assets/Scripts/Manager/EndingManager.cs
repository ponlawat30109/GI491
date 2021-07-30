using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
