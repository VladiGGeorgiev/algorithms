using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLoses
{
    class RiskWinsRiskLoses
    {
        static bool CheckExist(string[] forbidden, List<char> temp)
        {
            for (int i = 0; i < forbidden.Length; i++)
            {
                bool check = true;
                for (int j = 0; j < forbidden[i].Length; j++)
                {
                    if (forbidden[i][j] != temp[j])
                    {
                        check = false;
                    }
                }

                if (check)
                {
                    return true;
                }
                
            }

            return false;
        }
        static void Main(string[] args)
        {
            string startCombination = Console.ReadLine();
            string endCombination = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string[] forbiddenCombinations = new string[n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                forbiddenCombinations[i] = Console.ReadLine();
            }

            List<char> tempCombination = startCombination.ToList();
            var check = false;
            while (!check)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (tempCombination[i] == endCombination[i])
                    {
                        continue;
                    }
                    else if (tempCombination[i] > endCombination[i])
                    {
                        tempCombination[i]--;
                        if (CheckExist(forbiddenCombinations, tempCombination))
                        {
                            tempCombination[i]++;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    else
                    {
                        tempCombination[i]++;

                        if (CheckExist(forbiddenCombinations, tempCombination))
                        {
                            tempCombination[i]--;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }

                if (count == 0)
                {
                    count = -1;
                    break;
                }

                check = CheckExist(new string[] { endCombination }, tempCombination);
            }
            Console.WriteLine(count);
        }
    }
}
