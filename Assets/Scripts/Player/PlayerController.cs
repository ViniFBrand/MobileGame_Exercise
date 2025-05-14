using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";



    public GameObject endScreen;

    //privates
    private bool _canRun;
    private Vector3 _pos;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //_canRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    #region FUNCTIONS
    public void StartToRun()
    {
        _canRun = true;
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    #endregion

    #region ONCOLLISION
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            EndGame();
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

