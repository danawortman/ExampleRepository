using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{	
		public float speed;
		public Text text;
		private int count;
	
		void Start ()
		{
				count = 0;
				text.text = "Count: 0";
		}
	
		void FixedUpdate ()
		{
				float horizontal = Input.GetAxis ("Horizontal");
				float vertical = Input.GetAxis ("Vertical");
		
				Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);
		
				rigidbody.AddForce (movement * speed * Time.deltaTime);
		}
	
		void OnTriggerEnter (Collider other)
		{
				//Destroy (other.gameObject);
		
				if (other.gameObject.tag == "PickUp") {
						other.gameObject.SetActive (false);
						++count;
						text.text = "Count: " + count.ToString ();
				}
		}
}
