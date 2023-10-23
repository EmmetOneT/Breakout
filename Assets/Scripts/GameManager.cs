using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
     int blocksRemaining;
     int livesRemaining = 3;

    public Text livesText;
    public Text blocksText;
    // Start is called before the first frame update
    void Start()
    {
        blocksRemaining = CountBlocksInScene();
        UpdateUI();
    }
  

    int CountBlocksInScene()
    {
       GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        return blocks.Length;
    }

    public void OnBlockDestroyed()
    {
        UpdateUI();
        blocksRemaining--;
        if (blocksRemaining <= 0)
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int maxIndex = SceneManager.sceneCountInBuildSettings;
            currentIndex++;
            if (currentIndex < maxIndex)
            {
                SceneManager.LoadScene(currentIndex);
            }
            else 
            {
                SceneManager.LoadScene(0);
            }
        }

    }

    public void OnLifeLost()
    {
        livesRemaining--;
        UpdateUI();
        if (livesRemaining <= 0)
        {
           string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }
    }

    void UpdateUI()
    {
        livesText.text = "Lives" + livesRemaining;
        blocksText.text = "Blocks" + blocksRemaining;
    }
}
