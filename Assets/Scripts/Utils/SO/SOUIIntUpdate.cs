using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt SOInt;
    public TextMeshProUGUI uiTextValue;

    // Start is called before the first frame update
    void Start()
    {
        uiTextValue.text = "x" + SOInt.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = "x" + SOInt.value.ToString();
    }
}
