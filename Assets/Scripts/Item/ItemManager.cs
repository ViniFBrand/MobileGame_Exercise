using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Sigleton;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt coins2;

    protected override void Awake()
    {
        base.Awake();
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        coins2.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value +=amount;
    }

    public void AddCoins2(int amount = 1)
    {
        coins2.value += amount;
    }

    /*private void UpdateUI()
    {
       UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }*/
}
