using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] Text playerSelect;
    [SerializeField] string playerSelectName;
    [SerializeField] List<Button> playerButtonList = new List<Button>();
    [SerializeField] Button playButton;

    void Awake()
    {
        instance = this;

        foreach (var playerOrder in playerButtonList)
        {
            playerOrder.onClick.AddListener(delegate{SelectPlayer(playerOrder);});
        }

        playButton.onClick.AddListener(delegate{SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);});
    }

    void SelectPlayer(Button playerSelectButton)
    {
        playerSelectName = playerSelectButton.GetComponentInChildren<Text>().text;
        playerSelect.text = $"Select : {playerSelectName}";
        Debug.Log(playerSelectName);
    }
}
