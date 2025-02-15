﻿using Ardalis.Specification;

namespace DataAccess.Entities.Specifications
{
    public class CinemaHallSpecifications
    {
        public class ByIds : Specification<CinemaHall>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id));
            }
        }
        public class ById : Specification<CinemaHall>
        {
            public ById(int id)
            {
                Query
                    .Where(x => id == x.Id);
            }
        }

    }
}
