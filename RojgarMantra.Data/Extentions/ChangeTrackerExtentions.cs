﻿//using System;
//using System.Data.Entity;
//using RojgarMantra.Data.Entities;

//namespace RojgarMantra.Data.Extentions
//{
//    public static class ChangeTrackerExtensions
//    {
//        public static void ApplyAuditInformation(this ChangeTracker changeTracker)
//        {
//            foreach (var entry in changeTracker.Entries())
//            {
//                if (!(entry.Entity is BaseAuditClass baseAudit)) continue;
                
//                var now = DateTime.UtcNow;
//                switch (entry.State)
//                {
//                    case EntityState.Modified:
//                        baseAudit.Created = now;
//                        baseAudit.Modified = now;
//                        break;

//                    case EntityState.Added:
//                        baseAudit.Created = now;
//                        break;
//                }
//            }
//        }
//    }
//}