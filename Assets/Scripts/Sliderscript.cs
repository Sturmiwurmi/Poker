using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sliderscript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI playercount;
    private int playercountint = 2; 
    void Start()
    {
        playercount.text = "Spieler: 2";
        slider.onValueChanged.AddListener((v) =>
        {
            playercount.text = "Spieler: " + v.ToString();
            playercountint = (int)v;
            
        }); 
       
    }

    public int getPlayercount()
    {
        return playercountint; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
