using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument uiDocument;

    void Start()
    {
        uiDocument = GetComponent<UIDocument>();

        // Získání root vizuálního stromu z UI dokumentu
        var rootVisualElement = uiDocument.rootVisualElement;

        // Najdìte tlaèítko podle jeho jména (podle jména z UXML)
        Button tutButton = rootVisualElement.Q<Button>("Tutorial");

        // Pøiøaïte metodu, která se spustí pøi kliknutí
        tutButton.clicked += TutorialClick;

        Button prvniButton = rootVisualElement.Q<Button>("Lvl1");

        prvniButton.clicked += PrvniClick;

        Button druhyButton = rootVisualElement.Q<Button>("Lvl2");

        druhyButton.clicked += DruhyClick;

        Button tretiButton = rootVisualElement.Q<Button>("Lvl3");

        tretiButton.clicked += TretiClick;

        Button ldbrButton = rootVisualElement.Q<Button>("Ldbr");

        ldbrButton.clicked += LdbrClick;

        Button extButton = rootVisualElement.Q<Button>("Ext");

        extButton.clicked += ExtClick;
    }

    // Metoda pro zmìnu scény
    void TutorialClick()
    {
        // Zmìna scény na jinou
        SceneManager.LoadScene("Tutorial");
    }

    void PrvniClick()
    {
        SceneManager.LoadScene("Level1");
    }

    void DruhyClick()
    {
        SceneManager.LoadScene("Level2");
    }

    void TretiClick()
    {
        SceneManager.LoadScene("Level3");
    }

    void LdbrClick()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    void ExtClick()
    {
        SceneManager.LoadScene("StartUpMenu");
    }
}