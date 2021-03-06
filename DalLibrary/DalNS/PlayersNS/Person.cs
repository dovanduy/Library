﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using AliKuli.Extentions;
using EnumLibrary.EnumNS;
using ErrorHandlerLibrary.ExceptionsNS;
using InterfacesLibrary.PeopleNS;

namespace ModelsClassLibrary.ModelsNS.PeopleNS.PlayersNS
{
    public class Person : IPerson
    {
        private ErrorSet _err;

        public Person()
        {
            _err = new ErrorSet();
            _err.SetLibAndClass(Assembly.GetCallingAssembly().GetName().Name, this.GetType().Name);
        }


        [Display(Name = "Identification #")]
        public string IdentificationNo { get; set; }

        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "Middle Name")]
        public string MName { get; set; }

        [Display(Name = "Sex")]
        public SexENUM Sex { get; set; }


        [Display(Name = "Relation Type")]

        public SonOfWifeOfDotOfENUM SonOfOrWifeOf { get; set; }


        [Display(Name = "Name of Relative")]
        public string NameOfFatherOrHusband { get; set; }

        public void LoadFrom(IPerson p)
        {
            IdentificationNo = p.IdentificationNo;
            FName = p.FName;
            LName = p.LName;
            MName = p.MName;
            Sex = p.Sex;
            NameOfFatherOrHusband = p.NameOfFatherOrHusband ?? "";
            SonOfOrWifeOf = p.SonOfOrWifeOf;

        }

        public string Helper_CreateFullName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FName.ToTitleCase());

            if (!MName.IsNullOrEmpty())
            {
                sb.Append(" ");
                sb.Append(MName.ToTitleCase());
            }
            if (!LName.IsNullOrEmpty())
            {
                sb.Append(" ");
                sb.Append(LName.ToTitleCase());
            }

            if (SonOfOrWifeOf != SonOfWifeOfDotOfENUM.Unknown)
            {

                sb.Append(" ");
                sb.Append(SonOfOrWifeOf.ToString());
                sb.Append(" ");
                sb.Append(NameOfFatherOrHusband.ToTitleCase());
            }

            //Add the Identity Card Number to make sure there are no unneccessary duplicates in the names
            //The Id card will be the item tjhat will bring about the uniqueness
            if (!IdentificationNo.IsNullOrEmpty())
            {
                sb.Append(" ");
                sb.Append(string.Format("- National ID: {0}", IdentificationNo.ToPakistanCnicFormat()));
            }

            return sb.ToString();
        }




        private void Check_FathersNameOrHusbandsNameEntered()
        {
            if (NameOfFatherOrHusband.IsNullOrEmpty())
            {
                string error;

                if (SonOfOrWifeOf == SonOfWifeOfDotOfENUM.WifeOf)
                {
                    error = string.Format("You have not entered the name of the Husband for '{0}'. Please enter the Husband Name. ", PersonFullName());
                    _err.Add(error, MethodBase.GetCurrentMethod());
                }

                if (SonOfOrWifeOf == SonOfWifeOfDotOfENUM.SonOf)
                {
                    error = string.Format("You have not entered the name of the Father for '{0}'. Please enter the Father Name. ", PersonFullName());
                    _err.Add(error, MethodBase.GetCurrentMethod());
                }
            }
        }

        private void Check_SonOfWifeOfField()
        {
            //We want to know the father's name
            if (SonOfOrWifeOf == SonOfWifeOfDotOfENUM.Unknown)
            {
                string error = (string.Format("You have not entered the parentage/husband for '{0}'. Please enter the parentage or Husband. (W/O, S/O. D/O)", PersonFullName()));
                _err.Add(error, MethodBase.GetCurrentMethod());

            }
        }


        private void Check_FName()
        {
            if (FName.IsNullOrEmpty())
            {
                string error = "First Name missing.";
                _err.Add(error, MethodBase.GetCurrentMethod());

            }
        }

        private void Check_NationalIdentificationNumber()
        {
            if (IdentificationNo.IsNullOrEmpty())
            {
                string error = "Country Identifican Card Number missing.";
                _err.Add(error, MethodBase.GetCurrentMethod());
            }
        }

        private void Check_Sex()
        {
            if (Sex == SexENUM.Unknown)
            {
                string error = "Person's sex is missing.";
                _err.Add(error, MethodBase.GetCurrentMethod());
            }
        }





        public string PersonFullName()
        {
            return Helper_CreateFullName();
        }


        public void SelfErrorCheck()
        {
            Check_FathersNameOrHusbandsNameEntered();
            Check_SonOfWifeOfField();
            Check_FName();
            Check_NationalIdentificationNumber();
            Check_Sex();
        }



    }
}