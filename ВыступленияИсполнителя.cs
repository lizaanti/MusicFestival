//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicFestival
{
    using System;
    using System.Collections.Generic;
    
    public partial class ВыступленияИсполнителя
    {
        public int id { get; set; }
        public Nullable<int> id_исполнителя { get; set; }
        public Nullable<int> id_песни { get; set; }
        public Nullable<int> id_выступления { get; set; }
    
        public virtual Выступления Выступления { get; set; }
        public virtual Исполнители Исполнители { get; set; }
        public virtual Песни Песни { get; set; }
    }
}
