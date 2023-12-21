using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Playerbox : MonoBehaviour
{

    //poker
    [SerializeField] private TextMeshProUGUI Geld;
    [SerializeField] private TextMeshProUGUI lastbet;
    Color lastbetcolor;

    [SerializeField] private GameObject bet1000;
    [SerializeField] private GameObject bet500;
    [SerializeField] private GameObject bet100;
    [SerializeField] private GameObject bet25;
    [SerializeField] private GameObject bet10;
    [SerializeField] private GameObject bet5;
    [SerializeField] private GameObject winbutton;
    [SerializeField] private GameObject callButton;
    [SerializeField] private GameObject allinButton;

    private Manager manager; 
    private int eigenesgeld;
    private int lastbetint;

    private bool allin = false;

    private bool active = true;

    [SerializeField] private GameObject pokerUI;
    [SerializeField] private GameObject luckyDiceUI;

    //luckDice 

    [SerializeField] private TextMeshProUGUI LDGeld;
    [SerializeField] private GameObject BetSlider;

    [SerializeField] private TextMeshProUGUI CellphoneBet;
    [SerializeField] private TextMeshProUGUI ClockBet;
    [SerializeField] private TextMeshProUGUI MusikBet;
    [SerializeField] private TextMeshProUGUI LightBet;
    [SerializeField] private TextMeshProUGUI CarBet;
    [SerializeField] private TextMeshProUGUI TrashBet; 
    void Start()
    {
        lastbet.text = lastbetint.ToString();
        manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
        lastbetcolor = lastbet.color;

    }

    public void setGeld(int geld)
    {
        this.eigenesgeld = geld;
        Geld.text = "Geld: "+ eigenesgeld.ToString();
    }

    public void setzteGeld(int Geld)
    {
        if(Geld <= eigenesgeld)
        {
            if (eigenesgeld - Geld == 0)
            {
                allin = true;
            }
            eigenesgeld -= Geld;
            Manager.addGeldmitte(Geld);
            lastbetint += Geld; 
        }

        this.Geld.text = "Geld: " + eigenesgeld.ToString();
        lastbet.text = lastbetint.ToString();


    }
    public void win()
    {
        eigenesgeld += Manager.getGeldmitte();
        this.Geld.text = "Geld: " + eigenesgeld.ToString();
        Manager.resetGeldmitte();
        manager.resetbet();
        manager.resetALLIN();
    }
    public void resetbet()
    {
        lastbetint = 0; 
        lastbet.text = lastbetint.ToString();
/**
 * 
        if (eigenesgeld < 0)
        { 
        deactivateBet();
        }
**/
        }
    public void setALLIN(bool allin)
    {
        this.allin = allin; 
    }
    public void activateallplayers()
    {
        manager.activateallplayers();
    }
    public void deactivateBet()
    {
        bet1000.GetComponent<Button>().interactable = false;
        bet500.GetComponent<Button>().interactable = false;
        bet100.GetComponent<Button>().interactable = false;
        bet25.GetComponent<Button>().interactable = false;
        bet10.GetComponent<Button>().interactable = false;
        bet5.GetComponent<Button>().interactable = false;
        winbutton.GetComponent<Button>().interactable = false;
        callButton.GetComponent<Button>().interactable = false;
        allinButton.GetComponent<Button>().interactable = false; 
        resetbet();
        active = false;
    }
    public void reactivate()
    {
        if (eigenesgeld > 0)
        {
            bet1000.GetComponent<Button>().interactable = true;
            bet500.GetComponent<Button>().interactable = true;
            bet100.GetComponent<Button>().interactable = true;
            bet25.GetComponent<Button>().interactable = true;
            bet10.GetComponent<Button>().interactable = true;
            bet5.GetComponent<Button>().interactable = true;
            winbutton.GetComponent<Button>().interactable = true;
            callButton.GetComponent<Button>().interactable = true;
            allinButton.GetComponent<Button>().interactable = true;
            active = true; 
        }
    }
    public int getlastbet()
    {
        return lastbetint;
    }
    public void Call()
    {
        
            setzteGeld(manager.gethighestbet() - lastbetint);
       
    }
    public void ALLIN()
    {
        if (eigenesgeld > 0)
        {
            allin = true;
            setzteGeld(eigenesgeld);
        }
    }
    public bool getALLIN()
    {
        return allin;
    }
    public bool isActive()
    {
        return active;
    }
    public void addGeld(int geld)
    {
        eigenesgeld += geld;
        this.Geld.text = "Geld: " + eigenesgeld.ToString();
    }
    private void lastbetcolour()
    {
        
        Color orange = new Color(1.0f, 0.5f, 0.0f);
        if (getlastbet() != manager.gethighestbet()) {
            lastbet.color = orange; 
        }
        else
        {
            lastbet.color = lastbetcolor; 
        }
    }
    public void activatePokerUI()
    {
        luckyDiceUI.SetActive(false);
        pokerUI.SetActive(true);
        Geld.text = "Geld: "+eigenesgeld.ToString(); 
    }
    public void activateLuckyDiceUI()
    {
        pokerUI.SetActive(false);
        luckyDiceUI.SetActive(true);

        LDGeld.text = "Geld: " + eigenesgeld.ToString();
        BetSlider.GetComponent<BetSlider>().resetSlider();
    }

    public int getEigenesgeld()
    {
        return eigenesgeld;
    }

    public void LDbett(string icon)
    {
        if (icon.Equals("Cellphone"))
        {
           CellphoneBet.text= BetSlider.GetComponent<BetSlider>().getCurrentBet().ToString();
        }
        else if (icon.Equals("Clock"))
        {
            ClockBet.text = BetSlider.GetComponent<BetSlider>().getCurrentBet().ToString();
        }
        else if (icon.Equals("MusikNote"))
        {
            MusikBet.text = BetSlider.GetComponent<BetSlider>().getCurrentBet().ToString();
        }
        else if (icon.Equals("Light"))
        {
            LightBet.text = BetSlider.GetComponent<BetSlider>().getCurrentBet().ToString();
          
        }
        else if (icon.Equals("Car"))
        {
            CarBet.text = BetSlider.GetComponent<BetSlider>().getCurrentBet().ToString();
           
        }
        else if (icon.Equals("Trash"))
        {
            TrashBet.text = BetSlider.GetComponent<BetSlider>().getCurrentBet().ToString();
            
        }
        eigenesgeld -= BetSlider.GetComponent<BetSlider>().getCurrentBet();
        LDGeld.text = "Geld: " + eigenesgeld.ToString();
        BetSlider.GetComponent<BetSlider>().resetSlider();
        
    }
    public void LDresetBet()
    {
        eigenesgeld += int.Parse(CellphoneBet.text)+ int.Parse(ClockBet.text)
                     + int.Parse(MusikBet.text)+ int.Parse(LightBet.text)
                     + int.Parse(CarBet.text)+ int.Parse(TrashBet.text);
        LDGeld.text = "Geld: " + eigenesgeld.ToString();


        LDreset();
        BetSlider.GetComponent<BetSlider>().resetSlider();
    }
   
    public void LDreset()
    {
        CellphoneBet.text = 0.ToString();
        ClockBet.text = 0.ToString();
        MusikBet.text = 0.ToString();
        LightBet.text = 0.ToString();
        CarBet.text = 0.ToString();
        TrashBet.text= 0.ToString();
        BetSlider.GetComponent<BetSlider>().resetSlider();
        LDGeld.text = "Geld: " + eigenesgeld.ToString();

    }
    public void LuckyDiceWin(int symbolnumber1, int symbolnumber2, int symbolnumber3)
    {
        
        int cellphone = 0;
        int musikNote = 0;
        int car = 0;
        int clock = 0;
        int light = 0;
        int trash = 0;  

        switch (symbolnumber1)
        {
            case 1:
                cellphone++;
                break;                
            case 2:
                musikNote++;
                break;
            case 3:
                car++;
                break;
            case 4:
                clock++;
                break;
            case 5:
                light++;
                break;
            case 6:
                trash++;
                break;
        }
        switch (symbolnumber2)
        {
            case 1:
                cellphone++;
                break;
            case 2:
                musikNote++;
                break;
            case 3:
                car++;
                break;
            case 4:
                clock++;
                break;
            case 5:
                light++;
                break;
            case 6:
                trash++;
                break;
        }
        switch (symbolnumber3)
        {
            case 1:
                cellphone++;
                break;
            case 2:
                musikNote++;
                break;
            case 3:
                car++;
                break;
            case 4:
                clock++;
                break;
            case 5:
                light++;
                break;
            case 6:
                trash++;
                break;
        }



       

        int win = 0;
        win += int.Parse(CellphoneBet.text)*((cellphone > 0 ? 1 : 0)+cellphone); // wenn der wert des zheichen auf das man gesetzt hat größer ist als 0 wird zu dem eigentlichen mal, dass das zeichen gewürfelt wurde 1 addiert 
        win += int.Parse(ClockBet.text) * ((clock > 0 ? 1 : 0) + clock);
        win += int.Parse(MusikBet.text) * ((musikNote > 0 ? 1 : 0) + musikNote);
        win += int.Parse(LightBet.text) * ((light > 0 ? 1 : 0) + light);
        win += int.Parse(CarBet.text) * ((car > 0 ? 1 : 0) + car);
        win += int.Parse(TrashBet.text) * ((trash > 0 ? 1 : 0) + trash);

        eigenesgeld += win; 
        Geld.text = "Geld: " + eigenesgeld.ToString();
        LDreset();
    }

    void Update()
    {
        if (isActive())
        {
            lastbetcolour();
        }
    }
}
