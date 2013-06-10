using System;
using System.Text;

namespace RKMC.Base
{
    public class PagingValue
    {
        #region CONSTRUCTOR

        //notes:    constructor to determine paging values
        public PagingValue() { }
        public PagingValue(int PageIndex, int ReturnCount, int TotalCount)
        {
            int pageCount;
            int intOne = 0;
            int intTwo = 0;
            decimal tempCount = (Convert.ToDecimal(TotalCount) / Convert.ToDecimal(ReturnCount));


            //notes:    if total number of records is the same as the number of records returned - then total page count should be 1
            if (TotalCount == ReturnCount)
                pageCount = 1;
            else
            {
                //notes:    check for decimal to determine number of total pages
                if (tempCount.ToString().IsDecimal())
                    pageCount = Convert.ToInt32((Math.Floor(tempCount) + 1));
                else
                    pageCount = Convert.ToInt32(tempCount);
            }


            //notes:    compute paging numbers
            if (PageIndex == 1)
            {
                intOne = 1;
                intTwo = ReturnCount;
            }
            else
            {
                intOne = (ReturnCount * PageIndex) - (ReturnCount - 1);
                intTwo = (PageIndex * ReturnCount);
            }

            //notes:    determine if 2nd number is greater than the total number of records returned
            if (intTwo > TotalCount)
                intTwo = TotalCount;


            //notes:    set this object's properties
            this.FirstNumber = intOne;
            this.SecondNumber = intTwo;
            this.TotalNumber = TotalCount;
            this.TotalPages = pageCount;
        }

        #endregion


        #region PROPERTIES

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int TotalNumber { get; set; }
        public int TotalPages { get; set; }

        #endregion
    }
}