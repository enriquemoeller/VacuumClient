namespace IntelligentVacuum.Environments
{
    using System;
    using System.Collections.Generic;

    public class AreaMap
    {
        public AreaMap(){}
        public AreaMap(int xSize, int ySize)
        {
            var rnd = new Random();
            for (int x = 1; x <= xSize; x++)
            {
                for (int y = 1; y <= ySize; y++)
                {
                    Room room = new Room();
                    room.XAxis = x;
                    room.YAxis = y;
                    if(rnd.Next(0,90)> 90)
                    {
                        room.IsDirty = false;
                    }
                    else
                    {
                        room.IsDirty = true;
                    }
                    rooms.Add(room);
                }
            }
        }
        public List<Room> rooms = new List<Room>();
    }
}
