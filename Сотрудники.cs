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
    
    public partial class Сотрудники
    {
        public int id { get; set; }
        public int id_фестиваля { get; set; }
        public string имя { get; set; }
        public string должность { get; set; }
    
        public virtual Фестиваль Фестиваль { get; set; }
    }
}
