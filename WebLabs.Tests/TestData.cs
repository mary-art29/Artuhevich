using System;
using System.Collections.Generic;
using System.Text;
using WebLabs.DAL.Data;
using WebLabs.DAL.Entities;

namespace WebLabs.Tests
{
    public class TestData
    {
        public static void FillContext(ApplicationDbContext context)
        {
            context.DishGroups.Add(new DishGroup
            { GroupName = "fake group" });
            context.AddRange(new List<Dish>
            {
                new Dish{ DishId=1, DishGroupId=1},
                new Dish{ DishId=2, DishGroupId=1},
                new Dish{ DishId=3, DishGroupId=2},
                new Dish{ DishId=4, DishGroupId=2},
                new Dish{ DishId=5, DishGroupId=3}
            });
            context.SaveChanges();
        }

        internal static IEnumerable<Dish> FillContext()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<object[]> Params()
        {
            //
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };
        }
    }
}
