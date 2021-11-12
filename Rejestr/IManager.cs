using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejestr
{
    public interface IManager
    {
        public void List() { }

        public void Delete(int id) { }

        public void Add() { }

        public void Edit(int id) { }
    }
}
