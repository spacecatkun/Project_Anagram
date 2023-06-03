using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggables_T : MonoBehaviour
{
    public bool IsDragging;
    public string word = "A";
    public Vector3 LastPosition;
    public Vector3 checkp;

    private Collider2D _collider;
    private DragController_T _dragController;
    private float _movemonetTime = 7f;
    private System.Nullable<Vector3> _movemonetDestination;
    public int wordindex = 0;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController_T>();
    }
    void FixedUpdate()
    {
        if(_movemonetDestination.HasValue)
        {
            if (IsDragging)
            {
                _movemonetDestination = null;
                return;
            }

            if(transform.position == _movemonetDestination)
            {
                gameObject.layer = Layer.Default;
                _movemonetDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _movemonetDestination.Value, _movemonetTime * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Draggables_T collidedDraggable = other.GetComponent<Draggables_T>();

        if (collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }

        if (other.CompareTag("Dragin_T"))
        {
            _movemonetDestination = other.transform.position;
            gameObject.transform.SetParent(other.transform);
            Debug.Log("click");
        }
        else if (other.CompareTag("Dragnot"))
        {
            _movemonetDestination = LastPosition;
        }
    }
}
