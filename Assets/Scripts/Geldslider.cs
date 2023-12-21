using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Geldslider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI geldtextfeld;
    private int geld = 100;
    void Start()
    {
        geldtextfeld.text = "Geld: 100";
        slider.onValueChanged.AddListener((v) =>
        {
            geldtextfeld.text = "Geld: " + RoundToNearestMultipleOf5((int)v).ToString();
            geld = RoundToNearestMultipleOf5((int)v);
            slider.value = geld;
           
        });
    }

    static int RoundToNearestMultipleOf5(int number)
    {
        int remainder = number % 5;
        if (remainder == 0) // Wenn die Zahl bereits durch 5 teilbar ist
            return number;

        int roundedNumber;

        if (remainder < 3) // Runde auf die nächste kleinere durch 5 teilbare Zahl
            roundedNumber = number - remainder;
        else // Runde auf die nächste größere durch 5 teilbare Zahl
            roundedNumber = number + (5 - remainder);

        return roundedNumber;
    }
    public int getGeld()
    {
        return geld;
    }

   
}
