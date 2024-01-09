using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Codes.John.SpaceQuest
{
    public class LoadingAnim : MonoBehaviour
    {
        public Slider slider;
        public float fillDuration;

        private float startValue;
        private float endValue;
        private float elapsedTime = 0f;

        private void Start()
        {
            // Initialize the slider values
            startValue = 0f;
            endValue = 1f;

            // Start the filling coroutine
            StartCoroutine(FillSliderOverTime());
        }

        private IEnumerator FillSliderOverTime()
        {
            while (elapsedTime < fillDuration)
            {
                // Calculate the current fill value based on the elapsed time
                float currentFill = Mathf.Lerp(startValue, endValue, elapsedTime / fillDuration);

                // Update the slider value
                slider.value = currentFill;

                // Increment the elapsed time
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            // Ensure the slider is filled completely
            slider.value = endValue;
        }
    }
}