using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreField;
    [SerializeField] private string defaultMessage;

    // Start is called before the first frame update
    void Start()
    {
        int score = GameMaster.Score;
        scoreField.text = defaultMessage + score.ToString();
    }

}
