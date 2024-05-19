using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public int point;

    public bool hasIncremented = false;

    // Start is called before the first frame update
    void Start()
    {
        
        point = 0;
        pointText.text = $"Score: {point}";
    }

    private void Update()
    {
        if (hasIncremented == true)
        {
            point++;
            pointText.text = $"Score: {point}";
            hasIncremented = false;
        }

    }
}
