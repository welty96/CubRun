
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField]
    private InputActionReference pressAction;
    [SerializeField]
    private InputActionReference dragAction;
    [SerializeField] private float _speed;
    private float _oldMousePositionX;
    private float _eulerY;
    public float maxHp = 100;
    public float Hp;

    public delegate void OnDamageDelegate();
    public OnDamageDelegate OnDamage;

    public float rotationSpeed = 0.2f;

    private Rigidbody rb;

    public bool draggind;
    public bool beginDrag = false;

    private void Awake()
    {
        Hp = maxHp;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        pressAction.action.started += PressAction_started;
        pressAction.action.canceled += PressAction_started;
       
    }

    private void PressAction_started(InputAction.CallbackContext obj)
    {
        if (obj.ReadValueAsButton())
        {
            draggind = true;
            beginDrag = false;
        }
        else
        {
            draggind = false;
        }
    }

    private void OnEnable()
    {
        pressAction.action.Enable();
        dragAction.action.Enable();
    }

    private void OnDisable()
    {
        pressAction.action.Disable();
        dragAction.action.Disable();
    }

    void FixedUpdate()
    {      
        if (draggind)
        {
            rb.velocity = transform.forward * _speed;    
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (Hp <= 0)  
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void LateUpdate()
    {     
        if (draggind)
        {
            if (!beginDrag) 
            {
                beginDrag = true;
                _oldMousePositionX = dragAction.action.ReadValue<float>();
            }

            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            Debug.Log("DELTA X");
            _eulerY += deltaX;
            //transform.eulerAngles = new Vector3(0, _eulerY, 0);
            rb.rotation *= Quaternion.Euler(0, deltaX * Time.smoothDeltaTime * rotationSpeed, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Hp -= 20;
            OnDamage.Invoke();
            collision.gameObject.GetComponent<SpawnOnDestroyEffect>().Spawn();
            Destroy(collision.gameObject);
        }
    }
}
