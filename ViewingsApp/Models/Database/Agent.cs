using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewingsApp.Models.Database
{
    public class Agent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public bool IsFreeForViewing(DateTime viewingStart, DateTime viewingEnd)
        {
            if (viewingStart.Hour < StartTime)
            {
                return false;
            }

            if (viewingEnd.Hour > EndTime || (viewingEnd.Hour == EndTime && viewingEnd.Minute > 0))
            {
                return false;
            }

            return true;
        } 
    }
}