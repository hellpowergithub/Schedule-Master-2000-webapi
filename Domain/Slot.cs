using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaster.Domain
{
    public class Slot
    {

        public int Id { get; set; }

        public int SlotNumber { get; set; }

        public Slot(int id, int slotNumber)
        {
            Id = id;
            SlotNumber = slotNumber;
        }

        //public int DayId { get; set; }
        //public int TaskId { get; set; }


    }
}
