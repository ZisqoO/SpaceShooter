using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameFinishedScoreText;

    
    public GameObject player;
    public Image healthBarImage;
    public Image energyBarImage;
    public Image gameOverScreen;
    public Image gameFinishedScreen;
    

    

    private static UIManager instance = null;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }
    void Start()
    {
        Activate_GameOver_Tab(false);
        Activate_GameFinished_Tab(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncraseScore()
    {
        
        scoreText.text = GameManager.Instance.scorePoint.ToString();

    }
    public void HealthBar(float amount)
    {
        healthBarImage.fillAmount = amount;

        // amount 0 olunca Game over ekraný açýp scoreu göster sonrasýnda Restar veya Quit Game seçenekleri ekrana gelmeli.
    }
    public void ShieldBar(float amount)
    {
        if(energyBarImage.fillAmount > 0)
        {
            energyBarImage.fillAmount = amount;
            Debug.Log("Amount" + energyBarImage.fillAmount);
        }
        

    }
    public void Activate_GameOver_Tab(bool isActivated)
    {
        if(isActivated) 
        {
            StartCoroutine(GameOverCoroutine());
        }
        else
        {
            gameOverScreen.gameObject.SetActive(false);
        }
    }
    public void ColorAlphaChange()
    {
        //StartCoroutine(AlphaColorChange());
        SpriteRenderer sprite = player.gameObject.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {

            sprite.enabled = false;
            new WaitForSeconds(1f);
            sprite.enabled = true;
            Debug.Log("Çalýþtý");

        }
    }
    IEnumerator AlphaColorChange()
    {
        SpriteRenderer sprite = player.gameObject.GetComponent<SpriteRenderer>();
        
        for (int i = 0; i < 3; i++)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.7f); // transparan için buradan yaz.
            sprite.enabled = false;
            new WaitForSeconds(0.25f);
            sprite.enabled = true;
            i += 1;
            Debug.Log("Çalýþtý");
            yield return new WaitForSeconds(0.25f);
        }
        
    }
    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        SoundManager.Instance.mainMusic.Stop();
        SoundManager.Instance.SoundPlayer(SoundManager.Instance.gameOverSound);
        gameOverScoreText.text = GameManager.Instance.scorePoint.ToString();
        gameOverScreen.gameObject.SetActive(true);

    }
    public void Activate_GameFinished_Tab(bool isActivated)
    {
        if (isActivated)
        {
            StartCoroutine(GameFinishedCoroutine());
        }
        else
        {
            gameFinishedScreen.gameObject.SetActive(false);
        }
    }
    IEnumerator GameFinishedCoroutine()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        SoundManager.Instance.mainMusic.Stop();
        SoundManager.Instance.SoundPlayer(SoundManager.Instance.gameFinishedSound);
        gameFinishedScoreText.text = GameManager.Instance.scorePoint.ToString();
        gameFinishedScreen.gameObject.SetActive(true);

    }
}
