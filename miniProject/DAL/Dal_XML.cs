using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    class DalXml : Idal
    {
        private XElement childRoot;
        private XElement contractRoot;
        private XElement motherRoot;
        private XElement nannyRoot;
        private XElement number;
        private string childPath = @"ChildXml.xml";
        private string contractPath = @"ContractPath.xml";
        private string motherPath = @"motherXml.xml";
        private string nannyPath = @"nannyXml.xml";
        private string numberPath = @"number.xml";
        
        private static DalXml _Dal_imp = null;

        private DalXml()
        {
            if (!File.Exists(childPath))
                CreateChildFile();
            else
                LoadChildFile();
            if (!File.Exists(contractPath))
                CreateContractFile();
            else
                LoadContractFile();
            if (!File.Exists(motherPath))
                CreateMotherFile();
            else
                LoadMotherFile();
            if (!File.Exists(nannyPath))
                CreateNannyFile();
            else
                LoadNannyFile();
            if (!File.Exists(numberPath))
                CreateNumberFile();
            else
                LoadNumberFile();
        }

        private void CreateNumberFile()
        {
            number = new XElement("number", 12345678);
            number.Save(numberPath);
        }

        private void LoadNumberFile()
        {
            try
            {
                number = XElement.Load(numberPath);
            }
            catch
            {
                throw new Exception("can not load file of number");
            }
        }

        private void CreateNannyFile()
        {
            nannyRoot = new XElement("nannies");
            nannyRoot.Save(nannyPath);
        }

        private void LoadNannyFile()
        {
            try
            {
                nannyRoot = XElement.Load(nannyPath);
            }
            catch
            {
                throw new Exception("nanny file loaded problem");
            }
        }

        private void LoadMotherFile()
        {
            try
            {
                motherRoot = XElement.Load(motherPath);
            }
            catch
            {
                throw new Exception("mother file loaded problem");
            }
        }

        private void CreateMotherFile()
        {
            motherRoot = new XElement("mothers");
            motherRoot.Save(motherPath);
        }

        private void LoadContractFile()
        {
            try
            {
                contractRoot = XElement.Load(contractPath);
            }
            catch
            {
                throw new Exception("contract file load problem");
            }
        }

        private void CreateContractFile()
        {
            contractRoot = new XElement("contracts");
            contractRoot.Save(contractPath);
        }

        private void LoadChildFile()
        {
            try
            {
                childRoot = XElement.Load(childPath);
            }
            catch
            {
                throw new Exception("child file load problem");
            }

        }

        private void CreateChildFile()
        {
            childRoot = new XElement("children");
            childRoot.Save(childPath);
        }

        public void addNanny(BE.Nanny nanny)
        {
            XElement isWorkingToday = new XElement("working days");
            XElement workingHours = new XElement("working hours");

            for (int i = 0; i < 6; i++)
            {
                isWorkingToday.Add(new XElement(i.ToString(), ToXMLstring(nanny.isWorkingToday[i])));
                if (nanny.isWorkingToday[i])
                {
                    workingHours.Add(new XElement(i.ToString() + " start", ToXMLstring(nanny.workingHours[i, 0])));
                    workingHours.Add(new XElement(i.ToString() + " end", ToXMLstring(nanny.workingHours[i, 1])));
                }
            }

            XElement id = new XElement("id", nanny.id);
            XElement lastName = new XElement("last name", nanny.lastName);
            XElement firstName = new XElement("first name", nanny.firstName);
            XElement dateOfBirth = new XElement("date of birth", nanny.dateOfBirth);
            XElement phoneNumber = new XElement("phone number", nanny.phoneNumber);
            XElement address = new XElement("addrees", nanny.address);
            XElement isElevator = new XElement("elevator", nanny.isElevator);
            XElement floor = new XElement("floor", nanny.floor);
            XElement experienceYears = new XElement("experience years", nanny.experienceYears);
            XElement maxChildren = new XElement("max children", nanny.maxChildren);
            XElement minAgeChildren = new XElement("minimum age children", nanny.minAgeChildren);
            XElement maxAgeChildren = new XElement("maximum age children", nanny.maxAgeChildren);
            XElement hourlyRateAccepting = new XElement("hourly rate accepting", nanny.hourlyRateAccepting);
            XElement hourlyRate = new XElement("hourly rate", nanny.hourlyRate);
            XElement monthlyRate = new XElement("monthly rate", nanny.monthlyRate);
            XElement tamatHolidays = new XElement("tamat hildays", nanny.tamatHolidays);
            XElement reviews = new XElement("reviews", nanny.reviews);

            nannyRoot.Add(new XElement("nanny"), firstName, lastName, id, address, phoneNumber, isElevator, floor,
                experienceYears, maxChildren, maxAgeChildren, minAgeChildren, hourlyRateAccepting, hourlyRate,
                monthlyRate, tamatHolidays, reviews, isWorkingToday, workingHours);
            nannyRoot.Save(nannyPath);
        }

        public void removeNanny(BE.Nanny nanny)
        {
            XElement nannyElement;
            try
            {
                nannyElement = (from na in nannyRoot.Elements()
                    where int.Parse(na.Element("id").Value) == nanny.id
                    select na).FirstOrDefault();
                nannyElement.Remove();
            }
            catch 
            {
                throw new Exception("can not delete nanny");
            }
        }

        public void updateNanny(BE.Nanny nanny)
        {
            removeNanny(nanny);
            addNanny(nanny);
        }

        public void addMother(BE.Mother mother)
        {
            XElement firstName = new XElement("first name", mother.firstName);
            XElement lastName = new XElement("last name", mother.lastName);
            XElement id = new XElement("id", mother.id);
            XElement address = new XElement("address", mother.address);
            XElement phoneNumber = new XElement("phone number", mother.phoneNumber);
            XElement nannyRequestedAddress = new XElement("nanny requested address", mother.nannyRequestedAddress);
            XElement isNeedNannyToday = new XElement("needed days");
            XElement neededHours = new XElement("needed hours");
            XElement notes = new XElement("notes", mother.notes);

            for (int i = 0; i < 6; i++)
            {
                isNeedNannyToday.Add(new XElement(i.ToString(), mother.isNeedNannyToday[i]));
                if (mother.isNeedNannyToday[i])
                {
                    neededHours.Add(new XElement(i.ToString() + " start", ToXMLstring(mother.neededHours[i, 0])));
                    neededHours.Add(new XElement(i.ToString() + " start", ToXMLstring(mother.neededHours[i, 1])));
                }
            }

            motherRoot.Add(new XElement("mother", id, firstName, lastName, address, nannyRequestedAddress, phoneNumber,
                notes, isNeedNannyToday, neededHours));
            motherRoot.Save(motherPath);
        }

        public void removeMother(BE.Mother mother)
        {
            XElement motherElement;
            try
            {
                motherElement = (from mo in motherRoot.Elements()
                    where int.Parse(mo.Element("id").Value) == mother.id
                    select mo).FirstOrDefault();
                motherElement.Remove();
            }
            catch
            {
                throw new Exception("can not delete mother");
            }
        }

        public void updateMother(BE.Mother mother)
        {
            removeMother(mother);
            addMother(mother);
        }

        public void addChild(BE.Child child)
        {
            XElement id = new XElement("id", child.Id);
            XElement motherId = new XElement("mother id", child.motherId);
            XElement firstName = new XElement("first name", child.firstName);
            XElement lastName = new XElement("last name", child.lastName);
            XElement dateOfBirth = new XElement("date of birth", child.dateOfBirth);
            XElement specialNeeds = new XElement("special needs", child.specialNeeds);
            XElement specialNeedsDescrition = new XElement("special needs descrition", child.specialNeedsDescrition);

            childRoot.Add(new XElement("child", id, motherId, firstName, lastName, dateOfBirth, specialNeeds,
                specialNeedsDescrition));
            childRoot.Save(childPath);
        }

        public void removeChild(BE.Child child)
        {
            XElement childElement;
            try
            {
                childElement = (from ch in childRoot.Elements()
                    where int.Parse(ch.Element("id").Value) == child.Id
                    select ch).FirstOrDefault();
                childElement.Remove();
            }
            catch
            {
                throw new Exception("can not delete child");
            }
        }

        public void updateChild(BE.Child child)
        {
            removeChild(child);
            addChild(child);
        }

        public void addContract(BE.Contract contract)
        {
            int contractNumber = int.Parse(number.Element("number").Value);
            number = new XElement("number", ++contractNumber);
            number.Save(numberPath);

            XElement cNumber = new XElement("contract number", contractNumber);
            XElement nannyId = new XElement("nanny id", contract.nannyId);
            XElement motherId = new XElement("mother id", contract.motherId);
            XElement childId = new XElement("child id", contract.childId);
            XElement firstMeeting = new XElement("first meeting", contract.firstMeeting);
            XElement isContractSighed = new XElement("signed", contract.isContractSighed);
            XElement hourlyRate = new XElement("hourly rate", contract.hourlyRate);
            XElement monthlyRate = new XElement("mothly rate", contract.HourlyRate);
            XElement monthlyOrHourly = new XElement("mothly or hourly", contract.monthlyOrHourly);
            XElement contrcatBeggining = new XElement("begin", contract.contrcatBeggining);
            XElement contractFinshing = new XElement("end", contract.contractFinshing);

            contractRoot.Add(new XElement("contract", cNumber, nannyId, motherId, childId, firstMeeting,
                isContractSighed, hourlyRate, monthlyRate, monthlyOrHourly, contrcatBeggining, contractFinshing));
            contractRoot.Save(contractPath);
        }

        public void removeContract(BE.Contract contract)
        {
            XElement contractElement;
            try
            {
                contractElement = (from cont in contractRoot.Elements()
                    where int.Parse(cont.Element("contract number").Value) == contract.contractNumber
                    select cont).FirstOrDefault();
                contractElement.Remove();
            }
            catch
            {
                throw new Exception("can not delete contract");
            }
        }

        public void updateContract(BE.Contract contract)
        {
            removeContract(contract);
            addContract(contract);
        }

        public List<BE.Nanny> nanniesList()
        {

        }

        public List<BE.Mother> mothersList()
        {

        }

        public List<BE.Child> childrenList()
        {

        }

        public List<BE.Child> childrenByMother(BE.Mother mother)
        {

        }

        public List<BE.Contract> contractsList()
        {

        }

        public BE.Nanny getNannyById(int nannyId)
        {

        }

        //BY given  id of child return his mother 
        public BE.Mother MotherOfTheChild(int childId)
        {

        }

        public BE.Mother getMotherById(int motherId)
        {

        }

        public BE.Nanny GetNannyById(int nannyId)
        {

        }



        public IEnumerable<BE.Contract> contrantsByCondition(Func<BE.Contract, bool> predicate = null)
        {

        }

        public static Idal dal()
        {
            if (_Dal_imp == null)
                _Dal_imp = new DalXml();
            return _Dal_imp;
        }

        string ToXMLstring<T>(T toSerialize)
        {
            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }


        T ToObject<T>(string toDeserialize)
        {
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T) xmlSerializer.Deserialize(textReader);

            }
        }
    }
}
