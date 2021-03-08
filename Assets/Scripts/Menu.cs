using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
  [SerializeField] private Player _player;
  [SerializeField] private Canvas UICanvas;

  public void LoadMainMenu() {
    SceneManager.LoadScene(0);
  }

  public void LoadLevel() {
    SceneManager.LoadScene(1);
  }
  
  public void UICanvasSceneCheck() {
    if (UICanvas != null) {
      Scene currentScene = SceneManager.GetActiveScene();
      string currentScene_Name = currentScene.name;

      if (currentScene_Name == "Main Menu") {
        UICanvas.gameObject.SetActive(false);
      }
      else if (currentScene_Name == "Level") {
        UICanvas.gameObject.SetActive(true);
      }
    }
    else {
      Debug.Log("COULD NOT FIND UI CANVAS, REFERENCE IT IN THE INSPECTOR");
    }
  }

  public void ContinueLevel() {
    // _player.ContinueLevel();
  }
}
