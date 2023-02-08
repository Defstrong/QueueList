using System.Collections;
using QueueList.Models;
using QueueList.Enums;

namespace QueueList.QueueList
{
    sealed class Queue<T> : IEnumerable<T>
    {
        public Node<T> startPoint;
        public Node<T> endPoint;
        public int Count { get; private set; }
        public bool IsEmpty { get => Count == 0; }

        public Result<bool> Enqueue(T data)
        {
            var resultEqueue = new Result<bool>() { IsSuccess = false, Payload = false };
            var nodeToAdd = new Node<T>(data);
            if(data == null)
            {
                resultEqueue.TextError += $"{nameof(data)} is empty. Please try again";
                resultEqueue.Status = StatusError.ArgumentNull;
                return resultEqueue;
            }
            if (IsEmpty)
            {
                startPoint = nodeToAdd;
                endPoint = startPoint;
            }
            else
                startPoint.Next = nodeToAdd;

            resultEqueue.IsSuccess = true;
            resultEqueue.Payload = true;
            resultEqueue.TextError = "Enqueue completed successfully";
            resultEqueue.Status = StatusError.Success;
            endPoint.Next = nodeToAdd;
            endPoint = nodeToAdd;
            Count++;
            return resultEqueue;
        }
        public Result<T> Dequeue()
        {
            var resultDequeue = new Result<T>() { IsSuccess = false };
            if (IsEmpty)
            {
                resultDequeue.TextError = "Queue is empty";
                resultDequeue.Status = StatusError.ArgumentNull;
                return resultDequeue;
            }
            resultDequeue.IsSuccess = true;
            resultDequeue.TextError = "Enqueue completed successfully";
            resultDequeue.Status = StatusError.Success;
            resultDequeue.Payload = startPoint.Data;
            startPoint = startPoint.Next;
            return resultDequeue;
        }
        public Result<T> First
        {
            get
            {
                var resultFirst = new Result<T>() { IsSuccess = false };
                if (IsEmpty)
                {
                    resultFirst.TextError = "Queue is empty";
                    resultFirst.Status = StatusError.ArgumentNull;
                    return resultFirst;
                }
                return resultFirst;
            }
        }
        public Result<T> Last
        {
            get
            {
                var resultLast = new Result<T> { IsSuccess = false };
                if (IsEmpty)
                {
                    resultLast.TextError = "Queue is empty";
                    resultLast.Status = StatusError.ArgumentNull;
                    return resultLast;
                }
                resultLast.TextError = "Get last element completed success";
                resultLast.Status = StatusError.Success;
                resultLast.Payload = endPoint.Data;
                resultLast.IsSuccess = true;
                return resultLast;
            }
        }

        public Result<bool> Clear()
        {
            Result<bool> resultClear = new Result<bool>() { IsSuccess = false, Payload = false};
            if(IsEmpty)
            {
                resultClear.TextError = "Queue is empty";
                resultClear.Status = StatusError.ArgumentNull;
                return resultClear;
            }
            startPoint = null;
            endPoint = null;
            Count = 0;
            resultClear.IsSuccess = true;
            resultClear.Status = StatusError.Success;
            resultClear.TextError = "Clear queue completed is empty";
            resultClear.Payload = true;
            return resultClear;
        }

        public bool Contains(T data)
        {
            Node<T> dupleStartPoint = startPoint;
            while (dupleStartPoint != null)
            {
                if (dupleStartPoint.Data.Equals(data))
                    return true;
                dupleStartPoint = dupleStartPoint.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var dupleStartPoint = startPoint;
            while(dupleStartPoint is not null)
            {
                yield return dupleStartPoint.Data;
                dupleStartPoint = dupleStartPoint.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }   
}
