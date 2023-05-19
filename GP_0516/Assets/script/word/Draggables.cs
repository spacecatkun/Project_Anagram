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
    private bool check_in = false;

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
                }
            }
        }
        if (_wordMKcontroller.MK_remove > 0  && check_in == true)
        {
            _wordMKcontroller.MK_remove--;
            Destroy(gameObject);
        }
        else if (_wordMKcontroller.MK_reset > 0 && check_in == true)
        {
            _wordMKcontroller.MK_reset--;
            transform.position = checkp;
            _rigidbody.gravityScale = 1f;
            _collider.enabled = true;
            check_in = false;
            _movemonetDestination = null;
        }
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
            checkp = new Vector3(18.5f, 1.5f, 0f);
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_1 = word;
            _collider.enabled = false;
            check_in = true;
            _wordMKcontroller.MK_count++;
        }
        else if (other.CompareTag("Dragin2"))
        {
            checkp = new Vector3(20.5f, 1.5f, 0f);
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_2 = word;
            _collider.enabled = false;
            check_in = true;
            _wordMKcontroller.MK_count++;
        }
        else if (other.CompareTag("Dragin3"))
        {
            checkp = new Vector3(22.5f, 1.5f, 0f);
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_3 = word;
            _collider.enabled = false;
            check_in = true;
            _wordMKcontroller.MK_count++;
        }
        else if (other.CompareTag("Dragin4"))
        {
            checkp = new Vector3(24.5f, 1.5f, 0f);
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_4 = word;
            _collider.enabled = false;
            check_in = true;
            _wordMKcontroller.MK_count++;
        }
        else if (other.CompareTag("Dragin5"))
        {
            checkp = new Vector3(26.5f, 1.5f, 0f);
            _movemonetDestination = other.transform.position;
            _wordMKcontroller.word_5 = word;
            _collider.enabled = false;
            check_in = true;
            _wordMKcontroller.MK_count++;
        }
        else if (other.CompareTag("Dragnot"))
        {
            _movemonetDestination = LastPosition;
        }
    }
}
