using MVCCore.Repositories.CommonTasks;

using MVCClient.Builders.CommonTasks;
using MVCClient.ViewModels.StockTasks;

namespace MVCClient.Builders.StockTasks
{
    public class TransferOrderViewModelSelectListBuilder : ITransferOrderViewModelSelectListBuilder
    {   
        private readonly IAspNetUserRepository aspNetUserRepository;
        private readonly IAspNetUserSelectListBuilder aspNetUserSelectListBuilder;

        public TransferOrderViewModelSelectListBuilder(IAspNetUserSelectListBuilder aspNetUserSelectListBuilder,
                                    IAspNetUserRepository aspNetUserRepository)
        {            
            this.aspNetUserRepository = aspNetUserRepository;
            this.aspNetUserSelectListBuilder = aspNetUserSelectListBuilder;
        }

        public void BuildSelectLists(TransferOrderViewModel transferOrderViewModel)
        {
            transferOrderViewModel.ApproverDropDown = aspNetUserSelectListBuilder.BuildSelectListItemsForAspNetUsers(aspNetUserRepository.GetAllAspNetUsers(), transferOrderViewModel.UserID);
            transferOrderViewModel.PreparedPersonDropDown = aspNetUserSelectListBuilder.BuildSelectListItemsForAspNetUsers(aspNetUserRepository.GetAllAspNetUsers(), transferOrderViewModel.UserID);
        }

    }   
}