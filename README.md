## What is it?

It's a physics-driven ragdoll-climber prototype game.
By using these controls, the player has to use the yellow spheres as an hold, and as a lever 
to generate angular motion which will allow the character “to be thrown” at the other spheres.

##Character controls:

Spacebar: the arms are put into a “relaxed / tense” state, which means that all the spring components of the joints get activated/deactivated. 
Their function is to bring the Rigidbody back to the desired target position, by applying external forces (in case of the “tense” state).

A / D: when the arms are in the “tense” state, the target position of the joints gets modified (respectively +/- 90° degree rotation). 
The result of this operation, is a sudden bending of the arm. By pressing the key again, the arm will bend again but in the opposite direction.

S: the target position of all joints is set to 0, and the result is a complete extension of both arms. 

The previous two operations work only if the arms are in the “tense” state, since in the “relaxed” state the springs are not active.

Mouse left/right click: release the “grip” of the left/right hand. They have a tag which make them kinematic (isKinematic is set to true), 
when they collide with the yellow spheres. That means they are no longer controlled by forces. This was made to simulate the hand holding onto the object. 
If the key gets clicked again, the hand release its grip, which means that the collider component will be deactivated for a short amount of time, 
and the flag isKinematic will be set back to false. This solution was chosen after I have tried to create new joints at runtime, which wasn't particularly stable.

Originally made for the physics programming course @ Master Game Dev - University of Verona

## Demo Video

[Youtube link](https://www.youtube.com/watch?v=TjCFk3woABg)
