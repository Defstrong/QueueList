var queue = new Queue<int>();


queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);



foreach (var ii in queue)
    Console.WriteLine(ii);