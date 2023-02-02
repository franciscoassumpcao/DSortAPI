using AutoMapper;
using DSortAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace DSortAPI.Helpers.Physical_Address
    {
    public class pAddressCalculator : ControllerBase
        {

        private DataContext _context;

        public pAddressCalculator(DataContext context)
            {
            _context = context;
            }

        public string pAddressCalculatorFunction(int categoryId)
            {
            Console.WriteLine("Calling paddress function with category id " + categoryId);

            switch (categoryId)
                {
                case 98:
                    // House
                    return HouseCalculator();

                case 99:
                    // Other
                    return OtherCalculator();

                default:
                    // Person
                    return PersonCalculator(categoryId);
                }

            }

        string HouseCalculator()
            {
            List<string> physicalAddressListHouse = new List<string>();
            List<int> numberAddressList = new List<int>();    

            foreach (Document d in _context.Documents)
                {
                if (d.PhisicalAddress.Split('.')[0] == "House")
                    {
                    physicalAddressListHouse.Add(d.PhisicalAddress);
                    numberAddressList.Add(int.Parse(d.PhisicalAddress.Split('.')[1]));
                    }
                }

            return physicalAddressListHouse.Count == 0 ? "House.001" : $"House.{numberAddressList.Max() + 1}";
            }

        string OtherCalculator()
            {
            List<string> physicalAddressListOther = new List<string>();
            List<int> numberAddressList = new List<int>();

            foreach (Document d in _context.Documents)
                {
                if (d.PhisicalAddress.Split('.')[0] == "Other")
                    {
                    physicalAddressListOther.Add(d.PhisicalAddress);
                    numberAddressList.Add(int.Parse(d.PhisicalAddress.Split('.')[1]));
                    }
                }

            return physicalAddressListOther.Count == 0 ? "Other.001" : $"Other.{numberAddressList.Max() + 1}";
            }
            

            string PersonCalculator(int categoryId)
                {
            Console.WriteLine("calling person calculator with category id " +categoryId);
                Person? persounFound = _context.Persons.Find(categoryId);

                if (persounFound == null) return "";

                string personFirstName = persounFound.Name.Split(' ')[0];

                List<String> physicalAddressList = new List<String>();
                List<int> numberAddressList = new List<int>();

            foreach (Document d in _context.Documents)
                {
                if (d.PhisicalAddress.Contains(personFirstName))
                    {
                    physicalAddressList.Add(d.PhisicalAddress);
                    }
                }

                if (physicalAddressList.Count == 0) return $"{personFirstName}.001";

                else
                    {
                    foreach (string add in physicalAddressList)
                        {
                        numberAddressList.Add(int.Parse(add.Split('.')[1]));
                        }

                    int maxNumberPlusOne = numberAddressList.Max() + 1;

                    return $"{personFirstName}.{maxNumberPlusOne}";

                    }
                }
            }

        }
    
    
