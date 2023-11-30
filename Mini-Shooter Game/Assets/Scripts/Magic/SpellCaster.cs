using Unity.VisualScripting;
using UnityEngine;

namespace Magic
{
    public class SpellCaster : MonoBehaviour
    {

        public Transform spellOrigin;

        public Transform aimOrientation;

        public Rigidbody casterRigidbody;

        public void OrientationOrRaycast(out Vector3 position, out Quaternion rotation)
        {
            Debug.DrawRay(aimOrientation.position, aimOrientation.TransformDirection(Vector3.forward), Color.magenta, 500, false);
            if (Physics.Raycast(aimOrientation.position, aimOrientation.TransformDirection(Vector3.forward), out RaycastHit hit))
            {
                position = spellOrigin.position;
                Debug.DrawLine(position, hit.point, Color.blue, 500, false);
                rotation = Quaternion.FromToRotation(Vector3.forward, hit.point - position);
                return;
            }
            
            position = spellOrigin.position;
            rotation = aimOrientation.rotation;
        }
        
    }
}