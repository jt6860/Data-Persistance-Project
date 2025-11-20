using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button newGameButton;
    public Button exitButton;

    public Button backButton;
    public Button submitButton;
    public TMP_InputField playerNameInput;

    private GameObject newGameMenuParent;

    private GameObject menuStartParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newGameMenuParent = GameObject.Find("New Game Start Parent");
        newGameMenuParent.SetActive(false);

        menuStartParent = GameObject.Find("Menu Start Parent");
        menuStartParent.SetActive(true);

        // find buttons
        newGameButton = GameObject.Find("New Game Button").GetComponent<Button>();
        exitButton = GameObject.Find("Exit Button").GetComponent<Button>();
        // listeners for buttons
        newGameButton.onClick.AddListener(NewGameMenuFlow);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NewGameMenuFlow() {
        menuStartParent.SetActive(false);
        newGameMenuParent.SetActive(true);

        playerNameInput = GameObject.Find("Player Name Input").GetComponent<TMP_InputField>();

        backButton = GameObject.Find("Back Button").GetComponent<Button>();
        backButton.onClick.AddListener(BackToMenuStart);

        submitButton = GameObject.Find("Submit Button").GetComponent<Button>();
        submitButton.onClick.AddListener(SubmitNameAndStart);
    }

    private void BackToMenuStart()
    {
        menuStartParent.SetActive(true);
        newGameMenuParent.SetActive(false);
    }

    private void SubmitNameAndStart()
    {
        if (playerNameInput.text != "")
        {
            PlayerPrefs.SetString("Player Name", playerNameInput.text);
            SceneManager.LoadScene("main");
        }
    }

    private void ExitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
