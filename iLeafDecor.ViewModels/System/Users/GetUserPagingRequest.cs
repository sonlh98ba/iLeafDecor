using iLeafDecor.ViewModels.Common;

namespace iLeafDecor.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
