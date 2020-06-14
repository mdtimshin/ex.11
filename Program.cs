using System;
using System.IO;

namespace ex._11
{
    class Program
    {
        const int k = 4;
        static void Main(string[] args)
        {
            char[] text = File.ReadAllText("text(code).txt").ToCharArray();
            char[] copy = new char[text.Length];
            text.CopyTo(copy, 0);
            if (text.Length % 4 != 0)
            {
                text = new char[copy.Length + (4 - (copy.Length % 4))];
                for(int i = 0; i<copy.Length; i++)
                {
                    text[i] = copy[i];
                }
                for (int i = copy.Length; i < text.Length; i++)
                {
                    text[i] = ' ';
                }
            }
            using (StreamWriter sw = new StreamWriter("output(code).txt"))
            {
                int countGroup = 1;
                char[] group = new char[4];
                for(int i = 1; i<=text.Length/4; i++)
                {
                    group[0]=text[countGroup*4-4];
                    group[1]=text[countGroup*4-3];
                    group[2]=text[countGroup*4-2];
                    group[3]=text[countGroup*4-1];
                    sw.Write(group[2].ToString() + group[1].ToString() + group[3].ToString() + group[0].ToString());
                    countGroup++;
                }
            }


            text = File.ReadAllText("text(decode).txt").ToCharArray();
            
            using (StreamWriter sw = new StreamWriter("output(decode).txt"))
            {
                int countGroup = 1;
                char[] group = new char[4];
                for (int i = 1; i <= text.Length / 4; i++)
                {
                    group[0] = text[countGroup * 4 - 4];
                    group[1] = text[countGroup * 4 - 3];
                    group[2] = text[countGroup * 4 - 2];
                    group[3] = text[countGroup * 4 - 1];
                    sw.Write(group[3].ToString() + group[1].ToString() + group[0].ToString() + group[2].ToString());
                    countGroup++;
                }
            }
        }
    }
}
