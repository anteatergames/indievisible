using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace IndieVisible.Web.Exceptions
{
    [Serializable]
    public class CustomApplicationException : ApplicationException
    {
        private readonly string resourceName;
        private readonly IList<string> validationErrors;

        public string ResourceName
        {
            get { return this.resourceName; }
        }

        public IList<string> ValidationErrors
        {
            get { return this.validationErrors; }
        }

        public CustomApplicationException() : base()
        {

        }

        public CustomApplicationException(string message) : base(message)
        {

        }

        public CustomApplicationException(string message, Exception innerException) : base(message, innerException)
        {

        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]

        protected CustomApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.resourceName = info.GetString("CustomApplicationException.ResourceName");
            this.validationErrors = (IList<string>)info.GetValue("CustomApplicationException.ValidationErrors", typeof(IList<string>));

        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("CustomApplicationException.ResourceName", this.ResourceName);
            info.AddValue("CustomApplicationException.ValidationErrors", this.ValidationErrors, typeof(IList<string>));
        }
    }
}
