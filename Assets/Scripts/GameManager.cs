using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text totalClicksText;

    public float totalClicks;
    public int clickAmmount = 1;



    public void Clicks()
    {
        totalClicks += clickAmmount;
        totalClicksText.text = totalClicks.ToString("0");
    }
    private void Update()
    {
        
    }
}
