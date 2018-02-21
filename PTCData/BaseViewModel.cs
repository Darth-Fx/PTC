using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class BaseViewModel
    {
        public ITrainingProductManager TrainingProductManager { get; set; }

        public BaseViewModel(ITrainingProductManager trainingProductManager)
        {
            this.TrainingProductManager = trainingProductManager;
        }
    }
}
