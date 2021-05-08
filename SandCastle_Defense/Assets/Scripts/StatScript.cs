using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScript : MonoBehaviour
{
    public Text statText;
    private float minutesplayed;

    void Start()
    {
        PlayerController.timePlayed = Mathf.Ceil(PlayerController.timePlayed);
        minutesplayed = PlayerController.timePlayed / 60;
        statText.text = "Time Survived: " + PlayerController.timePlayed.ToString() + "s / " + minutesplayed.ToString("F1") + " mins\n"
                     + "Number of Waves Survived: " + PlayerController.numbOfLevels.ToString() + "\n"
                     + "Number of Crabs Hit Away: " + PlayerController.crabsHit.ToString() + "\n"
                     + "Number of Trenches Dug: " + PlayerController.trenchesDug.ToString() + "\n"
                     + "Number of Bucket Uses: " + PlayerController.bucketUses.ToString() + "\n";
    }
}
