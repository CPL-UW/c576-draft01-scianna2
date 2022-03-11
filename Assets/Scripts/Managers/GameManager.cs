using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private bool m_isPaused;

    public bool IsPaused { get { return m_isPaused; } }

    #region Unity Callbacks

    private void OnEnable() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (this != instance) {
            Destroy(this.gameObject);
        }

        m_isPaused = false;
    }

    #endregion
}
