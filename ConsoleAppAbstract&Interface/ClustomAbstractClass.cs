using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppAbstractAndInterface;

namespace ConsoleAppAbstractAndInterface
{

    //abstract class
    public abstract class ClustomAbstractClass
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public abstract int Multiply(int x, int y);
    }
        //interface
        interface ICalculator
        {
            int Substract(int x, int y);

            int Divide(int x, int y);
        }

    }

    internal class DerivedClass : ClustomAbstractClass, ICalculator
    {
        public override int Multiply(int x, int y)
        {
            return x * y;
        }
    
        public int Substract(int x, int y)
        {
            return x - y;
        }
        
        public int Divide(int x, int y)
        {
        return x / y;    
        }




    }

