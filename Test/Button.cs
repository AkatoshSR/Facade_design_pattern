using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    Facade facade;
    [SerializeField]
    public GameObject go1;
    public GameObject go2;


    private void Start()
    {
        facade = new Facade();
    }

    //button
    public void AddLevel()
    {
        facade.SetPlayerInfo(StringManager.PlayerLevel, facade.GetPlayerInfo(StringManager.PlayerLevel) + 1);
        LevelView();
    }
    public void LevelView()
    {
        go1.GetComponent<Text>().text = facade.GetPlayerInfo(StringManager.PlayerLevel).ToString();
    }
    public void AddCoin()
    {
        facade.SetPlayerInfo(StringManager.PlayerCoins, facade.GetPlayerInfo(StringManager.PlayerCoins) + 1);
        CoinsView();
    }
    public void CoinsView()
    {
        go2.GetComponent<Text>().text = facade.GetPlayerInfo(StringManager.PlayerCoins).ToString();
    }
}
