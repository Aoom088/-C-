using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer_4_dice
{
    internal class Program
    {
        public static void Main() 
        {

            dice onedice = new dice();
            Console.WriteLine("--** dice = 1 **--");
            onedice.onedice();

            dice doubledices = new dice();
            Console.WriteLine("--** doubledices = Snake eyes **--");
            doubledices.doubledices();

        }

    }

    class dice
    {
        public void onedice()                                                   //โปรแกรมจะทดสอบการโยนลูกเต๋าจนกว่าจะได้ค่า 1 (โยนกี่ครั้ง)
        {                                                                       // โดยสุ่มตัวเลขจาก 1-6
            int mark = 0, i = 1; ;                                              //กำหนด ค่าเริ่มต้น ของตัวแปร
            dice dic1 = new dice();                                             // สร้าง อินสแตนด์ dic1 สำหรับสุ่มตัวเลขการโยนลูกเต๋า
            while (mark != 1)                                                   //ให้วนจนกว่าการโยนลูกเต๋าจะได้เลขไม่เท่ากับ 1 (ค่าเริ่มต้น 0 )
            {                                                                   // หลังจากการวนรอบจะได้ค่า 1- 6 ถ้าได้เลข 1 จะหยุดวนรอบ
                mark = dic1.Throw();                                            //เก็บค่าการโยนลูกเต๋าไว้ในตัวแปร mark
                Console.WriteLine(" {0} Mark of Dice : {1} ", i, mark);         //แสดงจำนวนครั้ง (i) และแต้ม(mark)
                System.Threading.Thread.Sleep(10);                              // หน่วงเวลาไว้เพื่อไม่ให้แต้มซ้ำกันในขณะสุ่มตัวเลข
                i = i + 1;                                                      // เพิ่มจำนวนครั้งที่โยนลูกเต๋า
            }
            Console.WriteLine("Throw of dice = 1 is : " + (i - 1) + " time ");  //สรุปการโยนลูกเต๋าให้เท่ากับ 1 ว่ากี่ครั้ง
            Console.ReadLine();
        }

        public void doubledices()                                               
        {           
            int mark1 = 0, mark2 = 0, i = 1;                                        
            dice dic1 = new dice();
            dice dic2 = new dice();
            while (mark1 != 1 || mark2 != 1 )                                                   
            {                                                                  
                mark1 = dic1.Throw();
                System.Threading.Thread.Sleep(10);
                mark2 = dic2.Throw();
                Console.WriteLine(" {0} Mark of Dice : {1} {2} ", i, mark1, mark2);      
                System.Threading.Thread.Sleep(10);                            
                i = i + 1;                                                      
            }
            Console.WriteLine("Throw of double dices = Snake eyes is : " + (i - 1) + " time ");  
            Console.ReadLine();
        }


        int Throw()
        {
            Random random = new Random(); 
            return random.Next(6)+1;
        }
    }

}
