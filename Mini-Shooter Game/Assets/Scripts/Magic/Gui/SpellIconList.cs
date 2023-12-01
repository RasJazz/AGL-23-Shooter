using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Magic.Gui
{
    [RequireComponent(typeof(RectTransform))]
    public class SpellIconList : MonoBehaviour
    {
        public PlayerSpellController spellController;
        private SpellCaster _spellCaster;
        public Image loadingImage;
        private readonly Dictionary<Spell, Image> _loadings = new();
        private RectTransform _rectTransform;
        
        // Start is called before the first frame update
        void Start()
        {
            _spellCaster = spellController.GetComponent<SpellCaster>();
            
            _rectTransform = GetComponent<RectTransform>();
            Vector2 sizeDelta = _rectTransform.sizeDelta;
                            
            int count = 0;
            foreach (SpellKeybind spellKeybind in spellController.spells)
            {
                GameObject imageObject = new GameObject();
                Image image = imageObject.AddComponent<Image>();
                image.transform.SetParent(transform);
                
                RectTransform imgTransform = image.rectTransform;
                imgTransform.anchorMin = new Vector2(1, 0.5f);
                imgTransform.anchorMax = new Vector2(1, 0.5f);
                imgTransform.pivot = new Vector2(1, 0.5f);
                imgTransform.anchoredPosition = new Vector2(-sizeDelta.x*count, 0);
                imgTransform.sizeDelta = sizeDelta;

                Image loading = Instantiate(loadingImage, image.transform);
                
                image.sprite = spellKeybind.spell.icon;
                _loadings.Add(spellKeybind.spell, loading);
                count++;
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (KeyValuePair<Spell,Image> keyValuePair in _loadings)
            {
                keyValuePair.Value.fillAmount = keyValuePair.Key.CooldownPercentRemaining(_spellCaster);
            }   
        }
    }
}
