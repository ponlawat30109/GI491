using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TextMeshProUGUI playerSelect;
    [SerializeField] public string playerSelectName;
    [SerializeField] List<Button> playerButtonList = new List<Button>();
    [SerializeField] Button playButton;
    [SerializeField] Image[] charImg;

    void Awake()
    {
        instance = this;

        foreach (var playerOrder in playerButtonList)
        {
            playerOrder.onClick.AddListener(delegate { SelectCharacter(playerOrder); });
        }

        playButton.onClick.AddListener(PlayButton);
    }

    void SelectCharacter(Button playerSelectButton)
    {
        playerSelectName = playerSelectButton.GetComponentInChildren<TextMeshProUGUI>().text;

        playerSelect.text = $"Select : {playerSelectName}";

        // charImg[i].gameObject.SetActive(true);

        Debug.Log(playerSelectName);
    }

    void PlayButton()
    {
        if (!string.IsNullOrEmpty(playerSelectName))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // GameManager.instance.playerName = playerSelectName;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
