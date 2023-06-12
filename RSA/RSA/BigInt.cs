using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class BigInt
    {
        //Subtraction Two Big Intgers
        public string Subtraction(string NumberOne, string NumberTwo)
        {
            string Result = "";
            int Number1_len = NumberOne.Length;
            int Number2_len = NumberTwo.Length;

            if (Number1_len == 0 && Number2_len == 0)
                Result = "0";
            else if (Number1_len != 0 && Number2_len == 0)
                Result = NumberOne;
            else if (Number1_len >= Number2_len)
            {
                char[] Temp1 = NumberOne.ToCharArray();
                Array.Reverse(Temp1);
                NumberOne = new string(Temp1);

                char[] Temp2 = NumberTwo.ToCharArray();
                Array.Reverse(Temp2);
                NumberTwo = new string(Temp2);

                int Borrow = 0;

                for (int i = 0;i< Number2_len;i++)
                {
                    int Subtraction = ((int)(NumberOne[i] - '0') - (int)(NumberTwo[i] - '0') - Borrow);

                    if (Subtraction < 0)
                    {
                        Subtraction = Subtraction + 10;
                        Borrow = 1;
                    }
                    else
                        Borrow = 0;
                    Result += (char)(Subtraction + '0'); 
                }

                for(int i=Number2_len;i<Number1_len;i++)
                {
                    int Subtraction = ((int)(NumberOne[i] - '0') - Borrow);

                    if (Subtraction < 0)
                    {
                        Subtraction = Subtraction + 10;
                        Borrow = 1;
                    }
                    else
                        Borrow = 0;
                    Result += (char)(Subtraction + '0');
                }

                char[] Temp3 = Result.ToCharArray();
                Array.Reverse(Temp3);
                Result = new string(Temp3);

               Temp1 = NumberOne.ToCharArray();
                Array.Reverse(Temp1);
                NumberOne = new string(Temp1);

                Temp2 = NumberTwo.ToCharArray();
                Array.Reverse(Temp2);
                NumberTwo = new string(Temp2);
            }

            Result = Result.TrimStart(new Char[] { '0' });
            if (Result == "")
                return "0";
            else
                return Result;
        }

        //Add Two Big Intgers
        public string Addition(string a,string b)
        {
            string res = "";
            int carry = 0;
            string diff = "";
            
            if (a.Length > b.Length)
            {
                for (int i = 0; i < Math.Abs(a.Length - b.Length); i++)
                {
                    diff += '0';
                }
                b = diff + b;
            }
            if (b.Length > a.Length)
            {
                for (int i = 0; i < Math.Abs(a.Length - b.Length); i++)
                {
                    diff += '0';
                }
                a = diff + a;
            }
            char[] chares = new char[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                chares[i] = '0';
            }
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int firstdigit = a[i] - '0';
                int seconddigit = b[i] - '0';
                int sum = firstdigit + seconddigit + carry;
                if (sum >= 10)
                {
                    carry = 1;
                    int sres = sum - 10;
                    chares[i] = (char)(sres + '0');
                }
                else
                {
                    carry = 0;
                    chares[i] = (char)(sum + '0');
                }
            }
            if (carry == 1)
            {
                res += '1';
                for (int i = 0; i < a.Length; i++)
                    res += chares[i];
            }
            else
            {
                for (int i = 0; i < a.Length; i++)
                    res += chares[i];
            }

            res = res.TrimStart(new Char[] { '0' });
            if (res == "")
                return "0";
            else
                return res;
        }

        //Multiplication Two Big Intgers
        public string Multiplication(string NumberOne, string NumberTwo)
        {
            MakeEqual(ref NumberOne, ref NumberTwo);

            if (NumberOne.Length == 1 && NumberTwo.Length == 1)
                return (int.Parse(NumberOne) * int.Parse(NumberTwo)).ToString();

            int CurrentPosition = GetCurrentPosition(NumberOne, NumberTwo);

            string FirstNumberFirstPart = GetFirstPart(NumberOne, CurrentPosition);
            string FirstNumberSecondPart = GetSecondPart(NumberOne, CurrentPosition);

            string SecondNumberFirstPart = GetFirstPart(NumberTwo, CurrentPosition);
            string SecondNumberSecondPart = GetSecondPart(NumberTwo, CurrentPosition);

            string Mul1 = Multiplication(FirstNumberFirstPart, SecondNumberFirstPart);
            string Mul2 = Multiplication(FirstNumberSecondPart, SecondNumberSecondPart);

            string Mul1_Mul2 = Multiplication(Addition(FirstNumberFirstPart, FirstNumberSecondPart), Addition(SecondNumberFirstPart, SecondNumberSecondPart));
            int pad = FirstNumberSecondPart.Length + SecondNumberSecondPart.Length;

            return ResultCalculation(Mul1, Mul2, Mul1_Mul2, pad);
        }

        public int GetCurrentPosition (string NumberOne, string NumberTwo)
        {
            int Minimum = Math.Min(NumberOne.Length, NumberTwo.Length);

            if (Minimum == 1)
                return 1;
            if (Minimum % 2 == 0)
                return Minimum / 2;
            else
                return Minimum / 2 + 1;
        }

        public string GetFirstPart (string Number , int CurrentPosition)
        {
            return Number.Remove(Number.Length - CurrentPosition);
        }

        public string GetSecondPart(string Number, int CurrentPosition)
        {
            return Number.Substring(Number.Length - CurrentPosition);
        }

        public string ResultCalculation (string Mul1, string Mul2, string Mul1_Mul2, int Pad)
        {
            string Temp1 = Subtraction(Subtraction(Mul1_Mul2, Mul1), Mul2);
            string Temp2 = Temp1.PadRight(Temp1.Length + Pad / 2, '0');
            string Temp3 = Mul1.PadRight(Mul1.Length + Pad, '0');
            string Result = Addition(Addition(Temp2, Temp3), Mul2);

            Result = Result.TrimStart(new Char[] { '0' });
            if (Result == "")
                return "0";
            else
                return Result;
        }

        public void MakeEqual(ref string NumberOne, ref string NumberTwo)
        {
            int Number1_len = NumberOne.Length;
            int Number2_len = NumberTwo.Length;

            if (Number1_len < Number2_len)
            {
                for (int i = 0; i < Number2_len - Number1_len; i++)
                    NumberOne = '0' + NumberOne;
            }
            else if (Number1_len > Number2_len)
            {
                for (int i = 0; i < Number1_len - Number2_len; i++)
                    NumberTwo = '0' + NumberTwo;
            }
        }

        //Divid Two Big Integers
        public string[] Divide(string NumberOne, string NumberTwo)
        {
            string[] Result;

            if (NumberOne.Length < NumberTwo.Length)
            {
                Result = new string[] { "0", NumberOne };
                return Result;
            }
            else if (NumberOne.Length == NumberTwo.Length)
            {
                for (int i = 0; i < NumberTwo.Length; i++)
                {
                    if (NumberOne[i] < NumberTwo[i])
                        return new string[] { "0", NumberOne };
                    else if (NumberOne[i] > NumberTwo[i])
                        break;
                }
            }

            string M1 = Multiplication(NumberTwo, "2");
            Result = Divide(NumberOne, M1);
            Result[0] = Multiplication(Result[0], "2");

            if(Result[1].Length < NumberTwo.Length)
                return Result;
            else if (Result[1].Length == NumberTwo.Length)
            {
                string Temp = Result[1];

                for(int i = 0; i < NumberTwo.Length;i++)
                {
                    if (Temp[i] < NumberTwo[i])
                        return Result;
                    else if (Temp[i] > NumberTwo[i])
                        break;
                }

                string M2 = Addition(Result[0], "1");
                string M3 = Subtraction(Result[1], NumberTwo);
                Result[0] = M2;
                Result[1] = M3;
                
                return Result;               
            }
            else
            {
                string M2 = Addition(Result[0], "1");
                string M3 = Subtraction(Result[1], NumberTwo);
                Result[0] = M2;
                Result[1] = M3;
                return Result;
            }
        }
        
        //Mod Of Powers
        public string ModOfPower(string NumberOne, string NumberTwo, string Power)
        {
            string R1 = "0";

            if (Power == "0")
                return "1";

            string [] Back = Divide(Power, "2"); 

            if(Back[1] == "0")
            {
                string M1 = ModOfPower(NumberOne, NumberTwo, Back[0]);
                R1 = Multiplication(M1, M1);
            }
            else
            {
                string M3 = ModOfPower(NumberOne, NumberTwo, Back[0]);
                R1 = Multiplication(M3, M3);
                R1 = Multiplication(R1, NumberOne);
            }

            string[] R2 = Divide(R1, NumberTwo);

            return R2[1];
        }

        //RSA Encryption
        public string RSAEncryption(string M, string N, string E)
        {
            return ModOfPower(M, N, E);
        }

        //RSA Decryption
        public string RSADecryption(string EM, string N, string d)
        {
            return ModOfPower(EM, N, d);
        }
    }
}