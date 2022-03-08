using System;
using System.Collections.Generic;

#nullable disable

namespace DLL_Ver6
{
    public partial class RentTable
    {
        public int UserTz { get; set; }
        public int CarNum { get; set; }
        public string StartRentDate { get; set; }
        public string ReturnDate { get; set; }
        public string RealReturnDate { get; set; }
        public int OrderNum { get; set; }

        public virtual CarInfo CarNumNavigation { get; set; }
        public virtual UserTable UserTzNavigation { get; set; }
    }
}
