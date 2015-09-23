using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{	
		public float speed;
		public Text countText;
		public Text winText;
		private int count;
	
		void Start ()
		{
				count = 0;
				countText.text = "Count: 0";
				winText.text = "";
		}
	
		void FixedUpdate ()
		{
				float horizontal = Input.GetAxis ("Horizontal");
				float vertical = Input.GetAxis ("Vertical");
		
				Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);
		
				GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);
		}
	
		void OnTriggerEnter (Collider other)
		{
				//Destroy (other.gameObject);
		
				if (other.gameObject.tag == "PickUp") {
						other.gameObject.SetActive (false);
						++count;
						countText.text = "Count: " + count.ToString ();
						if (count == 12) {
								winText.text = "You Win!!";
						}
				}
		}
}
