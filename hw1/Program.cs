
question1(); 
Thread.Sleep(2000);
question2();

partial class Program {

// ****** question 1 ******
    static void question1(){
        //step1: create threads
        Thread th1 = new Thread(paralellThreadFunction);
        Thread th2 = new Thread(paralellThreadFunction);
        Thread th3 = new Thread(paralellThreadFunction);
        Thread th4 = new Thread(paralellThreadFunction);
        //step2: named threads
        th1.Name = "Thread 1";
        th2.Name = "Thread 2";
        th3.Name = "Thread 3";
        th4.Name = "Thread 4";
        Console.WriteLine("*********** Question 1 ***********");
        //step3: start threads
        th1.Start();
        th2.Start();
        th3.Start();
        th4.Start();
    }
    static void paralellThreadFunction(){
        Console.WriteLine(Thread.CurrentThread.Name + " is running");
    }

    
    // ****** question 2 ******
    static void question2(){
        // step1 - initialized an array
        double[] arr = arrayInitial();
        double sum = 0;
        
        // step2 - multiply each element in our array with random numbers
        for(int i = 0; i < arr.Length; i++) {
            Random rand = new Random();
            arr[i] *= rand.Next(1, 10) * 0.10;
        }

        // step3 - calculate the sum using serial way
        DateTime start = DateTime.Now;
        for(int i = 0; i < arr.Length; i++){
            sum += arr[i];
        }
        DateTime end = DateTime.Now;
        double serialTime = end.Subtract(start).TotalSeconds * 1000; //ms
        
        // step4 - calculate the sum using paralell way
        sum = 0;
        start = DateTime.Now;
        Parallel.ForEach(arr, number =>{
            sum += number;
        });
        end = DateTime.Now;
        double paralellTime = end.Subtract(start).TotalSeconds * 1000; //ms
        
        // step5 - calculate difference and print on screen
        Console.WriteLine("*********** Question 2 ***********");
        Console.WriteLine("the serial time is : " + serialTime);
        Console.WriteLine("the paralell time is : " + paralellTime);
        Console.WriteLine("the difference is : " + (serialTime - paralellTime));
    }
        static double[] arrayInitial(){
        double[] randomNumbers = new double[8];
        Random rand = new Random();

        for (int i = 0; i < randomNumbers.Length; i++) {
            randomNumbers[i] = rand.Next(1, 10); 
        }
        return randomNumbers;
    }

}