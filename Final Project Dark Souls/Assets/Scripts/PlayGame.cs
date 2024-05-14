using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DS
{
    public class PlayGame : MonoBehaviour
    {   
        private void start()
        {
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void Menu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Play() 
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}