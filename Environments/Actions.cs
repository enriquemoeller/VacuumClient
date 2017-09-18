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
        public enum actions  { moveup, movedown, moveleft, moveright, clean, lookup, none};
        public Dictionary<bool, Room> ActionResult{ get; set; }

        public ActionResult AvailableActions(actions action, Room currentRoom)
        {
            actionResult.ActionSuccess = false;
            actionResult.ActionRoom = currentRoom;
            switch(action)
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
            foreach( var rooms in _map.rooms)
            {
                if(rooms.XAxis == room.XAxis && rooms.YAxis == y && actionResult.ActionSuccess == false)
                {
                    actionResult.ActionRoom = rooms;
                    actionResult.ActionSuccess = true;
                }
            }
            if(!actionResult.ActionSuccess)
            {
                actionResult.ActionRoom = room;
                Console.WriteLine("Can't move that direction");
            }
        }
        private void Movedown(Room room)
        {
            int y = room.YAxis - 1;
            foreach( var rooms in _map.rooms)
            {
                if(rooms.XAxis == room.XAxis && rooms.YAxis == y && actionResult.ActionSuccess == false)
                {
                    actionResult.ActionRoom = rooms;
                    actionResult.ActionSuccess = true;
                }
            }
            if(!actionResult.ActionSuccess)
            {
                actionResult.ActionRoom = room;
                Console.WriteLine("Can't move that direction");
            }
        }
        private void MoveLeft(Room room)
        {
            int x = room.XAxis - 1;
            foreach( var rooms in _map.rooms)
            {
                if(rooms.YAxis == room.YAxis && rooms.XAxis == x && actionResult.ActionSuccess == false) 
                {
                    actionResult.ActionRoom = rooms;
                    actionResult.ActionSuccess = true;
                }
            }
            if(!actionResult.ActionSuccess)
            {
                actionResult.ActionRoom = room;
                Console.WriteLine("Can't move that direction");
            }
        }
        private void MoveRight(Room room)
        {
            int x = room.XAxis + 1;
            foreach( var rooms in _map.rooms)
            {
                if(rooms.YAxis == room.YAxis && rooms.XAxis == x && actionResult.ActionSuccess == false)
                {
                    actionResult.ActionRoom = rooms;
                    actionResult.ActionSuccess = true;
                }
            }
            if(!actionResult.ActionSuccess)
            {
                actionResult.ActionRoom = room;
                Console.WriteLine("Can't move that direction");
            }
        }
        private void Clean(Room room)
        {
            actionResult.ActionRoom.IsDirty = false;
            actionResult.ActionSuccess = true;
        }
        private List<Room> LookUp(Room room)
        {
            int y = room.YAxis + 1;
            if(_map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y) != null)
            {
                actionResult.ActionRoom = _map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y);
                actionResult.ActionSuccess = true;
                Console.WriteLine("yay");
            }
            else{
                Console.WriteLine("boo");
            }
            return null;
        }
        private List<Room> LookDown(Room room)
        {
            int y = room.YAxis - 1;
            if(_map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y) != null)
            {
                actionResult.ActionRoom = _map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y);
                actionResult.ActionSuccess = true;
                Console.WriteLine("yay");
            }
            else{
                Console.WriteLine("boo");
            }
            return null;
        }
        private List<Room> LookRight(Room room)
        {
            int y = room.XAxis + 1;
            if(_map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y) != null)
            {
                actionResult.ActionRoom = _map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y);
                actionResult.ActionSuccess = true;
                Console.WriteLine("yay");
            }
            else{
                Console.WriteLine("boo");
            }
            return null;
        }
        private List<Room> LookLeft(Room room)
        {
            int y = room.XAxis - 1;
            if(_map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y) != null)
            {
                actionResult.ActionRoom = _map.rooms.Find(x => x.XAxis == x.XAxis && x.YAxis == y);
                actionResult.ActionSuccess = true;
                Console.WriteLine("yay");
            }
            else{
                Console.WriteLine("boo");
            }
            return null;
        }
    }
}