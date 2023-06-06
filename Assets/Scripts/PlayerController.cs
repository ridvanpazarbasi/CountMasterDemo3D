using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Range(20, 60)] public int speedModifier;
    Rigidbody _rb;
    void Update()
    {
        if (Input.touchCount > 0 )
        {
           var  touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        var position = transform.position;
                        _rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                            position.y,
                            position.z);
                    }
                    break;
                case TouchPhase.Began:
                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                    }
                    break;
                case TouchPhase.Ended:
                    _rb.velocity = Vector3.zero;
                    break;
            }
        }
    }
}