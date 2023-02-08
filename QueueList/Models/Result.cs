using QueueList.Enums;

namespace QueueList.Models
{
    class Result<T>
    {
        public StatusError Status { get; set; }
        public string TextError { get; set; }
        public bool IsSuccess { get; set; }
        public T Payload { get; set; }

    }
}
