using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour {
    [SerializeField] private List<TextMeshProUGUI> motivationalTexts;
    [SerializeField] private float displayDuration = 2f;
    [SerializeField] private float delayBetweenTexts = 1f;

    private int currentIndex = 0;

    private void Start()
    {
        // Ensure all texts start inactive
        foreach (var text in motivationalTexts)
        {
            text.gameObject.SetActive(false);
        }

        // Start the cycle
        StartCoroutine(CycleMotivationalTexts());
    }

    private IEnumerator CycleMotivationalTexts()
    {
        while (true)
        {
            // Activate the current text
            TextMeshProUGUI currentText = motivationalTexts[currentIndex];
            currentText.gameObject.SetActive(true);

            yield return new WaitForSeconds(displayDuration);

            // Deactivate the current text
            currentText.gameObject.SetActive(false);

            // Move to the next text
            currentIndex = (currentIndex + 1) % motivationalTexts.Count;

            yield return new WaitForSeconds(delayBetweenTexts);
        }
    }
}

