﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class TrainingProductViewModel : BaseViewModel
    {
        private readonly ITrainingProductManager _tpmgr;
        public string TestProp1 { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public string EventCommand { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public TrainingProduct Entity { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }
        private void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;
            ListMode();
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public TrainingProductViewModel(ITrainingProductManager tpmanager) : base(tpmanager)
        {
            _tpmgr = tpmanager;
            Init();
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
        }
        
        public void HandleRequest()
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
                    System.Diagnostics.Debugger.Break();
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

        private void Save()
        {

            //TrainingProductManager mgr = new TrainingProductManager();
            if (Mode == "Add")
            {
                _tpmgr.Insert(this.Entity);
            }
            ValidationErrors = _tpmgr.ValidationErrors;
            if(ValidationErrors.Count > 0 )
            {
                IsValid = false;
            }

            if (!IsValid)
            { 

                if (Mode == "Add")
                {
                    AddMode();
                }
            }
        }

        private void ListMode()
        {
            IsValid = true;
            Mode = "List";
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;
        }

        private void Add()
        {
            IsValid = true;
            Entity = new TrainingProduct()
            {
                IntroductionDate = DateTime.Now,
                Price = 0,
                Url = "http://",
            };

            AddMode();
        }

        private void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }
        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
            Get();
        }
        private void Get()
        {
            //TrainingProductManager mgr = new TrainingProductManager();
            Products = _tpmgr.Get(SearchEntity);
        }
    }
}
