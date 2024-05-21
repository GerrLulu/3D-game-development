using Player;
using System.Collections;
using UnityEngine;

namespace HomeWorkForLesson2
{
    public class HomeWorkForLesson2 : MonoBehaviour
    {
        [SerializeField] private int _x;
        [SerializeField] private int _y;
        [SerializeField] private Protagonist _protagonist;
        [SerializeField] private Color _myColor;


        private void OnGUI()
        {
            GUI.BeginGroup(new Rect(10, 10, 400, 100));
            GUI.Box(new Rect(10, 10, 400, 100), "Player Life");
            GUI.TextField(new Rect(10, 20, 40, 30), "" + _protagonist.Hp);
            GUI.HorizontalSlider(new Rect(15, 70, 380, 40), _protagonist.Hp, 0.0f, 100.0f);
            GUI.EndGroup();

            _myColor = RGBSlider(new Rect(_x, _y, 200, 20), _myColor);
        }


        private Color RGBSlider(Rect screenRect, Color rgb)
        {
            rgb.r = LabelSlider(screenRect, rgb.r, 0.0f, 1.0f, "Red");
            screenRect.y += 20;

            rgb.g = LabelSlider(screenRect, rgb.g, 0.0f, 1.0f, "Green");
            screenRect.y += 20;

            rgb.b = LabelSlider(screenRect, rgb.b, 0.0f, 1.0f, "Blue");
            screenRect.y += 20;

            rgb.a = LabelSlider(screenRect, rgb.a, 0.0f, 1.0f, "Alfa");

            return rgb;
        }

        private float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue,
            string labelText)
        {
            GUI.Label(screenRect, labelText);
            screenRect.x += screenRect.width;
            sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);

            return sliderValue;
        }
    }
}