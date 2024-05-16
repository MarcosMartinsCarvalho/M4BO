using TMPro;
using UnityEngine;

public class KeyPadScript : MonoBehaviour
{
    [SerializeField] private GameObject button1; // The first button game object
    [SerializeField] private GameObject button2; // The second button game object
    [SerializeField] private Color button1Color; // Color of button 1 when pressed
    [SerializeField] private Color button2Color; // Color of button 2 when pressed
    [SerializeField] private Color button1ColorNotPressed; // Color of button 1 when not pressed
    [SerializeField] private Color button2ColorNotPressed; // Color of button 2 when not pressed
    [SerializeField] private KeyCode key1; // Key code for button 1
    [SerializeField] private KeyCode key2; // Key code for button 2
    [SerializeField] private TextMeshProUGUI textToUpdate1; // TextMeshProUGUI to update for button 1
    [SerializeField] private TextMeshProUGUI textToUpdate2; // TextMeshProUGUI to update for button 2
    private bool isKeyPressed1; // Flag to track if button 1 is currently pressed
    private bool wasKeyPressed1; // Flag to track if button 1 was pressed in the previous frame
    private bool isKeyPressed2; // Flag to track if button 2 is currently pressed
    private bool wasKeyPressed2; // Flag to track if button 2 was pressed in the previous frame

    private void Start()
    {
        // Initialize previous key press flags to false
        wasKeyPressed1 = false;
        wasKeyPressed2 = false;
    }

    private void Update()
    {
        // Check if button 1 is currently pressed
        isKeyPressed1 = Input.GetKey(key1);

        // Handle button 1 press and release
        if (isKeyPressed1 && !wasKeyPressed1)
        {
            int currentValue = int.Parse(textToUpdate1.text);
            textToUpdate1.text = (currentValue + 1).ToString(); // Increment text by 1
            button1.GetComponent<SpriteRenderer>().color = button1Color; // Change color of button 1 when pressed
        }
        else if (!isKeyPressed1 && wasKeyPressed1)
        {
            button1.GetComponent<SpriteRenderer>().color = button1ColorNotPressed; // Change color of button 1 when released
        }

        // Check if button 2 is currently pressed
        isKeyPressed2 = Input.GetKey(key2);

        // Handle button 2 press and release
        if (isKeyPressed2 && !wasKeyPressed2)
        {
            int currentValue = int.Parse(textToUpdate2.text);
            textToUpdate2.text = (currentValue + 1).ToString(); // Increment text by 1
            button2.GetComponent<SpriteRenderer>().color = button2Color; // Change color of button 2 when pressed
        }
        else if (!isKeyPressed2 && wasKeyPressed2)
        {
            button2.GetComponent<SpriteRenderer>().color = button2ColorNotPressed; // Change color of button 2 when released
        }

        // Update previous key press flags
        wasKeyPressed1 = isKeyPressed1;
        wasKeyPressed2 = isKeyPressed2;
    }
}
