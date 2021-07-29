using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    public static GameplayUIManager instance;

    [SerializeField] GameObject medkitItem;
    [SerializeField] GameObject keyItem;
    [SerializeField] Text medkitItemText;
    [SerializeField] Text keyItemText;
    [SerializeField] GameObject charTuu;
    [SerializeField] GameObject charPom;
    [SerializeField] Image hpBar;
    [SerializeField] Image staminaBar;
    private float currentHP;
    private float maxHP;
    private float currentStamina;
    private float maxStamina;

    void Awake()
    {
        instance = this;

        charTuu.SetActive(false);
        charPom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ItemCountCheck();
        CharProfileImg();
        StatusBarUpdate();
    }

    void StatusBarUpdate()
    {
        currentHP = PlayerStatus.instance.hp;
        currentStamina = CharMovement.instance.staminaPoint;
        maxHP = PlayerStatus.instance.maxHP;
        maxStamina = CharMovement.instance.maxStaminaPoint;

        hpBar.fillAmount = currentHP/maxHP;
        staminaBar.fillAmount = currentStamina/maxStamina;
    }

    void CharProfileImg()
    {
        switch (CharacterManager.instance.playerName)
        {
            case "TuuTuu":
                charTuu.SetActive(true);
                break;
            case "PomPom":
                charPom.SetActive(true);
                break;
        }
    }

    void ItemCountCheck()
    {
        if (PlayerStatus.instance.keyItem < 1)
            keyItem.SetActive(false);
        else
        {
            keyItem.SetActive(true);
            keyItemText.text = $"{PlayerStatus.instance.keyItem}/{GameManager.instance.keyItemCount}";
        }


        if (PlayerStatus.instance.medKit < 1)
            medkitItem.SetActive(false);
        else
        {
            medkitItem.SetActive(true);
            medkitItemText.text = $"{PlayerStatus.instance.medKit}";
        }
    }
}
