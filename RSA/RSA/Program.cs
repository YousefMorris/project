using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            // Needed parameters for reading and writing in file(s)  
            FileStream Stream1;
            FileStream Stream2;
            StreamWriter Writer;
            StreamReader Reader;
            BigInt Test;
            int LoopNumber;
            string Number1;
            string Number2;
            string Result;

            // Multiply Part
            Stream1 = new FileStream("MultiplyTestCases.txt", FileMode.Open);
            Reader = new StreamReader(Stream1);

            Stream2 = new FileStream("MultiplyOutput.txt", FileMode.Append);
            Writer = new StreamWriter(Stream2);

            Test = new BigInt();

            LoopNumber = int.Parse(Reader.ReadLine());
            Reader.ReadLine();

            for (int i = 0; i < LoopNumber; i++)
            {
                Number1 = Reader.ReadLine();
                Number2 = Reader.ReadLine();
                Reader.ReadLine();

                Result = Test.Multiplication(Number1, Number2);

                Writer.WriteLine(Result);
                if (i != (LoopNumber - 1))
                    Writer.WriteLine();
            }

            Reader.Close();
            Writer.Close();

            // Add Part
            Stream1 = new FileStream("AddTestCases.txt", FileMode.Open);
            Reader = new StreamReader(Stream1);

            Stream2 = new FileStream("AddOutput.txt", FileMode.Append);
            Writer = new StreamWriter(Stream2);

            LoopNumber = int.Parse(Reader.ReadLine());
            Reader.ReadLine();

            for (int i = 0; i < LoopNumber; i++)
            {
                Number1 = Reader.ReadLine();
                Number2 = Reader.ReadLine();
                Reader.ReadLine();

                Result = Test.Addition(Number1, Number2);

                Writer.WriteLine(Result);
                if (i != (LoopNumber - 1))
                    Writer.WriteLine();
            }

            Reader.Close();
            Writer.Close();

            // Subtract Part
            Stream1 = new FileStream("SubtractTestCases.txt", FileMode.Open);
            Reader = new StreamReader(Stream1);

            Stream2 = new FileStream("SubtractOutput.txt", FileMode.Append);
            Writer = new StreamWriter(Stream2);

            LoopNumber = int.Parse(Reader.ReadLine());
            Reader.ReadLine();

            for (int i = 0; i < LoopNumber; i++)
            {
                Number1 = Reader.ReadLine();
                Number2 = Reader.ReadLine();
                Reader.ReadLine();

                Result = Test.Subtraction(Number1, Number2);

                Writer.WriteLine(Result);
                if (i != (LoopNumber - 1))
                    Writer.WriteLine();
            }

            Reader.Close();
            Writer.Close();

            ////Divid Part
            //Test = new BigInt();
            //string[] b = Test.Divide("150", "12");
            //Console.WriteLine("Q: " + b[0]);
            //Console.WriteLine("R: " + b[1]);
            //Console.WriteLine();

            ////Mod Of Power
            //string b1 = Test.ModOfPower("2", "100", "10");
            //Console.WriteLine("MOP: " + b1);
            //Console.WriteLine();

            ////Encryption Part
            //string b2 = Test.RSAEncryption("2003", "3713", "7");
            //Console.WriteLine("Encryption: " + b2);
            //Console.WriteLine();

            ////Decryption part
            //string b3 = Test.RSADecryption(b2, "3713", "2563");
            //Console.WriteLine("Decryption: " + b3);
            //Console.WriteLine();

            ////End of program
        }
    }
}
