using UnityEngine;
using UnityEngine.UI;

public class turner : MonoBehaviour
{
    //VARIABLES
    [Header("Image")]
    public Image backgroundImage;
    [Header("Spriter")]
    public Sprite gameRoomSprite;
    public Sprite kitchenRoomSprite;
    public Sprite bathRoomSprite;
    public Sprite sleepRoomSprite;
    public Sprite factoryRoomSprite;
    [Header("Rooms")]
    public GameObject gameUI;
    public GameObject kitchenUI;
    public GameObject bathUI;
    public GameObject sleepUI;
    public GameObject factoryUI;
    [Header("Stats")]
    public float energy = 100f;
    public float purity = 100f;
    public int money = 0;
    public Text moneyText;

    //Start
    public void Start()
    {
        energy = 100f;
        purity = 100f;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (moneyText != null) moneyText.text = money.ToString();
    }
    
    //BUTTONS
    public void OnProteinEating()
    {
        energy += 10f;
        energy = Mathf.Clamp(energy, 0, 100);
        purity = Mathf.Clamp(purity, 0, 100);
        Debug.Log("Скушал протеин, радостно");
        UpdateUI();
    }
    public void OnTestEating()
    {
        energy += 50f;
        energy = Mathf.Clamp(energy, 0, 100);
        purity = Mathf.Clamp(purity, 0, 100);
        Debug.Log("Укололся тестом");
        UpdateUI();
    }
    public void OnMilkDrinking()
    {
        energy += 15f;
        energy = Mathf.Clamp(energy, 0, 100);
        purity = Mathf.Clamp(purity, 0, 100);
        Debug.Log("Выпил молочка, вайб");
        UpdateUI();
    }
    public void OnShowerUsing()
    {
        if (energy >= 15f)
        {
            energy -= 15f;
            purity += 25f;
            energy = Mathf.Clamp(energy, 0, 100);
            purity = Mathf.Clamp(purity, 0, 100);
            Debug.Log("Отмыл грязь после завода");
            UpdateUI();
        }
        else
        {
            Debug.Log("Недостаточно энергии, сходи поешь");
        }

    }
    public void OnSoapUsing()
    {
        if (energy >= 5f)
        {
            energy -= 5f;
            purity += 10f;
            energy = Mathf.Clamp(energy, 0, 100);
            purity = Mathf.Clamp(purity, 0, 100);
            Debug.Log("Отмыл грязь под ногтями");
            UpdateUI();
        }
        else
        {
            Debug.Log("Недостаточно энергии, сходи поешь");
        }
    }
    public void OnDiscipline()
    {
        energy += 1f;
        purity -= 1f;
        energy = Mathf.Clamp(energy, 0, 100);
        purity = Mathf.Clamp(purity, 0, 100);
        Debug.Log("ТИХО! ПОТЯК ДЕЛАЕТ ДИСЦИПЛИНУ😈😈😈");
        UpdateUI();
    }
    public void OnFactoryWork()
    {
        if (energy >= 15f && purity >= 20f)
        {
            energy -= 15f;
            purity -= 20f;
            money += 10;
            energy = Mathf.Clamp(energy, 0, 100);
            purity = Mathf.Clamp(purity, 0, 100);
            Debug.Log("ПОТЯК РАБОТАЕТ ЗА КОПЕЙКИ🤑🤑🤑");
        }
        else
        {
            if (energy < 15f)
            {
                Debug.Log("КАЖЕТСЯ КТО ТО УСТАЛ👾");
            }
            else
            {
                Debug.Log("ШУКАН СКАЗАЛ ТЫ НЕ МЫЛСЯ 10 ЛЕТ, ИДИ В ДУШ ВОНЮЧАЯ ГОРИЛЛА💀");
            }
        }
        UpdateUI();
    }

    //BgColor
    public void SetBackgroundColor(string roomName)
    {
        gameUI.SetActive(false);
        kitchenUI.SetActive(false);
        bathUI.SetActive(false);
        sleepUI.SetActive(false);
        factoryUI.SetActive(false);

        switch (roomName.ToLower())
        {
            case "game":
                backgroundImage.sprite = gameRoomSprite;
                gameUI.SetActive(true);
                break;
            case "kitchen":
                backgroundImage.sprite = kitchenRoomSprite;
                kitchenUI.SetActive(true);
                break;
            case "bath":
                backgroundImage.sprite = bathRoomSprite;
                bathUI.SetActive(true);
                break;
            case "sleep":
                backgroundImage.sprite = sleepRoomSprite;
                sleepUI.SetActive(true);
                break;
            case "factory":
                backgroundImage.sprite = factoryRoomSprite;
                factoryUI.SetActive(true);
                break;
        }
    }
    //Hit
    public void HitPotiak()
    {
        Debug.Log("НА СУКА!😈😈😈");
    }
}

