using System.Collections.Generic;

namespace IndieVisible.Domain.ValueObjects
{
    public class OperationResultVo
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public int PointsEarned { get; set; }

        public OperationResultVo(bool success)
        {
            Success = success;
        }

        public OperationResultVo(bool success, string message) : this(success)
        {
            Message = message;
        }

        public OperationResultVo(string message) : this(false)
        {
            Message = message;
        }
    }


    public class OperationResultHtmlVo : OperationResultVo
    {
        public string Html { get; set; }

        public OperationResultHtmlVo(string html) : base(true)
        {
            Html = html;
        }
        public OperationResultHtmlVo(bool success, string message) : base(success, message)
        {
        }
    }


    public class OperationResultRedirectVo : OperationResultVo
    {
        public string Url { get; set; }

        public OperationResultRedirectVo(string url) : base(true)
        {
            Url = url;
        }
        public OperationResultRedirectVo(bool success, string message) : base(success, message)
        {
        }
    }


    public class OperationResultVo<T> : OperationResultVo
    {
        public T Value { get; set; }

        public OperationResultVo(T item) : base(true)
        {
            Value = item;
        }

        public OperationResultVo(T item, int pointsEarned) : base(true)
        {
            Value = item;
            PointsEarned = pointsEarned;
        }
        public OperationResultVo(string message) : base(message)
        {
        }
    }


    public class OperationResultListVo<T> : OperationResultVo
    {
        public IEnumerable<T> Value { get; set; }

        public OperationResultListVo(IEnumerable<T> items) : base(true)
        {
            Success = true;
            Value = items;
        }

        public OperationResultListVo(string message) : base(message)
        {
        }
    }
}
