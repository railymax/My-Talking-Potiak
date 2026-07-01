using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject shopUI;
    public GameObject statsUI;
    [Header("Stats")]
    public float energy = 100f;
    public float purity = 100f;
    public int money = 0;
    public Text moneyText;
    [Header("Bars")]
    public Text energyText;
    public Text purityText;

    [Header("Food Inventory")]
    public int plovCounter = 0;
    public int proteinCounter = 0;
    public int milkCounter = 0;
    [Header("Food Prices")]
    public int plovPrice = 5;
    public int proteinPrice = 15;
    public int milkPrice = 10;
    [Header("Food Texts")]
    public Text plovText;
    public Text proteinText;
    public Text milkText;

    //Start
    public void Start()
    {
        energy = 100f;
        purity = 100f;
        money = PlayerPrefs.GetInt("SavedMoney", 0);
        energy = PlayerPrefs.GetFloat("SavedEnergy", 0f);
        purity = PlayerPrefs.GetFloat("SavedPurity", 0f);
        plovCounter = PlayerPrefs.GetInt("SavedPlov", 0);
        proteinCounter = PlayerPrefs.GetInt("SavedProtein", 0);
        milkCounter = PlayerPrefs.GetInt("SavedMilk", 0);

        UpdateUI();
    }
    public void UpdateUI()
    {
        if (moneyText != null) moneyText.text = money.ToString() + "$";
        if (plovText != null) plovText.text = plovCounter.ToString();
        if (proteinText != null) proteinText.text = proteinCounter.ToString();
        if (milkText != null) milkText.text = milkCounter.ToString();
        if (energyText != null) energyText.text = energy.ToString() + "/100";
        if (purityText != null) purityText.text = purity.ToString() + "/100";

        PlayerPrefs.SetInt("SavedMoney", money);
        PlayerPrefs.SetFloat("SavedEnergy", energy);
        PlayerPrefs.SetFloat("SavedPurity", purity);
        PlayerPrefs.SetInt("SavedPlov", plovCounter);
        PlayerPrefs.SetInt("SavedProtein", proteinCounter);
        PlayerPrefs.SetInt("SavedMilk", milkCounter);

        PlayerPrefs.Save();
    }

    //BUTTONS
    public void OnProteinEating()
    {
        if (proteinCounter > 0)
        {
            proteinCounter--;
            energy += 10f;
            energy = Mathf.Clamp(energy, 0, 100);
        }
        UpdateUI();
    }
    public void OnTestEating()
    {
        if (plovCounter > 0)
        {
            plovCounter--;
            energy += 50f;
            energy = Mathf.Clamp(energy, 0, 100);
        }
        UpdateUI();
    }
    public void OnMilkDrinking()
    {
        if (milkCounter > 0)
        {
            milkCounter--;
            energy += 15f;
            energy = Mathf.Clamp(energy, 0, 100);
        }
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
            UpdateUI();
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
            UpdateUI();
        }
    }
    public void OnDiscipline()
    {
        energy += 1f;
        energy = Mathf.Clamp(energy, 0, 100);
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
    //Food
    public void BuyFood(string itemName)
    {
        if (itemName == "plov" && money >= plovPrice) { money -= plovPrice; plovCounter++; }
        else if (itemName == "protein" && money >= proteinPrice) { money -= proteinPrice; proteinCounter++; }
        else if (itemName == "milk" && money >= milkPrice) { money -= milkPrice; milkCounter++; }
        else { Debug.Log("ИДИ НА ЗАВОД НИЩЕТА😭😭"); return; }
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
        shopUI.SetActive(false);
        statsUI.SetActive(true);


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
            case "shop":
                statsUI.SetActive(false);
                shopUI.SetActive(true);
                break;
            case "xxl":
                SceneManager.LoadScene("XXL");
                break;
        }
    }
    //Hit
    public void HitPotiak()
    {
        Debug.Log("НА СУКА!😈😈😈");
    }
}

