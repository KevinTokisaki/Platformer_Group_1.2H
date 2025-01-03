using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Reference to the first image
    public GameObject Image1;

    // Reference to the second image
    public GameObject Image2;

    // Reference to the Start button
    public Button BtnStart;

    void Start()
    {
        // Ensure the second image is hidden at the start
        Image2.SetActive(false);

        // Set up the button listener
        BtnStart.onClick.AddListener(OnStartButtonClicked);
    }

    void OnStartButtonClicked()
    {
        // Disable the first image and its buttons
        Image1.SetActive(false);

        // Show the second image and its buttons
        Image2.SetActive(true);
    }
}
