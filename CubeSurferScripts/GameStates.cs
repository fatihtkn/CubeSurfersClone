using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour
{
    [SerializeField] GameObject start_panel;
    [SerializeField] GameObject maincube;
    private string deneme;
    private void Awake()
    {
        start_panel.SetActive(true);
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void StartGame()
    {
        maincube.GetComponent<PlayerMoveControls>().speed = 1f;
        PlayerMoveControls.forward_speed = 13f;
        start_panel.SetActive(false);
       
    }
   


}
