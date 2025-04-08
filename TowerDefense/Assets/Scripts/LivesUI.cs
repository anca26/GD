using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
   
    void Update()
    {
        if(PlayerStats.lives > 0)
        {
            livesText.text = PlayerStats.lives + " HP";
        }
        else
        {
            livesText.text = "Game Over";
        }
    }
}
