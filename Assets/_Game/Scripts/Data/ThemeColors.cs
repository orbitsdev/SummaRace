using UnityEngine;

namespace SummaRace.Data
{
    [CreateAssetMenu(fileName = "ThemeColors", menuName = "SummaRace/Theme Colors")]
    public class ThemeColors : ScriptableObject
    {
        [Header("Primary Palette")]
        public Color skyDark = new Color(0.051f, 0.278f, 0.631f);
        public Color skyMid = new Color(0.259f, 0.647f, 0.961f);
        public Color skyLight = new Color(0.529f, 0.808f, 0.922f);
        public Color ice = new Color(0.878f, 0.941f, 1.0f);
        public Color snow = Color.white;
        public Color frost = new Color(0.690f, 0.769f, 0.871f);

        [Header("Feedback")]
        public Color correct = new Color(0.0f, 0.749f, 0.647f);
        public Color wrong = new Color(0.937f, 0.325f, 0.314f);
        public Color highlight = new Color(1.0f, 0.843f, 0.0f);
        public Color disabled = new Color(0.690f, 0.745f, 0.773f);

        [Header("Scene 01 Accent")]
        public Color accent = new Color(0.482f, 0.408f, 0.933f);

        [Header("Avatar Colors")]
        public Color avatarFox = new Color(1.0f, 0.541f, 0.396f);
        public Color avatarFrog = new Color(0.506f, 0.780f, 0.518f);
        public Color avatarDog = new Color(0.565f, 0.792f, 0.976f);
        public Color avatarPig = new Color(0.957f, 0.561f, 0.694f);

        [Header("Button States")]
        public Color buttonActive = new Color(0.118f, 0.533f, 0.898f);
        public Color buttonDisabled = new Color(0.690f, 0.745f, 0.773f);
        public Color buttonText = Color.white;
    }
}