using UnityEngine;
using UnityEngine.UI;

// This script will tell you which direction you swiped in
public class SimpleSwipeDirection : MonoBehaviour
{
	//public Text InfoText;

	protected virtual void OnEnable()
	{
		// Hook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
	}

	protected virtual void OnDisable()
	{
		// Unhook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
	}

	public void OnFingerSwipe(Lean.LeanFinger finger)
	{
		//// Make sure the info text exists
		//if (InfoText != null)
		//{
			// Store the swipe delta in a temp variable
			var swipe = finger.SwipeDelta;

			if (swipe.x < -Mathf.Abs(swipe.y))
			{
				//InfoText.text = "You swiped left!";z
				//transform.Rotate(0 * Time.deltaTime, 500 * Time.deltaTime, 0 * Time.deltaTime);
				//transform.Rotate(Vector3.right * Time.deltaTime);
				//transform.Rotate(Time.deltaTime, 0, 0);
				//Update();
				//transform.eulerAngles += new Vector3 (0f, 5f, 0f);
				//Debug.Log("L");
			}

			if (swipe.x > Mathf.Abs(swipe.y))
			{
				//InfoText.text = "You swiped right!";
				//transform.Rotate(0 * Time.deltaTime, -500 * Time.deltaTime, 0 * Time.deltaTime);
				//transform.Rotate(Vector3.right * Time.deltaTime);
				//transform.eulerAngles += new Vector3 (0f, -5f, 0f);
				//Debug.Log("R");
			}

			if (swipe.y < -Mathf.Abs(swipe.x))
			{
				//InfoText.text = "You swiped down!";
			//	transform.Rotate(500 * Time.deltaTime, 0 * Time.deltaTime, 0 * Time.deltaTime);
				//Debug.Log("down");
			}

			if (swipe.y > Mathf.Abs(swipe.x))
			{
				//InfoText.text = "You swiped up!";
			//	transform.Rotate(-500 * Time.deltaTime, 0 * Time.deltaTime, 0 * Time.deltaTime);
				//Debug.Log("Up");
			}
		//}
	}

}