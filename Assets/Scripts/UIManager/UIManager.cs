using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager UIM;
    [SerializeField] TMP_Text pointTxt;
    [SerializeField] Image hpFill;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gamePausePanel;
    [SerializeField] TMP_Text pointAkhirTxt;

    private void Awake()
    {
        UIM = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpFill.fillAmount = (float)GameManager.GM.currentHp / (float)GameManager.GM.hp;
        pointTxt.text = GameManager.GM.point.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pointAkhirTxt.text = pointTxt.text;
    }
    public void GamePause()
    {
        SoundManager.SM.SfxPlay("SFXButton");
        GameManager.GM.isPaused = true;
        gamePausePanel.SetActive(true);
    }
    public void GameUnPause()
    {
        SoundManager.SM.SfxPlay("SFXButton");
        gamePausePanel.SetActive(false);
        GameManager.GM.isPaused = false;
    }
}
