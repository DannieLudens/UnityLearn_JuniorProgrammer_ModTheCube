using UnityEngine;

/*
 * ------- Checklist 
 * [x] Change the cube's location (transform).
 * [x] Change the cube's scale.
 * [x] Change the angle at which the cube rotates.
 * [x] Change the cube’s rotation speed.
 * [x] Change the cube’s material color.
 * [x] Change the cube’s material opacity.
 * ------- Extra
 * [x] Modify any of the changes above so they change randomly each time the scene is played.
 */

public class CustomCube : MonoBehaviour
{
    [SerializeField] private MeshRenderer MeshRenderer;
    [SerializeField] private Color firstColor = new Color(1.0f, 0.0f, 0.0f, 0.5f);
    [SerializeField] private Color secondColor = new Color(0.0f, 0.0f, 1.0f, 0.5f);
    private float colorTime;
    
    void Start()
    {
        transform.position = new Vector3(3 + 4, 4, 1); // new location from the original cube
        transform.localScale = Vector3.one * Random.Range(1.3f, 4f); // new random scale from the original cube
        
        
    }
    
    void Update()
    {
        // 2 axis rotates in diff velocities
        transform.Rotate(30.0f * Time.deltaTime, 100.0f * Time.deltaTime, 0.0f, Space.Self);
        
        colorTime = colorTime + Time.deltaTime;
        float t = Mathf.PingPong(colorTime, 1.0f);
        MeshRenderer.material.color = Color.Lerp(firstColor, secondColor, t);
    }
}

