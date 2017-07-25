using System;
using System.Runtime.Remoting.Messaging;

namespace AopSample.Helper
{
    public class CurrentContext : ICurrentContext
    {
        private static readonly string contextName = "_AopSampleContext_";

        public CurrentContext() {
            CallContext.LogicalSetData(contextName, this);
        }

        public ICurrentContext Current {
            get {
                object obj = CallContext.LogicalGetData(contextName);
                if (obj == null) {
                    throw new ApplicationException("Abioka context is empty");
                }
                return (CurrentContext)obj;
            }
        }

        public string UserName { get; set; }

        public ActionType ActionType { get; set; }
    }
}