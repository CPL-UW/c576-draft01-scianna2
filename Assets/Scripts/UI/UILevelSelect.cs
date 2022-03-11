using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PhNarwahl;

public class UILevelSelect : MenuBase {
    #region Editor

    [SerializeField]
    private Button m_quitButton;

    #endregion

    #region Unity Callbacks

    private void Awake() {
        foreach(Button button in MenuButtons) {
            //TODO Figure out how to pass in level number
            button.onClick.AddListener(HandleLevelSelection);
        }
    }

    #endregion

    #region ButtonHandlers

    private void HandleLevelSelection() {
        SetupLevelData();
        SceneManager.LoadScene("SampleScene"); // change to whichever scene is your next
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
