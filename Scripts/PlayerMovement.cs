


using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;

    [SerializeField] float MaxX = 20f;
    [SerializeField]float MinX = -20f;
     [SerializeField] float MinY = -40f;
    [SerializeField] float MaxY = 60f;
    [SerializeField] float controlRotation = 20f;



    Vector2 movement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
         ProcessRotation();
    }
    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    void ProcessTranslation()
    {
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXpos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;
        float clampX = Mathf.Clamp(rawXpos, MinX, MaxX);
        float clampY = Mathf.Clamp(rawYpos, MinY, MaxY);

        transform.localPosition = new Vector3(clampX, clampY, 0f);
    }
    void ProcessRotation()
    {
        float pitch = -controlRotation * movement.y;
        float roll = -controlRotation * movement.x;

        Quaternion targetRotation =  Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, controlRotation * Time.deltaTime);
        
    }

}
