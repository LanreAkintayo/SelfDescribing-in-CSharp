using System;
using System.IO;

namespace Application{

    class Number{
        private string number;

        public Number(string _number){
            number = _number;
        }

         public int isSelfDescribing(){
            int _isSelfDescribing = 1;
            for (int i = 0; i < number.Length; i++){
                int digit = number[i] - '0';
                int indexCount = number.Count(character => character.ToString() == i.ToString());
                if (digit != indexCount){
                    _isSelfDescribing = 0;
                    break; 
                }
            }
            return _isSelfDescribing;
        }
        public string GetNumber(){
            return number;
        }

        public void SetNumber(string _newNumber){
            number = _newNumber;
        }
    }   


    class SelfDescribingNumber{

        public static void Main(string[] args){
            StreamReader file = new StreamReader("self.in");

            int testCase = Convert.ToInt32(file.ReadLine());
            string[] allTests = new string[testCase];
            int[] status = new int[testCase];

            for(int i = 0; i < testCase; i++){
                Number number = new Number(file.ReadLine());
                int _isSelfDescribing = number.isSelfDescribing();

                allTests[i] = number.GetNumber();
                status[i] = _isSelfDescribing;
            }

            for (int j = 0; j < testCase; j++){
                string currentNumber = allTests[j];
                int currentStatus = status[j];

                if(currentStatus == 1){
                    Console.WriteLine("{0} is self describing", currentNumber);
                } else if (currentStatus == 0){
                    Console.WriteLine("{0} is not self describing", currentNumber);
                }
            }

        }
    }
}