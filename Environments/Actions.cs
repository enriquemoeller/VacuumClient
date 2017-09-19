namespace IntelligentVacuum.Environments
{
    using System;
    using System.Collections.Generic;

    public class Actions
    {
        AreaMap _map = new AreaMap();
        ActionResult actionResult = new ActionResult();
        public Actions(AreaMap map)
        {
            _map = map;
        }
        public Actions(){}
        public enum actions { moveup, movedown, moveleft, moveright, clean, lookup, lookdown, lookright, lookleft, none };

        public ActionResult AvailableActions(actions action, Room currentRoom)
        {
            actionResult.ActionSuccess = false;
            actionResult.ActionRoom = currentRoom;
            actionResult.CurrentRoom = currentRoom;
            switch (action)
            {
                case actions.moveup:
                    MoveUp(currentRoom);
                    break;
                case actions.movedown:
                    Movedown(currentRoom);
                    break;
                case actions.moveleft:
                    MoveLeft(currentRoom);
                    break;
                case actions.moveright:
                    MoveRight(currentRoom);
                    break;
                case actions.clean:
                    Clean(currentRoom);
                    break;
                case actions.lookup:
                    LookUp(currentRoom);
                    break;
                case actions.lookdown:
                    LookDown(currentRoom);
                    break;
                case actions.lookright:
                    LookRight(currentRoom);
                    break;
                case actions.lookleft:
                    LookLeft(currentRoom);
                    break;
                case actions.none:
                    actionResult.ActionRoom = currentRoom;
                    actionResult.ActionSuccess = true;
                    break;
                default:
                    actionResult.ActionRoom = currentRoom;
                    actionResult.ActionSuccess = false;
                    break;
            }
            return actionResult;
        }
        private void MoveUp(Room room)
        {
            int y = room.YAxis + 1;
            foreach (var rooms in _map.rooms)
            {
                if (rooms.XAxis == room.XAxis && rooms.YAxis == y && actionResult.ActionSuccess == false)
                {
                    Console.WriteLine("You move into the room.");
                    actionResult.ActionRoom = rooms;
                    actionResult.ActionSuccess = true;
                    actionResult.CurrentRoom = rooms;
                }
            }
            if (!actionResult.ActionSuccess)
            {
                actionResult.CurrentRoom = room;
                Console.WriteLine("Can't move that direction.");
            }
        }
        private void Movedown(Room room)
        {
            int y = room.YAxis - 1;
            foreach (var rooms in _map.rooms)
            {
                if (rooms.XAxis == room.XAxis && rooms.YAxis == y && actionResult.ActionSuccess == false)
                {
                    Console.WriteLine("You move into the room.");
                    actionResult.ActionRoom = rooms;
                    actionResult.ActionSuccess = true;
                    actionResult.CurrentRoom = rooms;
                }
            }
            if (!actionResult.ActionSuccess)
            {
                actionResult.CurrentRoom = room;
                Console.WriteLine("Can't move that direction.");
            }
        }
        private void MoveLeft(Room room)
        {
            int x = room.XAxis - 1;
            foreach (var rooms in _map.rooms)
            {
                if (rooms.YAxis == room.YAxis && rooms.XAxis == x && actionResult.ActionSuccess == false)
                {
                    Console.WriteLine("You move into the room.");
                    actionResult.ActionRoom = rooms;
                    actionResult.ActionSuccess = true;
                    actionResult.CurrentRoom = rooms;
                }
            }
            if (!actionResult.ActionSuccess)
            {
                actionResult.CurrentRoom = room;
                Console.WriteLine("Can't move that direction.");
            }
        }
        private void MoveRight(Room room)
        {
            int x = room.XAxis + 1;
            foreach (var rooms in _map.rooms)
            {
                if (rooms.YAxis == room.YAxis && rooms.XAxis == x && actionResult.ActionSuccess == false)
                {
                    Console.WriteLine("You move into the room.");
                    actionResult.ActionRoom = rooms;
                    actionResult.ActionSuccess = true;
                    actionResult.CurrentRoom = rooms;
                }
            }
            if (!actionResult.ActionSuccess)
            {
                actionResult.CurrentRoom = room;
                Console.WriteLine("Can't move that direction.");
            }
        }
        private void Clean(Room room)
        {
            if (room.IsDirty)
            {
                Console.WriteLine("You clean the room");
                actionResult.ActionRoom.IsDirty = false;
                actionResult.ActionSuccess = true;
            }
        }
        private void LookUp(Room room)
        {
            int y = room.YAxis + 1;
            if (_map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y) != null)
            {
                actionResult.ActionRoom = _map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y);
                actionResult.ActionSuccess = true;
                Console.WriteLine("You look at the room");
            }
            else
            {
                Console.WriteLine("There is no room there");
            }
        }
        private void LookDown(Room room)
        {
            int y = room.YAxis - 1;
            if (_map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y) != null)
            {
                actionResult.ActionRoom = _map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y);
                actionResult.ActionSuccess = true;
                Console.WriteLine("You look at the room");
            }
            else
            {
                Console.WriteLine("There is no room there");
            }
        }
        private void LookRight(Room room)
        {
            int y = room.XAxis + 1;
            if (_map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y) != null)
            {
                actionResult.ActionRoom = _map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y);
                actionResult.ActionSuccess = true;
                Console.WriteLine("You look at the room");
            }
            else
            {
                Console.WriteLine("There is no room there");
            }
        }
        private void LookLeft(Room room)
        {
            int y = room.XAxis - 1;
            if (_map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y) != null)
            {
                actionResult.ActionRoom = _map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y);
                actionResult.ActionSuccess = true;
                Console.WriteLine("You look at the room");
            }
            else
            {
                Console.WriteLine("There is no room there");
            }
        }
    }
}