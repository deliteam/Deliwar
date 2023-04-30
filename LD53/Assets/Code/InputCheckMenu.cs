using UnityEngine;

public class InputCheckMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject victoryMenu;
    private void Update() {
        GameOverActive();
        VictoryActive();
    }
    private void GameOverActive(){
        if (Input.GetKeyDown(KeyCode.G)) // --> buraya koşul gelecek öldüğünü takip eden bir bool ile yapılabilir.
        {
            gameOverMenu.SetActive(true);
        }
    }
    private void VictoryActive(){
        if (Input.GetKeyDown(KeyCode.V)) // --> oyun sonu boss'u kestikten sonra veya finish noktasına gittikten sonra bool ile yapılabilir.
        {
            victoryMenu.SetActive(true);
        }
    }
}
