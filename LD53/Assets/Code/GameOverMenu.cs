using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public void BackToMenu(){
        SceneManager.LoadScene("Main_Scene");
        gameObject.SetActive(false);
    }
}
