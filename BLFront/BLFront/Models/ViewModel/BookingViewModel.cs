using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLFront.Models.ViewModel
{
    public class BookingViewModel
    {
        public Booking Booking { get; set; }

        public SelectList Package { get; set; }

        public int selectedPack { get; set; }

        public MultiSelectList Extras { get; set; }

        public List<int> selectedExtras { get; set; }
    }
}