using DG.Tweening;
using Ebac.Core.Sigleton;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollactableCoin> itens;

    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        itens = new List<ItemCollactableCoin>();
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.C))
        {
            StartAnimations();
        }*/
    }

    public void RegisterCoin(ItemCollactableCoin i)
    {
        if(!itens.Contains(i))
        {
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    public void CleanCoins()
    {
        for (int i = itens.Count - 1; i >= 0; i--)
        {
            Destroy(itens[i].gameObject);
        }
        itens.Clear();
    }

    public void StartAnimations()
    {
        StartCoroutine(ScaleCoinsByTime());
    }

    IEnumerator ScaleCoinsByTime()
    {
        foreach (var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }

        Sort();

        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }

    private void Sort()
    {
        itens = itens.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }

}
