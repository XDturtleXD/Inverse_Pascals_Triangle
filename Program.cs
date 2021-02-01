using System;
namespace 反巴斯塔
{
    class Program
    {
        //static int k = 0;
        //static int[] arr = new int[1];//隨便啦
        static uint count = 0;
        static int[] brr;//隨便啦
        static int num;
        static UInt32 layer = 0;//層數
        static void Main()
        {
            Console.WriteLine("         Welcome!");
            Console.WriteLine("SYSTEM POWERED BY TORTOISE");
        start:
            Console.Write("Please Enter The Total Number of The Array: ");
            object obj = Console.ReadLine();
            long millis = DateTimeOffset.UtcNow.UtcTicks;
            try
            {
                Program.num = Convert.ToInt32(obj);
                Program.layer = Convert.ToUInt32((Math.Sqrt(1 + 8 * num) - 1) / 2);
                if (Program.layer != (Math.Sqrt(1 + 8 * num) - 1) / 2 && num != 0)
                {
                    Exception a = new FormatException();
                    throw a;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error: ");
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.ToString ());
                goto start;
            }

            int[] temp = new int[num];//重新定義
            for (int i = 0; i < num; i++)
            {
                temp[i] = i + 1;//填數字
            }
            Program.brr = new int[num];

            Swap(temp);
            Console.WriteLine();
            double t = (double)(DateTimeOffset.UtcNow.UtcTicks - millis) / 10000000;
            Console.WriteLine("With Total {0} Possibilitie(s)", Program.count);
            Console.WriteLine(String.Format("Processed With {0:#0.000000} Second(s) Elapsed", t));
            Console.Write("Press Any Key To Terminate...");
            Console.ReadKey();
        }
        static void Swap(int[] arr)//排列組合階乘概念
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int[] temp = new int[arr.Length - 1];
                brr[num - arr.Length] = arr[i];
                int k = 0;
                for (int j = 0; j < arr.Length; j++)//建立新數列
                {
                    if (j != i)
                    {
                        temp[k] = arr[j];
                        k++;
                    }
                }
                Swap(temp);
            }
            if (arr.Length != 0) return;//檢查是否在最底層
            /*for (int j = 0; j < num; j++)
            {
                Console.Write("{0} ", Program.brr[j]);
            }
            Console.WriteLine();//所有可能*/
            if (Program.Check())//檢查
            {
                Console.Write("Outcome {0}: ", ++Program.count);
                for (int j = 0; j < num; j++)
                {
                    Console.Write("{0} ", Program.brr[j]);
                }
                Console.WriteLine();
            }

        }
        static bool Check()
        {
            int i = 0;
            /*for (int j = 0; j < num * 2 - 1; j++)//建立數列
            {
                if (Program.arr[j] != 0)
                {
                    Program.brr[i] = Program.arr[j];
                    i++;
                }
            }*/
            for (int j = 1; j < Program.layer; j++)
            {
                for (int k = 0; k < j; k++)
                {
                    if (Program.brr[i] != Math.Abs(Program.brr[j + i] - Program.brr[j + 1 + i])) return false;
                    i++;//i=(j+2)*(j+1)/2+k，但計算起來不值得
                }
            }
            return true;
        }
    }
}
