using UnityEngine;

/// <summary>
/// Handles the rate of speed desserts fall and destroys dessert when outside of
/// player view 
/// </summary>
public class DessertFall : MonoBehaviour
{
    [SerializeField] float _moveSpeed;

    private void Update()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
        if (transform.localPosition.y < transform.parent.position.y * -1.5) 
        {
            Destroy(gameObject);
        }
    }
}
