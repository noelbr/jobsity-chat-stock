using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobsity_chat.Models
{
    public class Room
    {
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public string RoomID { get; set; }
        public string Name { get; set; }

    }
}
