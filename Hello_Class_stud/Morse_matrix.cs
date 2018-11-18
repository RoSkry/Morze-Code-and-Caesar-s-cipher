using System;
using System.Linq;
using System.Threading;

namespace Hello_Class_stud
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix : String_matrix, IMorse_crypt
    {
        public const int Size_2 = Alphabet.Size;
        private int offset_key = 0;


        //Implement Morse_matrix constructor with the int parameter for offset
        //Use fd(Alphabet.Dictionary_arr) and sd() method
        public Morse_matrix()
        {
            fd(Alphabet.Dictionary_arr);
        }
        public Morse_matrix(int offset = 0)
        {
            offset_key = offset;
            fd(Alphabet.Dictionary_arr);
            sd();
        }
        //Implement Morse_matrix constructor with the string [,] Dict_arr and int parameter for offset
        //Use fd(Dict_arr) and sd() methods
        public Morse_matrix(string[,] Dict_arr, int offset = 0)
        {
            fd(Dict_arr);
            offset_key = offset;
            sd();
        }

        private void fd(string[,] Dict_arr)
        {
            for (int ii = 0; ii < Size1; ii++)
                for (int jj = 0; jj < Size_2; jj++)
                    this[ii, jj] = Dict_arr[ii, jj];
        }


        private void sd()
        {
            int off = Size_2 - offset_key;
            for (int jj = 0; jj < off; jj++)
            {
                this[1, jj] = this[1, jj + offset_key];
            }
            for (int jj = off; jj < Size_2; jj++)
            {
                this[1, jj] = this[1, jj - off];
            }
        }

        //Implement Morse_matrix operator +
        public static Morse_matrix operator +(Morse_matrix matr1, Morse_matrix matr2)
        {
            Morse_matrix morse = new Morse_matrix();
            for (int i = 0; i < Size1; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    morse[i, j] = matr1[i, j] + " " + matr2[i, j];
                }
            }
            return morse;
        }

        //Realize crypt() with string parameter
        //Use indexers
        public string Crypt(string word)
        {
            int index;
            string output = "";
            foreach (char c in word)
            {

                for (int j = 0; j < Size2; j++)
                {
                    if (c.ToString() == this[0, j])
                    {
                        index = j;
                        output += this[1, j];
                        break;
                    }
                }
                //ctrl+K+D - шоткат для выравнивая кода
            }

            return output;
        }
        //Realize decrypt() with string array parameter
        //Use indexers
        public string DeCrypt(string[] signal)
        {
            int index;
            string output = "";
            foreach (string str in signal)
            {

                for (int j = 0; j < Size2; j++)
                {
                    if (str == this[1, j])
                    {
                        index = j;
                        output += this[0, j];
                        break;
                    }
                }

            }

            return output;
        }

        //Implement Res_beep() method with string parameter to beep the string
        public void Res_beep(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Console.Beep(650 + i, i + 200);
            }

        }
    }

}


