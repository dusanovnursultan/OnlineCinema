//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineCinema.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Seats
    {
        public int IdSeats { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    
        public virtual Sessions Sessions { get; set; }
    }
}