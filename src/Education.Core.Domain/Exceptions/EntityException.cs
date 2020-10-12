﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Education.Core.Domain.Exceptions
{
    public class EntityException : Exception
    {
        public string SourceProperty { get; set; }
        public EntityException()
        {
        }

        public EntityException(string message) : base(message)
        {
        }

        public EntityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public EntityException(string sourceProperty, string message): base(message)
        {
            SourceProperty = sourceProperty;
        }
    }
}
