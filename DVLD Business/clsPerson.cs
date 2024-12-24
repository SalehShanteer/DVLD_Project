using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsPerson
    {

        private enum enMode { AddNew, Update }

        private enMode _Mode;

        public int ID { get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public bool Gender { get; set; }// Male : true | Female : false
        public DateTime DateOfBirth { get; set; }
        public byte Age { get; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public clsCountry Country { get; set; }
        public string ImagePath { get; set; }

        public clsPerson()
        {
            this.ID = -1;
            this.NationalNumber = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.Gender = false;
            this.DateOfBirth = DateTime.MinValue;
            this.Age = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.Country = null;
            this.ImagePath = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsPerson(int iD, string nationalNumber, string firstName, string secondName, string thirdName
            , string lastName, bool gender, DateTime dateOfBirth, byte age, string address, string phone
            , string email, clsCountry countryID, string imagePath)
        {
            ID = iD;
            NationalNumber = nationalNumber;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Age = age;
            Address = address;
            Phone = phone;
            Email = email;
            Country = countryID;
            ImagePath = imagePath;

            _Mode = enMode.Update;
        }


        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddNewPerson(this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.Gender, this.DateOfBirth, this.Address, this.Phone, this.Email, this.Country.ID, this.ImagePath);
            return this.ID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.ID, this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.Gender, this.DateOfBirth, this.Address, this.Phone, this.Email, this.Country.ID, this.ImagePath);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                case enMode.Update:
                    {
                        return _UpdatePerson();
                    }

                default:
                    return false;
            }
        }

        public static clsPerson Find(int ID)
        {
            //Prepare variables to store person data
            string nationalNumber = string.Empty;
            string firstName = string.Empty;
            string secondName = string.Empty;
            string thirdName = string.Empty;
            string lastName = string.Empty;
            bool gender = false;
            DateTime dateOfBirth = DateTime.MinValue;
            byte age = 0;
            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int countryID = -1;
            string imagePath = string.Empty;

            if (clsPersonData.FindPersonByID(ID, ref nationalNumber, ref firstName, ref secondName, ref thirdName
                , ref lastName, ref gender, ref dateOfBirth, ref age, ref address, ref phone, ref email
                , ref countryID, ref imagePath))
            {
                //Find country using CountryID
                clsCountry country = clsCountry.Find(countryID);

                return new clsPerson(ID, nationalNumber, firstName, secondName, thirdName, lastName, gender
                    , dateOfBirth, age, address, phone, email, country, imagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson Find(string NationalNumber)
        {
            //Prepare variables to store person data
            int ID = -1;
            string firstName = string.Empty;
            string secondName = string.Empty;
            string thirdName = string.Empty;
            string lastName = string.Empty;
            bool gender = false;
            DateTime dateOfBirth = DateTime.MinValue;
            byte age = 0;
            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int countryID = -1;
            string imagePath = string.Empty;

            if (clsPersonData.FindPersonByNationalNumber(ref ID, NationalNumber, ref firstName, ref secondName, ref thirdName
                , ref lastName, ref gender, ref dateOfBirth, ref age, ref address, ref phone, ref email, ref countryID, ref imagePath))
            {
                //Find country using CountryID
                clsCountry country = clsCountry.Find(countryID);
                return new clsPerson(ID, NationalNumber, firstName, secondName, thirdName, lastName, gender
                    , dateOfBirth, age, address, phone, email, country, imagePath);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int ID)
        {
            return clsPersonData.IsPersonExistByPersonID(ID);
        }

        public static bool IsExist(string NationalNumber)
        {
            return clsPersonData.IsPersonExistByNationalNumber(NationalNumber);
        }

        public static bool Delete(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static DataTable GetPeopleList()
        {
            return clsPersonData.GetAllPeople();
        }

    }
}
