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
            this.Success = success;
        }

        public OperationResultVo(bool success, string message) : this(success)
        {
            this.Message = message;
        }

        public OperationResultVo(string message) : this(false)
        {
            this.Message = message;
        }
    }


    public class OperationResultHtmlVo : OperationResultVo
    {
        public string Html { get; set; }

        public OperationResultHtmlVo(string html) : base(true)
        {
            this.Html = html;
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
            this.Url = url;
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
            this.Value = item;
        }

        public OperationResultVo(T item, int pointsEarned) : base(true)
        {
            this.Value = item;
            this.PointsEarned = pointsEarned;
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
            this.Success = true;
            this.Value = items;
        }

        public OperationResultListVo(string message) : base(message)
        {
        }
    }
}
