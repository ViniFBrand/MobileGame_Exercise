using DG.Tweening;
using Ebac.Core.Sigleton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerController : Singleton<PlayerController>
{
    #region VARIABLES
    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    [Header("TextMeshPro")]
    public TextMeshPro uiTextPowerUp;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [Header("VFX")]
    public ParticleSystem vfxDeath;

    [Header("Boundaries")]
    public Vector2 limitVector = new Vector2 (-4,4);

    [Header("Player Animation")]
    public Ease ease = Ease.Linear;
    public float scaleDuration = .2f;


    [Header("Power Ups")]
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public bool invincible = false;

    public GameObject endScreen;

    [SerializeField] private BounceHelper _bounceHelper;

    //privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 5;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AppearAnimation());
        _startPosition = transform.position;
        ResetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        if (_pos.x < limitVector.x) _pos.x = limitVector.x;
        if (_pos.x > limitVector.y) _pos.x = limitVector.y;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    #region FUNCTIONS
    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimatorType.RUN, _currentSpeed / _baseSpeedToAnimation);
    }

    private void EndGame(AnimatorManager.AnimatorType animatorType = AnimatorManager.AnimatorType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animatorType);
    }

    private void MoveBack(Transform t)
    {
        t.DOMoveZ(1f, .3f).SetRelative();
    }

    public void Bounce()
    {
        if(_bounceHelper != null)
            _bounceHelper.Bounce();
    }

    public IEnumerator AppearAnimation()
    {
        this.transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(.5f);
        this.transform.DOScale(1, scaleDuration);
    }


    #region POWER UPS
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvincible(bool b = true) //por default é passado true
    {
        invincible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount,animationDuration).SetEase(ease);//.OnComplete(ResetHeight);
        Invoke(nameof(ResetHeight), duration);

    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);

        /*var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;*/
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    #endregion


    #endregion

    #region ONCOLLISION
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if (!invincible)
            {
                MoveBack(collision.transform);
                EndGame(AnimatorManager.AnimatorType.DEATH);
                if (vfxDeath != null) vfxDeath.Play();
            }
        }
    }
    #endregion

    #region ONTRIGGER
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckEndLine)
        {
            EndGame();
        }
    }

    #endregion
}

