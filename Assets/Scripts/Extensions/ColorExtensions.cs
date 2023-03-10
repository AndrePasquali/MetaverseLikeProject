using UnityEngine;

namespace Genies.Extensions
{
    public static class ColorExtensions
    {
        public static Color PickRandom(this Color color)
        {
            var pickedColor  = new Color(
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f)
            );

            return pickedColor;
        }

        public static Color SetAlpha(this Color color, float value)
        {
            var newColor = color;
            newColor.a = value;
            color = newColor;

            return color;
        }
    }
}