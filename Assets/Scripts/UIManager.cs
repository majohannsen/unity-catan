using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    TMP_Text Text;

    void Start()
    {
        Text = GameObject.FindGameObjectWithTag("UI Text").GetComponent<TMP_Text>();
        updateText();
    }

    public void updateText()
    {
        Text.text = "Free Placement: " + gameObject.GetComponent<GameController>().freePlacement;
    }
}
