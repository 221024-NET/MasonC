using System;

namespace App {
    class Program{

        public int calculator(string str){
            int ans = 0;
            int num1 = 0;
            //int num2 = 0;
            char op = ' ';
            bool b = true;
            string[] s = new String[str.Length];
            b = Int32.TryParse(str[0].ToString(), out num1);
            if(!b) return -1;
            ans = num1;
            num1 = 0;
            for(int i = 1; i < str.Length; i++){
                b = Int32.TryParse(str[i].ToString(), out num1);
                if(!b){
                    op = str[i];
                }
                switch(op){
                    case '+':
                    {
                        ans = ans + num1;
                        break;
                    }
                    case '-':
                    {
                        ans = ans - num1;
                        break;
                    }
                    

                }
            }
            return ans;
        }

        public static int[] bubbleSort(int[] nums){
            for(int i = 0; i < nums.Length; i++){
                for(int j = 0; j < j - i - 1; j++){
                    if(nums[j] > nums[j + 1]){
                        int temp = nums[j];
                        nums[j] = nums[j+1];
                        nums[j+1] = temp;
                    }
                }
            }
            return nums;
        }
        public static void main(string[] args){
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine(calculator("3+5-9+4"));
            int[] n = { 9, 40, 56, 90, 100 };
            //foreach(int d in n) Console.Write(d + " ");
            Console.WriteLine(n);
            int[] c = bubbleSort(n);
            Console.WriteLine(c);
        }
    }
}


