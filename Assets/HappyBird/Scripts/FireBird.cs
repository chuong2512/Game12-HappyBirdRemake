using UnityEngine;


public class FireBird : MonoBehaviour
{
    private float _time;

    void FixedUpdate()
    {
        if (_time < Time.time)
            gameObject.SetActive(false);
    }

    void OnEnable()
    {
        _time = Time.time + 0.3f;
    }
}