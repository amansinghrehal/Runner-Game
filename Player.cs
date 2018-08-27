public class Player:MonoBehaviour
{
	private CharacterController controller;
	private float speed=5.0f;
	private Vector3 moveVector;
	private verticalVelocity=0.0f;
	private float gravity=12.0f;
	private float animationDuration=2.0f;
	private bool isDead=false;
	private startTime;

	void Start()
	{
		//to get the CharacterController component of Player
		controller=GetComponent<CharacterController>();
		//storing start time of game
		startTime=Time.time;
	}
	void Update()
	{
		if(isDead)
		{
			return;
		}
		//restrict player to move left or right until the camera animation complete
		if(Time.time-startTime<animationDuration)
		{
			controller.Move(Vector3.forward*speed*Time.deltaTime);
			return;
		}
		moveVector=Vector3.zero;
		//checking weather player is on ground or not
		if(controller.isGrounded)
		{
			verticalVelocity=-0.1f;
		}
		else
		{	
			//set vertical velocity in case player is not on ground 
			verticalVelocity=-gravity*Time.deltaTime;
		}

		//moveVector.x=Input.GetAxisRaw("Horizontal")*speed;
      	
      	if(Input.GetMouseButton(0))
      	{
      		if(Input.mousePosition>Screen.width/2)
      		{
      			moveVector.x=speed;
      		}
      		else
      		{
      			moveVector.x=-speed;
      		}
      	}
        moveVector.y=verticalVelocity;
        movevetor.z=speed;
        //calling Move function of CharachterController with updated Vector
	    controller.Move(moveVector*Time.deltaTime);		
	}

	public void SetSpeed(float modify)
	{
		//increasing speed after level up
		speed=5.0f+modify;
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//check the name of the tag to which player collide and the distance between them 
		if(hit.point.z>transform.position.z+0.1f&&hit.gameObject.tag=="Enemy")
		{
			Death();
		}
	}
	private void Death()
	{
		isDead=true;
		//calling onDeath function of Score to set the score after game end
		GetComponent<Score>().onDeath();
	}
}