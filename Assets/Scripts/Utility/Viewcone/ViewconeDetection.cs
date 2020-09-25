using UnityEngine;
using UnityEngine.Events;


public class ViewconeDetection : MonoBehaviour {

	//public GameObject AlertIcon;
	private const string ObjectTag = "Player"; // Change if you are checking for another tag.
	public Transform Character;			// Transform of the character.
	public UnityEvent OnDetected;  //Event that gets called when the tag is detected.
	public UnityEvent OnLeft;  //Event that gets called when the tag was detected but left the viewcone.
	[SerializeField] LayerMask targetLayer;


	void Start () 
	{
		//AlertIcon.SetActive (false);
		if (Character == null)
		{
			Debug.LogError (ObjectTag + " viewcone character property is not set!");
		}
	}

	public void ObjectSpotted (Collider col) 
	{
		if(col.CompareTag(ObjectTag))
		{
			RaycastHit newHit;
			Debug.DrawRay(transform.position, col.transform.position - transform.position);

			if(Physics.Raycast(new Ray(transform.position, col.transform.position - transform.position), out newHit, Mathf.Infinity))
			{
				if(newHit.collider.CompareTag(ObjectTag))
				{
					Debug.LogWarning (ObjectTag + " spotted by " + Character.name + ".");
					OnDetected.Invoke();
					//AlertIcon.SetActive (true);
				}
				else
				{
					Debug.Log (ObjectTag + " within viewcone of " + Character.name + ", but is obstructed by" + newHit.collider.name);
					//AlertIcon.SetActive (false);
				}
			}
		}
	}

	public void ObjectLeft (Collider col)
	{
		if(col.CompareTag(ObjectTag))
		{
			OnLeft.Invoke();
			//AlertIcon.SetActive (false);
		}

	}
}
