using System;
using System.Collections.Generic;
using System.Text;

namespace ProEventos.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }


        internal void AttId(int id)
        {
            Id = id;
        }

    }

}
