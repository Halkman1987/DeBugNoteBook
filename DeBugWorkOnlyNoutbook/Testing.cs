using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeBugWorkOnlyNoutbook
{
	public class Testing
	{
		static int Iterations = 10000;
		//[Benchmark]
		/*public string UseString()
		{
			string value = "";

			for (int i = 0; i < Iterations; i++)
			{
				value += i.ToString();
				value += " ";
			}

			return value;
		}*/

        [Benchmark]
        public string UseStringBuilder()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < Iterations; i++)
            {
                builder.Append(i.ToString());
                builder.Append(" ");
            }

            return builder.ToString();
        }
       /* [Benchmark]
        public void CreateMatrix()
        {
            int n = 10000;

            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = i + j;
                }
            }
        }*/
    }
}