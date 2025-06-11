using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollectableBase
{
    public Collider collider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;



    private void Start()
    {
        //CoinsAnimationManager.Instance.RegisterCoin(this);
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position,PlayerController.Instance.transform.position, lerp * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                //HideItens();
                Destroy(gameObject);
            }
        }
    }


    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
        collider.enabled = false;
        collect = true;
        //PlayerController.Instance.Bounce();
    }

    protected override void Collect()
    {
        OnCollect();
    }

    public void HideItens()
    {

    }
}
