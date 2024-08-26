using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daytime
{
    [ExecuteInEditMode]
    public class Daytime : MonoBehaviour
    {
        [SerializeField] private Gradient _dirLightGradient;
        [SerializeField] private Gradient _ambientLightGradient;
        [SerializeField] private Light _dirLight;
        [SerializeField, Range(1, 3600)] private float _timeDayInSecond = 60;
        [SerializeField, Range(0f, 1f)] private float _timeProgress;

        private Vector3 _defaultAngles;


        private void Start()
        {
            _defaultAngles = _dirLight.transform.localEulerAngles;
        }

        private void Update()
        {
            _timeProgress += Time.deltaTime / _timeDayInSecond;

            if (_timeProgress > 1f)
                _timeProgress = 0f;

            _dirLight.color = _dirLightGradient.Evaluate(_timeProgress);
            RenderSettings.ambientLight = _ambientLightGradient.Evaluate(_timeProgress);

            _dirLight.transform.localEulerAngles = new Vector3(360f * _timeProgress - 90, _defaultAngles.x, _defaultAngles.y);
        }
    }
}