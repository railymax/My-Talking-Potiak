using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class XXL : MonoBehaviour
{
    public string itemType;
    public float fallSpeed = 5f;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            turner mainScript = FindObjectOfType<turner>();

            if (mainScript != null)
            {
                if (itemType == "food")
                {
                    mainScript.energy += 5f;
                    mainScript.energy = Mathf.Clamp(mainScript.energy, 0, 100);
                }
                else if (itemType == "money")
                {
                    mainScript.money += 5;
                }
                else if (itemType == "altushka")
                {
                    mainScript.money += 100;
                    mainScript.energy += 100f;
                    mainScript.purity += 100f;
                    mainScript.energy = Mathf.Clamp(mainScript.energy, 0, 100);
                    mainScript.purity = Mathf.Clamp(mainScript.purity, 0, 100);
                }
                mainScript.UpdateUI();
            }
        }
        Destroy(gameObject);
    }
}
