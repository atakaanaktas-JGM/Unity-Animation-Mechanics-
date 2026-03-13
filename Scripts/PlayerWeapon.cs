using UnityEngine.InputSystem;
using UnityEngine;




public class PlayerWeapon : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        processFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }
    
    public void processFiring()
    {
        foreach(GameObject laser in lasers) 
        {
        var emisionControl = laser.GetComponent<ParticleSystem>().emission;
        emisionControl.enabled = isFiring;
        }
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;

    }
    void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();

    }

    void MoveTargetPoint()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 targetPointPosition = new Vector3(mousePos.x, mousePos.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLasers()
    {
        foreach(GameObject laser in lasers) 
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
