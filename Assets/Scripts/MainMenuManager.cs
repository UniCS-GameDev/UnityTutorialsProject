using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private string startSceneName;

    // Start is called before the first frame update
    void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(startSceneName, LoadSceneMode.Single);
    }
}
