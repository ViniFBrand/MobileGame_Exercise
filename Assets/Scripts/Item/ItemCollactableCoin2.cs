using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin2 : ItemCollectableBase
{
    public Collider collider;

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins2();
        collider.enabled = false;
    }
}
