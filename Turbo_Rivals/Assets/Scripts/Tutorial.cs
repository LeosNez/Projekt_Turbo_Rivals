using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text TutorialText;
    public GameObject Canvas;

    private int _currentStep = 0;

    void Start()
    {
        DisplayInstructions();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _currentStep == 0)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && _currentStep == 1)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && _currentStep == 2)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.RightArrow) && _currentStep == 3)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.T) && _currentStep == 4)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.S) && _currentStep == 5)
        {
            _currentStep++;
            DisplayInstructions();
        }
    }

    void DisplayInstructions()
    {
        switch (_currentStep)
        {
            case 0:
                TutorialText.text = "Vítej u tutorialu. Napøed zkus popojed dopøedu tak, že zmáèkneš šipku dopøedu.";
                break;
            case 1:
                TutorialText.text = "Skvìle! Teï si zkusíme couvání. To udìláš tím, že zmáèkneš šipku zpìt.";
                break;
            case 2:
                TutorialText.text = "Nyní se rozjeï dopøedu nebo dozadu a u toho zkus zatoèit doleva tak, že bìhem toho co je tvé auto v pohybu zmáèkneš šipku doleva.";
                break;
            case 3:
                TutorialText.text = "A nyní zkus zatoèit doprava";
                break;
            case 4:
                TutorialText.text = "Pro zrychlení stisknìte T";
                break;
            case 5:
                TutorialText.text = "Teï zkus smyk pomocí S";
                break;
            default:
                TutorialText.text = "Blahopøeji! úspìšnì si prošel tutorialem :)";
                Canvas.SetActive(true);
                break;
        }
    }
}