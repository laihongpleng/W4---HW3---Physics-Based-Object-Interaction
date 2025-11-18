using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// public class GoalDetector : MonoBehaviour
// {
//     public ParticleSystem goalParticles;
//     public TextMeshProUGUI goalText;

//     private int goalCount = 0;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Ball"))
//         {
//             // Play Particle
//             goalParticles.Play();

//             // Add goal
//             goalCount++;

//             // Show Text
//             goalText.gameObject.SetActive(true);
//             goalText.text = "GOAL " + goalCount;
//             FindObjectOfType<TimerManager>().WinGame();


//             Debug.Log("GOAL!!!");
//         }
//     }
// }
public class GoalDetector : MonoBehaviour
{
    public ParticleSystem goalParticles;
    public TextMeshProUGUI goalText;

    private int goalCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            goalParticles.Play();

            goalCount++;

            goalText.gameObject.SetActive(true);
            goalText.text = "GOAL " + goalCount;

            StopAllCoroutines();
            StartCoroutine(FadeOutText());

            FindObjectOfType<TimerManager>().WinGame();
        }
    }

    IEnumerator FadeOutText()
    {
        Color c = goalText.color;
        c.a = 1f;
        goalText.color = c;

        yield return new WaitForSeconds(1f);

        float duration = 1.5f;
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, t / duration);
            goalText.color = c;
            yield return null;
        }

        goalText.gameObject.SetActive(false);
    }
}