using UnityEngine;
using UnityEngine.SceneManagement;

namespace DS
{
    public class GameOver : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}