using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RKMC.Base
{
    public class ResponseStatus
    {
        #region CONSTRUCTOR

        public ResponseStatus() { }
        public ResponseStatus(string Message, string Description, ResponseStatusResult StatusResult)
        {
            this.Message = Message;
            this.Description = Description;
            this.ResponseStatusResult = StatusResult;
        }
        public ResponseStatus(string Message, string Description, string StackTrace, ResponseStatusResult StatusResult)
        {
            this.Message = Message;
            this.Description = Description;
            this.StackTrace = StackTrace;
            this.ResponseStatusResult = StatusResult;
        }

        #endregion


        #region PROPERTIES

        public string Message { get; set; }
        public string Description { get; set; }
        public string StackTrace { get; set; }
        public ResponseStatusResult ResponseStatusResult { get; set; }
        public string Status
        {
            get
            {
                switch (this.ResponseStatusResult)
                {
                    case Base.ResponseStatusResult.Fail:
                        return "Fail";

                    case Base.ResponseStatusResult.Success:
                        return "Success";

                    default:
                        return "Fail";
                }
            }
        }

        #endregion
    }
}