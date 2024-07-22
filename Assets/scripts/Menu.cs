using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Sprite sprt1;
    public Sprite sprt2;
    
    [SerializeField]
    private GameObject btn;
    private Image img;

    private void Start()
    {
        img = btn.GetComponent<Image>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void AudioBtn()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            img.sprite = sprt1;
            
        }

        else
        {
            AudioListener.volume = 1;
            img.sprite = sprt2;
        }
            
    }
}
