using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace CodeWars.CSharp.GenericCollections.BuildingGenericCode
{
    //class OperationResult
    //{

    //    public bool Success { get; }

    //    public string Message { get; }

    //    public OperationResult()
    //    {
            
    //    }

    //    public OperationResult(bool success, string message) : this()
    //    {
    //        this.Success = success;
    //        this.Message = message;
    //    }
    //}


    class  OperationResult<TSuccess, TMessage>
    {
        public TSuccess Success { get; }

        public TMessage Message { get; }

        public OperationResult(TSuccess success, TMessage message) 
        {
            this.Success = success;
            this.Message = message;
        }
    }
}
