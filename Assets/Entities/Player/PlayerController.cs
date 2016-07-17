using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private float xMin;
    private float xMax;
    private float padding;
	// Use this for initialization
	void Start () {
        padding = gameObject.GetComponent<Renderer>().bounds.size.x / 2;
        float distance = transform.position.z - Camera.main.transform.position.z;
	    Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 righttMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        print(padding);
        xMin = leftMost.x + padding;
        xMax = righttMost.x + padding;
	}
	
	// Update is called once per frame
	void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Move(Vector3.left *  speed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            Move(Vector3.right * speed * Time.deltaTime);
        }
	}

    private void Move(Vector3 movement) {
        transform.position += movement;

        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

}
