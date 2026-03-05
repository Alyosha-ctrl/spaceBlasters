using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class startScrene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject image;
    public TextMeshProUGUI startingText;
    void Start()
    {
        Invoke("invisScreen", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            invisScreen();
        }
    }

    void invisScreen()
    {
        //Make the image and the image child invisible
        // Image image = GetComponent<Image>();
        startingText.text = "";
        Destroy(this.gameObject);

        // RectTransform rect = GetComponent<RectTransform>();

        // Image image = GetComponent<Image>();
        //Change the color or otherwise destroy it.
    }
}
