using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    float elapsedSeconds = 0;
    bool gameTimer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer)
        {
            elapsedSeconds += Time.deltaTime;
            scoreText.text = elapsedSeconds.ToString();
        }
    }
    public void StopGameTimer()
    {
        gameTimer = false;
    }
}
