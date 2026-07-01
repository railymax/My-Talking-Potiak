using UnityEngine;
using UnityEngine.UI;

public class turner : MonoBehaviour
{
    public Image backgroundImage;
    public Color gameRoomcolor = Color.gray;
    public Color kitchenRoomcolor = Color.green;
    public Color bathRoomcolor = Color.blue;
    public Color sleepRoomcolor = Color.magenta;
    public Color factoryRoomcolor = Color.magenta;

    public void SetBackgroundColor(string roomName)
    {
        if (backgroundImage == null) return;

        switch (roomName.ToLower())
        {
            case "game":
                backgroundImage.color = gameRoomcolor;
                break;
            case "kitchen":
                backgroundImage.color = kitchenRoomcolor;
                break;
            case "bath":
                backgroundImage.color = bathRoomcolor;
                break;
            case "sleep":
                backgroundImage.color = sleepRoomcolor;
                break;
            case "factory":
                backgroundImage.color = factoryRoomcolor;
                break;
        }
    }
    public void HitPotiak()
    {
        Debug.Log("НА СУКА!😈😈😈");
    }
}

