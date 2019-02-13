using NotatnikMechanika.Database.Models;
using NotatnikMechanika.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using PropertyChanged;
using System.Collections.Generic;
using System.Windows.Input;

namespace NotatnikMechanika.ViewModels.AddOrder
{
    [AddINotifyPropertyChangedInterface]
    public class AddOrderGoodsInfoViewModel : INavigationAware
    {
        public ICommand AddGoodCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public GoodDTO Good { get; set; }

        public List<GoodDTO> Goods { get; set; }

        private IAddOrderService _addOrderService;
        private IRegionManager _regionManager;


        public AddOrderGoodsInfoViewModel(IAddOrderService addOrderService, IRegionManager regionManager)
        {
            _addOrderService = addOrderService;
            _regionManager = regionManager;
            Good = new GoodDTO();
            Goods = _addOrderService.GetGoods(Goods);

            AddGoodCommand = new DelegateCommand(AddGood);
            NextPageCommand = new DelegateCommand(NextPage);
        }

        public void AddGood()
        {
            _addOrderService.AddGood(Good);
            Goods = _addOrderService.GetGoods(Goods);
        }

        public void NextPage()
        {
            _regionManager.RequestNavigate("ContentRegion", "AddOrderInfoView");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Goods = _addOrderService.GetGoods(Goods);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            _addOrderService.AddGoods(Goods);
        }
    }
}