using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text coinText;
    public int coinCounter;
    public int playerLifesCounter=3;
    public GameObject[] playerLifes;
    public static UIManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public void DeleteLastestPlayerLife() {
        playerLifes[playerLifesCounter].SetActive(false);
    }
    public void IncreaseCoinCounterText() {
        //Debug.Log("Increase Coin Counter");
        coinCounter++;
        coinText.text = coinCounter.ToString();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
