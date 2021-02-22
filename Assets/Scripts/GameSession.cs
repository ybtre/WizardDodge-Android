using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {
    [SerializeField] private int playerLives = 1;

    [SerializeField] private int score = 0;
    
    #region Singleton
    private void Awake() {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion


    // Start is called before the first frame update
    void Start() {
    }

    public void ProcessPlayerDeath() {
        Destroy(gameObject);
    }

}
