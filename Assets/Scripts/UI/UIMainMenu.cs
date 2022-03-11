using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PhNarwahl;

public class UIMainMenu : MenuBase {
    #region Editor

    [SerializeField]
    private Button m_newGameButton;
    [SerializeField]
    private Button m_quitButton;

    #endregion

    #region Unity Callbacks

    private void Awake() {
        m_newGameButton.onClick.AddListener(HandleNewGame);
        m_quitButton.onClick.AddListener(HandleQuit);
    }

    #endregion

    #region ButtonHandlers

    private void HandleNewGame() {
        SetupLevelData();
        SceneManager.LoadScene("LevelSelect"); // change to whichever scene is your next
        AudioManager.instance.PlayOneShot("menu-click-default");
    }

    private void SetupLevelData() {
        LevelData.timeBetweenWaves = 2;
        LevelData.totalWaves = 5;
    }

    private void HandleQuit() {
        Application.Quit();
        AudioManager.instance.PlayOneShot("menu-click-default");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    #endregion
}
