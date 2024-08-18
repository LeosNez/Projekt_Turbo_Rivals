using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowlLdbrd : MonoBehaviour
{
    public GameObject LeaderBoard;

    public void Show()
    {
        LeaderBoard.SetActive(true);
    }

    public void Off()
    {
        LeaderBoard.SetActive(false);
    }
}