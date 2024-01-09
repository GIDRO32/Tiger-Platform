using System;
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

        [SerializeField] private LoadingScreen _loadingScreen;
        private int _isStartedGame;

        private readonly string savePP_Play = "savePlayPP";

        private void Start()
        {
            _isStartedGame = PlayerPrefs.GetInt(savePP_Play, 0);

            if (_isStartedGame == 1)
                _loadingScreen.enabled = true;
            else
            {
                _isStartedGame = 1;
                PlayerPrefs.SetInt(savePP_Play, _isStartedGame);
                PlayerPrefs.Save();
            }

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

        private void OnApplicationPause(bool pauseStatus)
        {
            PlayerPrefs.SetInt(savePP_Play, 0);
        }
    }
}