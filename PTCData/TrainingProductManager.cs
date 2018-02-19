using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class TrainingProductManager
    {
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string,string>> ValidationErrors { get; set; }

        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();

            if(!string.IsNullOrEmpty(entity.ProductName))
            {
                if(entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be all lower case"));
                }
            }

            return (ValidationErrors.Count == 0);
        }

        public bool Insert(TrainingProduct entity)
        {
            bool ret = false;
            ret = Validate(entity);
            if(ret)
            {
                //Create Insert Code Hereeee
            }
            return ret;
        }

        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();
            ret = CreateMockData();
            if(!string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.StartsWith(entity.ProductName));
            }
            return ret;
        }

        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();
            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Extending Bootstrap with CSS, JS and JQuery",
                IntroductionDate = Convert.ToDateTime("2/15/2018"),
                Url = "https://darth-fx.com",
                Price = Convert.ToDecimal(29.00)
            });
            ret.Add(new TrainingProduct()
            {
                ProductId = 2,
                ProductName = "ReactJS",
                IntroductionDate = Convert.ToDateTime("2/17/2018"),
                Url = "https://darth-fx.com",
                Price = Convert.ToDecimal(14.00)
            });
            ret.Add(new TrainingProduct()
            {
                ProductId = 3,
                ProductName = "Angular 2.0",
                IntroductionDate = Convert.ToDateTime("2/18/2018"),
                Url = "https://darth-fx.com",
                Price = Convert.ToDecimal(9.00)
            });
            ret.Add(new TrainingProduct()
            {
                ProductId = 4,
                ProductName = "WPF for the Visual Basic Programmer - Part 1",
                IntroductionDate = Convert.ToDateTime("2/19/2018"),
                Url = "https://pluralsight.com",
                Price = Convert.ToDecimal(229.00)
            });
            ret.Add(new TrainingProduct()
            {
                ProductId = 5,
                ProductName = "WPF for the Visual Basic Programmer - Part 2",
                IntroductionDate = Convert.ToDateTime("2/19/2018"),
                Url = "https://pluralsight.com",
                Price = Convert.ToDecimal(229.00)
            });
            ret.Add(new TrainingProduct()
            {
                ProductId = 6,
                ProductName = "Extending Bootstrap with CSS, JavaScript, and jQuery",
                IntroductionDate = Convert.ToDateTime("2/20/2018"),
                Url = "https://pluralsight.com",
                Price = Convert.ToDecimal(55.99)
            });
            return ret;
        }
    }
}
