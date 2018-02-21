using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class TrainingProductViewModel : BaseViewModel
    {
        public List<TrainingProduct> Products { get; set; }
        
        public TrainingProduct SearchEntity { get; set; }
        
        public TrainingProduct Entity { get; set; }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
            base.Init();
        }

        public TrainingProductViewModel(ITrainingProductManager tpmanager) : base(tpmanager)
        {}

        public override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "extra":
                    break;
                default:
                    break;
            }
            base.HandleRequest();
        }

        protected override void Delete()
        {
            TrainingProduct entity = new TrainingProduct
            {
                ProductId = Convert.ToInt32(EventArgument)
            };
            TrainingProductManager.Delete(entity);
            
            Get();

            base.Delete();
        }
        
        protected override void Add()
        {
            IsValid = true;
            Entity = new TrainingProduct()
            {
                IntroductionDate = DateTime.Now,
                Price = 0,
                Url = "http://",
            };

            base.Add();
        }

        protected override void Edit()
        {
            Entity = base.TrainingProductManager.Get(Convert.ToInt32(EventArgument));   

            base.Edit();
        }

        
        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
            Get();
            base.ResetSearch();
        }

        protected override void Save()
        {

            //TrainingProductManager mgr = new TrainingProductManager();
            if (Mode == "Add")
            {
                TrainingProductManager.Insert(this.Entity);
            }
            if (Mode == "Edit")
            {
                TrainingProductManager.Update(this.Entity);
            }
            ValidationErrors = TrainingProductManager.ValidationErrors;

            base.Save();
        }
        protected override void Get()
        {
            //TrainingProductManager mgr = new TrainingProductManager();
            Products = TrainingProductManager.Get(SearchEntity);
            base.Get();
        }
    }
}
