using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggables : MonoBehaviour
{
    public bool IsDragging;
    public string word = "A";
    public Vector3 LastPosition;

    private Collider2D _collider;
    private DragController _dragController;
    private WordMKController _wordMKcontroller;
    private float _movemonetTime = 15f;
    private System.Nullable<Vector3> _movemonetDestination;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
        _wordMKcontroller = FindObjectOfType<WordMKController>();
    }
    void FixedUpdate()
    {
        if(_movemonetDestination.HasValue)
        {
            if(IsDragging)
            {
                _wordMKcontroller.word_1 = null;
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
                _wordMKcontroller.word_1 = word;
                transform.position = Vector3.Lerp(transform.position, _movemonetDestination.Value, _movemonetTime * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Draggables collidedDraggable = other.GetComponent<Draggables>();

        if(collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }

        if(other.CompareTag("Dragin"))
        {
            _movemonetDestination = other.transform.position;
        }
        else if (other.CompareTag("Dragnot"))
        {
            _movemonetDestination = LastPosition;
        }
    }
}
