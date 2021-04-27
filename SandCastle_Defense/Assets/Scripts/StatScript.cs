using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScript : MonoBehaviour
{
    public Text statText;

    void Start()
    {
        statText.text = "Time Survived: " + PlayerController.timePlayed.ToString() + "\n"
                     + "Number of Waves Survived: " + PlayerController.numbOfLevels.ToString() + "\n"
                     + "Number of Crabs Hit Away: " + PlayerController.crabsHit.ToString() + "\n"
                     + "Number of Trenches Dug: " + PlayerController.trenchesDug.ToString() + "\n"
                     + "Number of Bucket Uses: " + PlayerController.bucketUses.ToString() + "\n";
    }
}
