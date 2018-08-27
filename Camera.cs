using UnityEngine;
using System.Collections;
public class Camera : MonoBehaviour
{
	private Transform lookAt;
	private Vector3 diff;
	private Vector3 moveVector;
	private float transition=0.0f;
	private float animationDuration=2.0f;
	private Vector3 animationOffset=new Vector3(0,0,5);
	void Start()
	{
		//store the position of Player in lookAt
		lookAt=GameObject.FindGameObjectWithTag("Player").transform;
		//find difference between Camera position and Player position
		diff=transform.position-look.position;
	}
	void Update()
	{
		// to keep Camera at a fix distance from the Player
		moveVector=lookAt.posotion+diff;
		//to set x(horizontal) position to zero so that when player move left or right Camera stay at fix position
		moveVector.x=0;
		//to restrict vertical camera movement between 3 and 5
		moveVector.y=Mathf.Clamp(movevector.y,3,5);
		//to check weather camera animation should continue or not
		if(transition>1.0f)
		{
			transition.position=moveVector;
		}
		else
		{
			transform.position=Vector3.Lerp(moveVector+animationOffset,moveVector,transition);
			transition+=Time.deltaTime/animationDuration;
			transform.LookAt(lookAt.position+Vector3.up);
		}
		
	}
}