using UnityEngine;

namespace _App.HappyBird.Scripts
{
    public class ObjectMovevement : MonoBehaviour
    {
        void FixedUpdate()
        {
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(position.x - 0.03f, position.y, 0);
            transform1.position = position;

            if (transform.position.x <= -7.5f)
            {
                Destroy(gameObject);
            }
        }
    }
}