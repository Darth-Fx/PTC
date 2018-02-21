using System.Collections.Generic;

namespace PTCData
{
    public interface ITrainingProductManager
    {
        List<TrainingProduct> Products { get; set; }
        List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        List<TrainingProduct> Get(TrainingProduct entity);
        bool Insert(TrainingProduct entity);
        bool Validate(TrainingProduct entity);
    }
}