﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MusFestivalEntities : DbContext
    {
        private static MusFestivalEntities _context;
        public MusFestivalEntities()
            : base("name=MusFestivalEntities")
        {
        }

        public static MusFestivalEntities GetContext()
        {
            if( _context == null )
                _context = new MusFestivalEntities();
            return _context;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Билеты> Билеты { get; set; }
        public virtual DbSet<Выступления> Выступления { get; set; }
        public virtual DbSet<ВыступленияИсполнителя> ВыступленияИсполнителя { get; set; }
        public virtual DbSet<ВыступленияНаСцене> ВыступленияНаСцене { get; set; }
        public virtual DbSet<Должность> Должность { get; set; }
        public virtual DbSet<Жанр> Жанр { get; set; }
        public virtual DbSet<ЗаказБилета> ЗаказБилета { get; set; }
        public virtual DbSet<Заказы> Заказы { get; set; }
        public virtual DbSet<Исполнители> Исполнители { get; set; }
        public virtual DbSet<Место> Место { get; set; }
        public virtual DbSet<НазваниеМест> НазваниеМест { get; set; }
        public virtual DbSet<Песни> Песни { get; set; }
        public virtual DbSet<Посетители> Посетители { get; set; }
        public virtual DbSet<Роли> Роли { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<Сцены> Сцены { get; set; }
        public virtual DbSet<ТипБилета> ТипБилета { get; set; }
        public virtual DbSet<Фестиваль> Фестиваль { get; set; }
    }
}