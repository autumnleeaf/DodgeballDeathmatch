using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DodgeballDeathmatch
{
    public class Player
    {
        public Movement Movement;

        private Vector3 Position;

        private float MaxLeft;
        private float MaxRight;
        private float MaxPosy;

        public string ShootKey { get; private set; }
        public string PickupKey { get; private set; }

        public string VerticalAxisName { get; private set; }
        public string HoriztonalAxisName { get; private set; }

        public int BallCount { get; private set; }

        public List<GameObject> ReachableDodgeballs { get; private set; }

        public int Health { get; private set; }

        public int Team { get; private set; }

        public Player(Vector3 position, int team = 1, float _movementSpeed = 10f)
        {
            // Initialize Movement class
            Movement = new Movement(_movementSpeed);

            Position = position;

            MaxPosy = 8;

            BallCount = 5;

            Health = 100;

            Team = team;

            ReachableDodgeballs = new List<GameObject>();

            if (team == 1)
            {
                MaxLeft = -19;
                MaxRight = -1;

                ShootKey = "c";
                PickupKey = "v";

                HoriztonalAxisName = "Horizontal";
                VerticalAxisName = "Vertical";
            }
            else
            {
                MaxLeft = 1;
                MaxRight = 19;

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
            float xPos = Mathf.Clamp(position.x, MaxLeft, MaxRight);
            float yPos = Mathf.Clamp(position.y, -MaxPosy, MaxPosy);

            Position = new Vector3(xPos, yPos, position.z);

            // New position of player 1 after restrictions on court are placed
            return Position;
        }

        public void PickupBall()
        {
            GameObject closestBall = null;
            float shortestDistance = -1;

            foreach (GameObject dodgeball in ReachableDodgeballs)
            {
                float distance = Vector3.Distance(Position, dodgeball.transform.position);

                if(distance < shortestDistance || shortestDistance < 0){
                    closestBall = dodgeball;
                    shortestDistance = distance;
                }
            }

            UnityEngine.Object.Destroy(closestBall);

            BallCount += 1;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void ThrowBall()
        {
            BallCount -= 1;
        }

        internal void AddToReachable(GameObject dodgeball)
        {
            if (!ReachableDodgeballs.Contains(dodgeball))
            {
                ReachableDodgeballs.Add(dodgeball);
            }
        }

        internal void RemoveFromReachable(GameObject dodgeball)
        {
            var itemToRemove = ReachableDodgeballs.Single(b => b == dodgeball);
            ReachableDodgeballs.Remove(itemToRemove);
        }
    }
}
