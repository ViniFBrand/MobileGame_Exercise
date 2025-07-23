using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    public List<Transform> positions;

    public float duration = 1.0f;

    private int _index;

    private void Start()
    {
        transform.position = positions[Random.Range(0, positions.Count)].position;
        NextIndex();

        StartCoroutine(StartMoviment());
    }

    private void NextIndex()
    {
        _index++;

        if (_index >= positions.Count) _index = 0;
    }


    IEnumerator StartMoviment()
    {
        float time = 0;
        _index = Random.Range(0, positions.Count);
        //var posRandom = positions[Random.Range(0, _index)];

        while (true)
        {
            var currentPosition = transform.position;

            while (time < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (time/duration));

                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            time = 0;

            yield return null;
        }
    }
}


