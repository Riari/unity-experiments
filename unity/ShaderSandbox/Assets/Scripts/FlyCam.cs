using UnityEngine;

public class FlyCam : MonoBehaviour {
	public float baseSpeed = 5f;
	public float shiftMultiplier = 20.0f;
	public float shiftMaxSpeed = 500.0f;
	public float mouseSensitivity = 0.25f;
	public bool rotateOnlyIfMousedown = true;
	public bool movementStaysFlat = true;

	private Vector3 _lastMouse = new Vector3(255, 255, 255);

	void Update () {
		if (Input.GetMouseButtonDown(1))
		{
			_lastMouse = Input.mousePosition;
		}

		if (!rotateOnlyIfMousedown || (rotateOnlyIfMousedown && Input.GetMouseButton(1)))
		{
			_lastMouse = Input.mousePosition - _lastMouse ;
			_lastMouse = new Vector3(-_lastMouse.y * mouseSensitivity, _lastMouse.x * mouseSensitivity, 0 );
			_lastMouse = new Vector3(transform.eulerAngles.x + _lastMouse.x , transform.eulerAngles.y + _lastMouse.y, 0);
			transform.eulerAngles = _lastMouse;
			_lastMouse =  Input.mousePosition;
		}

		Vector3 velocity = GetBaseInput();
		if (Input.GetKey(KeyCode.LeftShift))
		{
			velocity *= shiftMultiplier;
			velocity.x = Mathf.Clamp(velocity.x, -shiftMaxSpeed, shiftMaxSpeed);
			velocity.y = Mathf.Clamp(velocity.y, -shiftMaxSpeed, shiftMaxSpeed);
			velocity.z = Mathf.Clamp(velocity.z, -shiftMaxSpeed, shiftMaxSpeed);
		}
		else
		{
			velocity *= baseSpeed;
		}
		
		velocity *= Time.deltaTime;
		if (Input.GetKey(KeyCode.Space) || (movementStaysFlat && !(rotateOnlyIfMousedown && Input.GetMouseButton(1))))
		{
			transform.Translate(velocity);
		}
		else
		{
			transform.Translate(velocity);
		}
	}

	private Vector3 GetBaseInput() {
		Vector3 velocity = new Vector3();
		if (Input.GetKey(KeyCode.W)) velocity += new Vector3(0, 0 , 1);
		if (Input.GetKey(KeyCode.S)) velocity += new Vector3(0, 0, -1);
		if (Input.GetKey(KeyCode.A)) velocity += new Vector3(-1, 0, 0);
		if (Input.GetKey(KeyCode.D)) velocity += new Vector3(1, 0, 0);
		if (Input.GetKey(KeyCode.Space)) velocity += new Vector3(0, 1, 0);
		if (Input.GetKey(KeyCode.C)) velocity += new Vector3(0, -1, 0);

		return velocity;
	}
}