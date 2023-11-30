using UnityEngine;

namespace Magic.SpellTypes.Lightning
{
    public class LightningSegment : MonoBehaviour
    {
    
        private float _timeAlive;
        public LightningSpell LightningSpell { private get; set; }
        
        void Update()
        {
            _timeAlive += Time.deltaTime;
            if (_timeAlive >= LightningSpell.lifetime)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
