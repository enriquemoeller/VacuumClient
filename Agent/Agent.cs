namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {
        private Sensor _sensor;
        private Stack<AgentAction> _plan;
        public Agent(Sensor sensor)
        {
            this._sensor = sensor;
            this._plan = new Stack<AgentAction>();
        }

        public AgentAction DecideAction(Room room)
        {
            AgentAction action;

            if (!this._plan.TryPop(out action))
            {
                BuildPlan(room);
                if (!this._plan.TryPop(out action))
                {
                    action = AgentAction.NONE;
                }
            }
            // if (_previousAction == action) {
            //     if (_previousRoom == room) {
            //         _lockedRooms.Add(room);
            //     }
            // }

            // _previousAction = action;

            #region First Assignment Homework
            // bool isDirty = room.IsDirty;

            // if (isDirty)
            // {
            //     action = AgentAction.CLEAN;
            // }

            // else
            // {
            //     List<int> moveSet = new List<int> { 0, 1, 2, 3 };
                
            //     Random rnd = new Random();

            //     if (room.YAxis == 0)
            //     {
            //         moveSet.Remove(0);
            //     }
                
            //     if (room.XAxis == 0)
            //     {
            //         moveSet.Remove(2);
            //     }

            //     int index = rnd.Next(0, moveSet.Count);

            //     int direction = moveSet[index];
            
            //     action = (AgentAction)direction;
            // }
            #endregion
            return action;
        }

        public void BuildPlan(Room room)
        {
            var explored = new HashSet<Room>();
            var frontier = new Queue<GraphNode>();
            var node = new GraphNode(room, null, AgentAction.NONE);

            frontier.Enqueue(node);

            do
            {
                if (!frontier.TryDequeue(out node))
                {
                    return;
                }
                List<GraphNode> newNodes = Explore(node);
                explored.Add(node.Room);
                newNodes.RemoveAll(n => explored.Contains(n.Room));
                foreach(var newNode in newNodes)
                {
                    frontier.Enqueue(newNode);
                }
                
            } while (!node.Room.IsDirty);

            _plan.Clear();
            _plan.Push(AgentAction.CLEAN);

            while(node.Parent != null)
            {
                _plan.Push(node.Action);
                node = node.Parent;
            }
        }

        private List<GraphNode> Explore(GraphNode node)
        {
            List<GraphNode> discovered = new List<GraphNode>();
            AgentAction[] moveActions = new AgentAction[] {
                AgentAction.MOVE_UP, AgentAction.MOVE_RIGHT, AgentAction.MOVE_DOWN, AgentAction.MOVE_LEFT
            };

            foreach (var action in moveActions)
            {
                GraphNode newNode = Transition(node, action);
                if (newNode != null)
                {
                    discovered.Add(newNode);
                }
            }

            return discovered;
        }

        private GraphNode Transition(GraphNode node, AgentAction action)
        {
            Room newRoom = null;
            Room currentRoom = node.Room;
            switch (action)
            {
                case AgentAction.MOVE_DOWN:
                    newRoom = _sensor.SenseRoom(currentRoom.XAxis, currentRoom.YAxis + 1);
                    break;
                case AgentAction.MOVE_UP:
                    newRoom = _sensor.SenseRoom(currentRoom.XAxis, currentRoom.YAxis - 1);
                    break;
                case AgentAction.MOVE_LEFT:
                    newRoom = _sensor.SenseRoom(currentRoom.XAxis - 1, currentRoom.YAxis);
                    break;
                case AgentAction.MOVE_RIGHT:
                    newRoom = _sensor.SenseRoom(currentRoom.XAxis + 1, currentRoom.YAxis);
                    break;
            }

            if (newRoom != null && newRoom.IsLocked)
            {
                newRoom = null;
            }

            GraphNode newNode = null;
            if (newRoom != null)
            {
                newNode = new GraphNode(newRoom, node, action);
            }
            return newNode;
        }
    }
}