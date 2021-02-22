using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {
    private const string MASTER_SCORE_KEY = "master score";

    public static void SetMasterScore(int score) {
        PlayerPrefs.SetInt(MASTER_SCORE_KEY, score);
    }

    public static int GetMasterScore() {
        return PlayerPrefs.GetInt(MASTER_SCORE_KEY);
    }
}
