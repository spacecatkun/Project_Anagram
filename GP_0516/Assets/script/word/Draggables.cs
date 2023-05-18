using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggables : MonoBehaviour
{
    public bool IsDragging;
    public string word = "A";
    public Vector3 LastPosition;
    public Vector3 checkp;

    private Collider2D _collider;
    private DragController _dragController;
    private WordMKController _wordMKcontroller;
    private Rigidbody2D _rigidbody;
    private float _movemonetTime = 7f;
    private System.Nullable<Vector3> _movemonetDestination;
    public int wordindex = 0;
    public bool checkb;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
        _wordMKcontroller = FindObjectOfType<WordMKController>();
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
                _rigidbody.gravityScale = 0f;
                if (_rigidbody.gravityScale == 0f)
                {
                    transform.position = Vector3.Lerp(transform.position, _movemonetDestination.Value, _movemonetTime * Time.fixedDeltaTime);
                    checkp = _movemonetDestination.Value;
                }
            }
        }
        checkb = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Draggables collidedDraggable = other.GetComponent<Draggables>();

        if (collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }

        if(other.CompareTag("Dragin1"))
        {
            checkp = new Vector3(18.5f, 3.5f, 7.955483f);
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_1 = word;
            _collider.enabled = false;
        }
        else if (other.CompareTag("Dragin2"))
        {
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_2 = word;
            _collider.enabled = false;
        }
        else if (other.CompareTag("Dragin3"))
        {
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_3 = word;
            _collider.enabled = false;
        }
        else if (other.CompareTag("Dragin4"))
        {
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_4 = word;
            _collider.enabled = false;
        }
        else if (other.CompareTag("Dragin5"))
        {
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_5 = word;
            _collider.enabled = false;
        }
        else if (other.CompareTag("Dragnot"))
        {
            _movemonetDestination = LastPosition;
        }
    }
    private void removeword(int index)
    {
        if(index == 1)
        {
            _wordMKcontroller.word_1 = null;
        }
        else if(index == 2)
        {
            _wordMKcontroller.word_2 = null;
        }
        else if (index == 3)
        {
            _wordMKcontroller.word_3 = null;
        }
        else if (index == 4)
        {
            _wordMKcontroller.word_4 = null;
        }
        else if (index == 5)
        {
            _wordMKcontroller.word_5 = null;
        }
        else
        {
            return;
        }
    }
}
