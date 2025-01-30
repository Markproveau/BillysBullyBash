using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    Image panelImage;

    private float colorChangeSpeed = 1.0f; // Speed of color change

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = CombatValues.buttonPressed.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        Color newColor = new Color(
         Mathf.PingPong(Time.time * colorChangeSpeed, 1),  // R
         Mathf.PingPong(Time.time * colorChangeSpeed * 0.8f, 1),  // G
         Mathf.PingPong(Time.time * colorChangeSpeed * 0.6f, 1)   // B
         );
        panelImage.color = newColor;
    }
}
