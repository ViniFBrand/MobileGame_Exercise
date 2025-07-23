using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public string compareTag = "Player";
    public GameObject graphicItem;
    public float timeToHide = 3;

    [Header("Sounds")]
    public AudioSource audioSource;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag)) 
        {
            Collect();
        }

    }

    protected virtual void HideItens()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke(nameof(HideObject), timeToHide);
    }

    protected virtual void Collect()
    {
        HideItens();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if(particleSystem != null) particleSystem.Play();
        if(audioSource != null) audioSource.Play();
    }
}
