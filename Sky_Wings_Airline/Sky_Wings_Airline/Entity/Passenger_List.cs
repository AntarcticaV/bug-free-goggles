//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sky_Wings_Airline.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Passenger_List
    {
        public int IDFlight { get; set; }
        public int IDUser { get; set; }
        public Nullable<int> SeatOnThePlane { get; set; }
    
        public virtual Flight Flight { get; set; }
        public virtual Users Users { get; set; }
    }
}