using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
   public void BackToMainMenu(){
        SceneManager.LoadScene("Menu_Start");
        gameObject.SetActive(false);
    }
}
