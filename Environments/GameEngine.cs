namespace IntelligentVacuum.Environments
{
    using System;
    using System.Collections.Generic;

    public class GameEngine
    {
        private readonly AreaMap _map;
        public GameEngine(AreaMap map)
        {
            _map = map;
        }
        public enum AgentActions { MOVE_UP, MOVE_DOWN, MOVE_LEFT, MOVE_RIGHT, CLEAN, LOOK_UP, LOOK_DOWN, LOOK_RIGHT, LOOK_LEFT, NONE };

        public ActionResult DoAction(AgentActions action, Room currentRoom)
        {
            switch (action)
            {
                case AgentActions.MOVE_UP:
                    return MoveUp(currentRoom);
                case AgentActions.MOVE_DOWN:
                    return MoveDown(currentRoom);
                case AgentActions.MOVE_LEFT:
                    return MoveLeft(currentRoom);
                case AgentActions.MOVE_RIGHT:
                    return MoveRight(currentRoom);
                case AgentActions.CLEAN:
                    return Clean(currentRoom);
                case AgentActions.LOOK_UP:
                    return LookUp(currentRoom);
                case AgentActions.LOOK_DOWN:
                    return LookDown(currentRoom);
                case AgentActions.LOOK_RIGHT:
                    return LookRight(currentRoom);
                case AgentActions.LOOK_LEFT:
                    return LookLeft(currentRoom);
                case AgentActions.NONE:
                    return new ActionResult(currentRoom) { ActionSuccess = true };
            }
            return new ActionResult(currentRoom);
        }
        private ActionResult MoveUp(Room room)
        {
            int y = room.YAxis + 1;
            ActionResult result = new ActionResult(room);
            if (y >= 0 && y < _map.Rooms.GetLength(1))
            {
                result.ActionSuccess = true;
                result.CurrentRoom = _map.Rooms[room.XAxis, y];
            }
            return result;
        }
        private ActionResult MoveDown(Room room)
        {
            int y = room.YAxis + 1;
            ActionResult result = new ActionResult(room);
            if (y >= 0 && y < _map.Rooms.GetLength(1))
            {
                result.ActionSuccess = true;
                result.CurrentRoom = _map.Rooms[room.XAxis, y];
            }
            return result;
        }
        private ActionResult MoveLeft(Room room)
        {
            int x = room.XAxis - 1;
            ActionResult result = new ActionResult(room);
            if (x >= 0 && x < _map.Rooms.GetLength(0))
            {
                result.ActionSuccess = true;
                result.CurrentRoom = _map.Rooms[x, room.YAxis];
            }
            return result;
        }
        private ActionResult MoveRight(Room room)
        {
            int x = room.XAxis + 1;
            ActionResult result = new ActionResult(room);
            if (x >= 0 && x < _map.Rooms.GetLength(0))
            {
                result.ActionSuccess = true;
                result.CurrentRoom = _map.Rooms[x, room.YAxis];
            }
            return result;
        }
        private ActionResult Clean(Room room)
        {
            ActionResult result = new ActionResult(room);
            if (room.IsDirty)
            {
                room.IsDirty = false;
                result.ActionSuccess = true;
            }
            return result;
        }
        private ActionResult LookUp(Room room)
        {
            ActionResult result = new ActionResult(room);
            int y = room.YAxis + 1;
            if (y >= 0 && y < _map.Rooms.GetLength(1))
            {
                result.LookResultRoom = _map.Rooms[room.XAxis, y];
                result.ActionSuccess = true;
            }
            return result;
        }
        private ActionResult LookDown(Room room)
        {
            ActionResult result = new ActionResult(room);
            int y = room.YAxis - 1;
            if (y >= 0 && y < _map.Rooms.GetLength(1))
            {
                result.LookResultRoom = _map.Rooms[room.XAxis, y];
                result.ActionSuccess = true;
            }
            return result;
        }
        private ActionResult LookRight(Room room)
        {
            ActionResult result = new ActionResult(room);
            int x = room.XAxis + 1;
            if (x >= 0 && x < _map.Rooms.GetLength(0))
            {
                result.LookResultRoom = _map.Rooms[x, room.YAxis];
                result.ActionSuccess = true;
            }
            return result;
        }
        private ActionResult LookLeft(Room room)
        {
            ActionResult result = new ActionResult(room);
            int x = room.XAxis - 1;
            if (x >= 0 && x < _map.Rooms.GetLength(0))
            {
                result.LookResultRoom = _map.Rooms[x, room.YAxis];
                result.ActionSuccess = true;
            }
            return result;
        }
    }
}