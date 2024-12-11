#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public string name;
    public TMP_Text bestScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DataPresistor.Instance.LoadScore();
        bestScoreText.text = "Best Score: " + DataPresistor.Instance.bestScore + " Name: " + DataPresistor.Instance.bestName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataPresistor.Instance.name = name;
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void changeName(string newName)
    {
        name = newName;
    }
}
