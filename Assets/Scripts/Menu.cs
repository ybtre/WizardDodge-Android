using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
  [SerializeField] private Player _player;
  public void LoadMainMenu() {
    SceneManager.LoadScene(0);
  }

  public void LoadLevel() {
    SceneManager.LoadScene(1);
  }

  public void ContinueLevel() {
    // _player.ContinueLevel();
  }
}
