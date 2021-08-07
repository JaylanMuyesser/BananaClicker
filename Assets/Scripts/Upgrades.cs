using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public GameManager gameManager;

    public float autoClicksPerSecond;

    public Text AutoClicksPerSecondText;
    public Text ClickAmountText;

    private float upgrade1Price = 40;
    public Text upgrade1Text;
    private int timesBought1;

    private float upgrade2Price = 200;
    public Text upgrade2Text;
    private int timesBought2;

    private float upgrade3Price = 125;
    public Text upgrade3Text;
    private int timesBought3;

    private float upgrade1UnlockPrice = 50000;
    public Text upgrade1UnlockText;
    public Button upgrade1UnlockButton;
    private bool upgrade1UnlockBought = false;

    private float upgrade2UnlockPrice = 90000;
    public Text upgrade2UnlockText;
    public Button upgrade2UnlockButton;
    private bool upgrade2UnlockBought = false;

    private float upgrade3UnlockPrice = 10000;
    public Text upgrade3UnlockText;
    public Button upgrade3UnlockButton;
    private bool upgrade3UnlockBought = false;


    private void Start()
    {
        upgrade1Text.text = upgrade1Price.ToString("0");
        upgrade2Text.text = upgrade2Price.ToString("0");
        upgrade3Text.text = upgrade3Price.ToString("0");
        upgrade1UnlockText.text = upgrade1UnlockPrice.ToString("0");
        upgrade2UnlockText.text = upgrade2UnlockPrice.ToString("0");
        upgrade3UnlockText.text = upgrade3UnlockPrice.ToString("0");
        upgrade1UnlockButton.gameObject.SetActive(false);
        upgrade2UnlockButton.gameObject.SetActive(false);
        upgrade3UnlockButton.gameObject.SetActive(false);
    }
    public void AutoClickUpgrade1()
    {
        if (gameManager.totalClicks > upgrade1Price)
        {
            gameManager.totalClicks -= upgrade1Price;
            upgrade1Price = upgrade1Price * 1.5f;
            autoClicksPerSecond++;
            upgrade1Text.text = upgrade1Price.ToString("0");
            timesBought1++;
        }
    }

    public void AutoClickUpgrade2()
    {
        if (gameManager.totalClicks > upgrade2Price)
        {
            gameManager.totalClicks -= upgrade2Price;
            upgrade2Price = upgrade2Price * 1.5f;
            autoClicksPerSecond += 2 ;
            upgrade2Text.text = upgrade2Price.ToString("0");
            timesBought2++;
        }
    }

    public void AutoClickUpgrade3()
    {
        if (gameManager.totalClicks > upgrade3Price)
        {
            gameManager.totalClicks -= upgrade3Price;
            upgrade3Price = upgrade3Price * 2f;
            gameManager.clickAmmount++;
            upgrade3Text.text = upgrade3Price.ToString("0");
            timesBought3++;
        }
    }
    public void AutoClickUpgrade1Unlock()
    {
            gameManager.totalClicks -= upgrade1UnlockPrice;
            autoClicksPerSecond += 30;
            upgrade1UnlockBought = true;
            upgrade1UnlockButton.gameObject.SetActive(false);
    }
    public void AutoClickUpgrade2Unlock()
    {     
            gameManager.totalClicks -= upgrade2UnlockPrice;
            autoClicksPerSecond += 100;
            upgrade2UnlockBought = true;
            upgrade2UnlockButton.gameObject.SetActive(false);

    }
    public void AutoClickUpgrade3Unlock()
    {       
            gameManager.totalClicks -= upgrade3UnlockPrice;
            gameManager.clickAmmount += 30;
            upgrade3UnlockBought = true;
            upgrade3UnlockButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        gameManager.totalClicks += autoClicksPerSecond * Time.deltaTime;
        gameManager.totalClicksText.text = gameManager.totalClicks.ToString("0");
        AutoClicksPerSecondText.text = autoClicksPerSecond.ToString("0");
        ClickAmountText.text = gameManager.clickAmmount.ToString("0");

        if (timesBought1 >= 10 && upgrade1UnlockBought == false)
        {
            upgrade1UnlockButton.gameObject.SetActive(true);
        }
        if (timesBought2 >= 10 && upgrade2UnlockBought == false)
        {
            upgrade2UnlockButton.gameObject.SetActive(true);
        }
        if (timesBought3 >= 10 && upgrade3UnlockBought == false)
        {
            upgrade3UnlockButton.gameObject.SetActive(true);
        }

    }
}
