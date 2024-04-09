using UnityEngine;

namespace Commponents
{
    public class DestroyComponent : MonoBehaviour
    {
        public void DestroyCurrentObj()
        {
            Destroy(gameObject);
        }
    }
}
