using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    // [SerializeField]
    [SerializeField] GameObject RunningGameUI;
    [SerializeField] GameObject Startscreen;
    
   

    [SerializeField] GameObject button;
    [SerializeField] GameObject textplayercount;
    [SerializeField] GameObject slider;
    [SerializeField] GameObject geldslider;
    [SerializeField] GameObject geldstartscreen;
    [SerializeField] TextMeshProUGUI Gamemodetext;
    [SerializeField] GameObject gamemodeButton; 

    private int playercount;
    private int geldalle; 
    [SerializeField] Canvas canvas;

    [SerializeField] GameObject playerboxprefab;

    static int GeldinMitte; 

    GameObject[] playerScreenboxes ;

    private bool timergestartet;
    private float timer;
    private int nextroundcalled = 0;

    private string gamemode = "LuckyDice";

    [SerializeField] GameObject drawButton;
    [SerializeField] GameObject nextRoundButton;
    [SerializeField] GameObject geldMitteText;


    [SerializeField] Sprite ldcellphone;
    [SerializeField] Sprite ldmusikNote;
    [SerializeField] Sprite ldcar;
    [SerializeField] Sprite ldclock;
    [SerializeField] Sprite ldlight;
    [SerializeField] Sprite ldtrash;

    [SerializeField] GameObject LuckyDiceGameUI; 
    [SerializeField] GameObject wuerfel1;
    [SerializeField] GameObject wuerfel2;
    [SerializeField] GameObject wuerfel3;

    [SerializeField] GameObject pokerUI;
    

    float timer2;
    bool luckydicewürfelanimation; 
    private void Awake()
    {
        playerScreenboxes = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
    }
    void Start()
    {
        Geldmitte.updatetext("0");
        Startscreen.SetActive(true);
        RunningGameUI.SetActive(false);

        GameObject[] Playerbox = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        foreach (GameObject playerbox in Playerbox)
        {
            playerbox.GetComponent<Playerbox>().activatePokerUI();
        }
    }
   
    public void start()
    {
        Startscreen.SetActive(false);
        RunningGameUI.SetActive(true);

        

        playercount = slider.GetComponent<Sliderscript>().getPlayercount();
        geldalle =geldslider.GetComponent<Geldslider>().getGeld();

        /**
        button.SetActive(false);
        textplayercount.SetActive(false);
        slider.SetActive(false);
        geldslider.SetActive(false);
        geldstartscreen.SetActive(false);
        **/
        
        /**
         * 6 Spieler
Spieler1: 0	0	0		0
Spieler2: 0	0	0		180
Spieler3: 250 	0	0		45
Spieler4:-250 	0	0		-45
Spieler5: 250 	0	0		135
Spieler6: -250 	0	0		-135

5 Spieler
Spieler1: 0	0	0		0
Spieler2: 200	-100	0		90
Spieler3: -200 	-100	0		-90
Spieler4: 165 	0	0		180
Spieler5: -165	0	0		180

4 Spieler: 
Spieler1: 0	0	0		0
Spieler2: 0	0	0		180
Spieler3: -200	0	0		-90
Spieler4: 200	0	0		90

3 Spieler: 
Spieler1: 0	0	0		0
Spieler2: -200	0	0		-90
Spieler3: 200	0	0		90

2 Spieler: 
Spieler1: 0	0	0		0
Spieler2: 0	0	0		180
         **/
        switch (playercount)
        {
            case 2:
                newPlayerbox(0f, -11f, 0f, 0f);
                newPlayerbox(0f, 11f, 0f, 180f);
                break;
            case 3:
                newPlayerbox(0f, -11f, 0f, 0f);             
                newPlayerbox(200f, 0f, 0f, 90f);
                newPlayerbox(-200f, 0f, 0f, -90f);
                break;
            case 4:
              
                newPlayerbox(0f, 0f, 0f, 0f);
                newPlayerbox(200f, 0f, 0f, 90f);
                newPlayerbox(0f, 0f, 0f, 180f);
                newPlayerbox(-200f, 0f, 0f, -90f);

                break;
            case 5:
                newPlayerbox(0f, -11f, 0f, 0f);
                newPlayerbox(200f, -100f, 0f, 90f);
                newPlayerbox(165f, 0f, 0f, 180f);
                newPlayerbox(-165f, 0f, 0f, 180f);
                newPlayerbox(-200f, -100f, 0f, -90f);


                break;
            case 6:
                newPlayerbox(0f, -16f, 0f, 0f);
                newPlayerbox(265f, -30f, 0f, 45f);
                newPlayerbox(265f, 30f, 0f, 135f);
                newPlayerbox(0f, 16f, 0f, 180f);
                newPlayerbox(-265f, 30f, 0f, -135f);
                newPlayerbox(-265f, -30f, 0f, -45f);
                       
                break;

                
        }
        playerScreenboxes = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        foreach (GameObject playerScreenbox in playerScreenboxes)
        {
            playerScreenbox.SetActive(true);
            playerScreenbox.GetComponent<Playerbox>().setGeld(geldalle);
        }
        SwitchGameMode();
    }

    public void newPlayerbox(float x, float y, float z, float rotation)
    {
        Vector3 position = new Vector3(x, y, z);
        Quaternion rotationn = Quaternion.Euler(0f, 0f, rotation);

        GameObject newPrefabInstance = Instantiate(playerboxprefab, position, Quaternion.identity);
        
        newPrefabInstance.transform.SetParent(canvas.transform);



        
        newPrefabInstance.GetComponent<RectTransform>().anchoredPosition = position;
        newPrefabInstance.transform.rotation = rotationn;
        newPrefabInstance.transform.localScale = new Vector3(1f, 1f, 1f);
        //newPrefabInstance.transform.localPosition = transform.position - canvas.transform.position;
    }
    void Update()
    {
      

        timer += Time.deltaTime;  // nur dazu da um zu schauen ob der knop in der Mitte drei mal hintereinander gedrückt wurde 
        timer2 += Time.deltaTime; 
        if (timergestartet)
        {            
            if(timer>0.5f)
            {
                timergestartet = false;
                nextroundcalled = 0; 
            }
            else
            {
                if (nextroundcalled > 2)
                {
                    loadMainMenu();
                }
            }
        }
        else
        {
            timer = 0;
        }
       
    }
    public void nextround()
    {
        timergestartet = true;
        nextroundcalled++;
        GameObject[] Playerbox = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        foreach (GameObject playerbox in Playerbox)
        { 
         if(playerbox.GetComponent<Playerbox>().getlastbet() < gethighestbet()&&!playerbox.GetComponent<Playerbox>().getALLIN()) // wenn all in false ist, dann soll der spieler raus 
            {
                
                playerbox.GetComponent<Playerbox>().deactivateBet();
            }
        }
        }
    public int gethighestbet()
    {

        int highestbet = 0;
        GameObject[] Playerbox = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        foreach (GameObject playerbox in Playerbox)
        {
            //höchstes Bet finden
            if (highestbet < playerbox.GetComponent<Playerbox>().getlastbet())
            {
                highestbet = playerbox.GetComponent<Playerbox>().getlastbet();
            }
        }
        return highestbet;
    }
    public static void addGeldmitte(int geld)
    {
        GeldinMitte += geld;
        Geldmitte.updatetext(GeldinMitte.ToString());
    }

    public void resetbet()
    {
        GameObject[] Playerbox = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        foreach (GameObject playerbox in Playerbox)
        {
            playerbox.GetComponent<Playerbox>().resetbet();
        }
    }
    public void resetALLIN()
    {
        GameObject[] Playerbox = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        foreach (GameObject playerbox in Playerbox)
        {
            playerbox.GetComponent<Playerbox>().setALLIN(false);
        }
    }
    public void activateallplayers()
    {
        GameObject[] Playerbox = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        foreach (GameObject playerbox in Playerbox)
        {
            playerbox.GetComponent<Playerbox>().reactivate(); 
        }
    }
    public static int getGeldmitte()
    {
       
        return GeldinMitte; 
    }
    public static void resetGeldmitte()
    {
        GeldinMitte = 0;
        Geldmitte.updatetext("0");
    }
    public void loadMainMenu()
    {
        GameObject[] Playerbox = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        foreach (GameObject playerbox in Playerbox)
        {
            Destroy(playerbox);
        }
        resetGeldmitte();

        Startscreen.SetActive(true);
        RunningGameUI.SetActive(false);

    }

    public void Draw()
    {
        int activePlayers = 0;
        GameObject[] Playerbox = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        for (int i = 0; i < Playerbox.Length; i++)
        {
            if (!Playerbox[i].GetComponent<Playerbox>().isActive())
            {
                Playerbox[i] = null;
            }
            else
            {
                activePlayers++;
            }
        }
       
       int drawgeld = roundNumberOn5((float)GeldinMitte / activePlayers);

        foreach (GameObject playerbox in Playerbox)
        {
            if (playerbox != null)
            {
                playerbox.GetComponent<Playerbox>().addGeld(drawgeld);
            }
        }
        resetGeldmitte();
        resetbet();
        resetALLIN();

    }
    private int roundNumber(float number)
    {
        int rounded;

        if (number - Math.Floor(number) >= 0.5)
        {
            rounded = (int)Math.Ceiling(number);
        }
        else
        {
            rounded = (int)Math.Floor(number);
        }
      
        return rounded;
    }
    private int roundNumberOn5(float number)
    {
        int rounded;

        if (number % 5 >= 2.5)
        {
            rounded = (int)Math.Ceiling((float)number / 5) * 5;
        }
        else
        {
            rounded = (int)Math.Floor((float)number / 5) * 5;
        }

        return rounded;
     
    }
   
    public void SwitchGameMode()
    {
        
        GameObject[] Playerbox = GameObject.FindGameObjectsWithTag("PlayerScreenbox");
        
        if (gamemode.Equals("Poker"))
        {
            Gamemodetext.text = gamemode;
            gamemode = "LuckyDice";
            
            foreach (GameObject playerbox in Playerbox)
            {
                playerbox.GetComponent<Playerbox>().activateLuckyDiceUI();
            }
            

            pokerUI.SetActive(false);
            LuckyDiceGameUI.SetActive(true);

            gamemodeButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-135, 0);
        }
        else if (gamemode.Equals("LuckyDice")){

            Gamemodetext.text = gamemode;
            gamemode = "Poker";
            
            foreach (GameObject playerbox in Playerbox)
            {
                playerbox.GetComponent<Playerbox>().activatePokerUI();
            }

            nextRoundButton.SetActive(true);
            drawButton.SetActive(true);
            geldMitteText.SetActive(true);

            Quaternion rotationn = Quaternion.Euler(0f, 0f, -90);
            gamemodeButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-80, 0);
            gamemodeButton.transform.rotation = rotationn;

            pokerUI.SetActive(true);
            LuckyDiceGameUI.SetActive(false);
        }
    }

    public void ldwuerfeln()
    {
        if (!luckydicewürfelanimation)
        {
            luckydicewürfelanimation = true; 
            for (int i = 1; i < 20; i++)
            {
                StartCoroutine(randomsprites(i));
            }


            StartCoroutine(ldwuerfeln2(20f * 0.1f + 0.1f));
        }
    }
    public IEnumerator randomsprites(float time)
    {
        Sprite wuerfelI = getSpritebyNumber(UnityEngine.Random.Range(1, 7));
        Sprite wuerfelII = getSpritebyNumber(UnityEngine.Random.Range(1, 7));
        Sprite wuerfelIII = getSpritebyNumber(UnityEngine.Random.Range(1, 7));
       
        
            timer2 = 0;
            yield return new WaitForSeconds(0.1f* time);

            wuerfel1.GetComponent<Image>().sprite = wuerfelI;
            wuerfel2.GetComponent<Image>().sprite = wuerfelII;
            wuerfel3.GetComponent<Image>().sprite = wuerfelIII;

       
        
    }
    public IEnumerator ldwuerfeln2(float time)
    {
        yield return new WaitForSeconds(time);
        int wuerfeli = UnityEngine.Random.Range(1, 7);
        int wuerfelii = UnityEngine.Random.Range(1, 7);
        int wuerfeliii = UnityEngine.Random.Range(1, 7);

        Sprite wuerfelI = getSpritebyNumber(wuerfeli);
        Sprite wuerfelII = getSpritebyNumber(wuerfelii);
        Sprite wuerfelIII = getSpritebyNumber(wuerfeliii);

       
        wuerfel1.GetComponent<Image>().sprite = wuerfelI;
        wuerfel2.GetComponent<Image>().sprite = wuerfelII;
        wuerfel3.GetComponent<Image>().sprite = wuerfelIII;
       

        foreach (GameObject playerScreenbox in playerScreenboxes)
        {
           
            playerScreenbox.GetComponent<Playerbox>().LuckyDiceWin(wuerfeli,wuerfelii,wuerfeliii);
           
        }

        luckydicewürfelanimation = false; 
    }

    public Sprite getSpritebyNumber(int number)
    {
        switch (number)
        {
            case 1:
                return ldcellphone;                
            case 2:
                return ldmusikNote; 
            case 3:
                return ldcar; 
            case 4:
                return ldclock; 

            case 5:
                return ldlight; 
            case 6:
                return ldtrash; 
        }
        return null; 
    }
}
