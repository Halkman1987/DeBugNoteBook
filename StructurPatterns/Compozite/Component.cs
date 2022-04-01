using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurPatterns.Compozite
{
    abstract class Component //общий интерфейс для всех
                             //компонентов древовидной струк-ры

    {
        public readonly string Name;
        protected Component(string name)
        {
            Name = name;
        }
        public abstract void Display();
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
    }
}
