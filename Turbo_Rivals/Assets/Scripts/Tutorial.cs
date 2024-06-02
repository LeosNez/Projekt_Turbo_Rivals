using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text tutorialText;
    public GameObject canvas;

    private int currentStep = 0;

    void Start()
    {
        DisplayInstructions();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentStep == 0)
        {
            currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentStep == 1)
        {
            currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && currentStep == 2)
        {
            currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.RightArrow) && currentStep == 3)
        {
            currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.T) && currentStep == 4)
        {
            currentStep++;
            DisplayInstructions();
        }
    }

    void DisplayInstructions()
    {
        switch (currentStep)
        {
            case 0:
                tutorialText.text = "Vítej u tutorialu. Napøed zkus popojed dopøedu tak, že zmáèkneš šipku dopøedu.";
                break;
            case 1:
                tutorialText.text = "Skvìle! Teï si zkusíme couvání. To udìláš tím, že zmáèkneš šipku zpìt.";
                break;
            case 2:
                tutorialText.text = "Nyní se rozjeï dopøedu nebo dozadu a u toho zkus zatoèit doleva tak, že bìhem toho co je tvé auto v pohybu zmáèkneš šipku doleva.";
                break;
            case 3:
                tutorialText.text = "A nyní zkus zatoèit doprava";
                break;
            case 4:
                tutorialText.text = "Pro zrychlení stisknìte T";
                break;
            default:
                tutorialText.text = "Blahopøeji! úspìšnì si prošel tutorialem :)";
                canvas.SetActive(true);
                break;
        }
    }
}