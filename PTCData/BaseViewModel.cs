using System.Collections.Generic;

namespace PTCData
{
    public class BaseViewModel
    {
        public ITrainingProductManager TrainingProductManager { get; set; }

        public BaseViewModel(ITrainingProductManager trainingProductManager)
        {
            this.TrainingProductManager = trainingProductManager;
            Init();
        }

        public string EventCommand { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }

        protected virtual void ListMode()
        {
            IsValid = true;
            Mode = "List";
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;
        }

        protected virtual void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;
            ListMode();
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        protected virtual void Get()
        { }

        protected void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }
        protected void EditMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Edit";
        }

        protected virtual void ResetSearch()
        {

        }

        protected virtual void Add() { AddMode(); }
        protected virtual void Edit() { EditMode(); }
        protected virtual void Delete() { ListMode(); }

        protected virtual void Save()
        {
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
                if (Mode == "Edit")
                {
                    EditMode();
                }
            }
        }
        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                case "save":
                    Save();
                    //change belonging to AddCustomValidationProductMgr feature..
                    if (IsValid)
                        Get();
                    break;

                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                default:
                    break;
            }
        }
    }
}
