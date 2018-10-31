using System;
using UnityEngine;

namespace DodgeballDeathmatch
{
    public class Player
    {
        public Movement Movement;

        private float maxLeft;
        private float maxRight;
        private float maxPosy;

        public string ShootKey { get; private set; }
        public string PickupKey { get; private set; }

        public string VerticalAxisName { get; private set; }
        public string HoriztonalAxisName { get; private set; }

        public int BallCount { get; private set; }

        public Player(int team, float _movementSpeed)
        {
            // Initialize Movement class
            Movement = new Movement(_movementSpeed);

            maxPosy = 8;

            BallCount = 5;

            if(team == 1)
            {
                maxLeft = -19;
                maxRight = -1;

                ShootKey = "c";
                PickupKey = "v";

                HoriztonalAxisName = "Horizontal";
                VerticalAxisName = "Vertical";
            }
            else
            {
                maxLeft = 1;
                maxRight = 19;

                ShootKey = ".";
                PickupKey = "/";

                HoriztonalAxisName = "Horizontal2";
                VerticalAxisName = "Vertical2";
            }
        }

        // Calculates the new position of player with given inputs.
        public Vector3 CalculateNewPosition(Vector3 position, float horizontal, float vertical, float deltaTime)
        {
            // Calculates new position of character when moved
            position += Movement.Calculate(horizontal, vertical, deltaTime);

            // Statements to restrict player 1 movement on the dodgeball court
            float xPos = Mathf.Clamp(position.x, maxLeft, maxRight);
            float yPos = Mathf.Clamp(position.y, -maxPosy, maxPosy);

            // New position of player 1 after restrictions on court are placed
            return new Vector3(xPos, yPos, position.z);
        }

        public void PickupBall(){
            BallCount += 1;
        }

        public void ThrowBall()
        {
            BallCount -= 1;
        }
    }
}
