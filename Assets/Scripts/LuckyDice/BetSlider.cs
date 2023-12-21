using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetSlider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bet;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject playerbox; 
    private int currentBet;
    private int maxGeld; 

    void Start()
    {
        maxGeld = playerbox.GetComponent<Playerbox>().getEigenesgeld();
        slider.maxValue = maxGeld;
       
        bet.text = currentBet.ToString();

        slider.onValueChanged.AddListener((v) =>
        {
            maxGeld = playerbox.GetComponent<Playerbox>().getEigenesgeld();
            slider.maxValue = maxGeld;

            bet.text = v.ToString();
            currentBet = (int)v;

        });
    }
    public int getCurrentBet()
    {
        return currentBet;
    }
    public void resetSlider()
    {
        maxGeld = playerbox.GetComponent<Playerbox>().getEigenesgeld();
        slider.maxValue = maxGeld;
        slider.value = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
