//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using RojgarMantra.Data;
//using RojgarMantra.Data.Entities;

//namespace RojgarMantra.Repo
//{
//    public class DataRepository<T> : IRepository<T> where T : BaseAuditClass  
//    {  
//        private readonly DataContext context;  
//        private DbSet<T> entities;  
//        string errorMessage = string.Empty;  
  
//        public DataRepository(DataContext context)  
//        {  
//            this.context = context;  
//            entities = context.Set<T>();  
//        }
//        public IEnumerable<T> GetPage(int page, int pageSize)
//        {
//            return entities.Skip(0).Take(pageSize).AsEnumerable();
//        }
//        public IEnumerable<T> GetAll()  
//        {  
//            return entities.AsEnumerable();  
//        }  
  
//        public T Get(int id)  
//        {  
//            return entities.SingleOrDefault(s => s.Id == id);  
//        }  
//        public void Insert(T entity)  
//        {  
//            if (entity == null)  
//            {  
//                throw new ArgumentNullException("entity");  
//            }  
//            entities.Add(entity);  
//            context.SaveChanges();  
//        }  
  
//        public void Update(T entity)  
//        {  
//            if (entity == null)  
//            {  
//                throw new ArgumentNullException("entity");  
//            }  
//            context.SaveChanges();  
//        }  
  
//        public void Delete(T entity)  
//        {  
//            if (entity == null)  
//            {  
//                throw new ArgumentNullException("entity");  
//            }  
//            entities.Remove(entity);  
//            context.SaveChanges();  
//        }  
//        public void Remove(T entity)  
//        {  
//            if (entity == null)  
//            {  
//                throw new ArgumentNullException("entity");  
//            }  
//            entities.Remove(entity);              
//        }
        
//        public void SaveChanges()  
//        {  
//            context.SaveChanges();  
//        }

//        public int Count()
//        {
//            return entities.Count();
//        }
//    }
//}