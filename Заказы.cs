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
    
    public partial class Заказы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Заказы()
        {
            this.ЗаказБилета = new HashSet<ЗаказБилета>();
        }
    
        public int id_заказа { get; set; }
        public int id_билета { get; set; }
        public int id_посетителя { get; set; }
        public string дата_брони { get; set; }
    
        public virtual Билеты Билеты { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ЗаказБилета> ЗаказБилета { get; set; }
        public virtual Посетители Посетители { get; set; }
    }
}
