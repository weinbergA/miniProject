using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;

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
        private string contractPath = @"ContractXml.xml";
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
            number = new XElement("numbers", new XElement("number", 12345678));
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
            XElement isWorkingToday = new XElement("workingDays");
            XElement workingHours = new XElement("workingHours");

            for (int i = 0; i < 6; i++)
            {
                isWorkingToday.Add(new XElement("day"+i.ToString().ToUpper(), ToXMLstring(nanny.isWorkingToday[i])));
                if (nanny.isWorkingToday[i])
                {
                    workingHours.Add(new XElement( "start"+ i.ToString().ToUpper(), nanny.workingHours[i, 0].ToString(@"hh\:mm\:ss")));
                    workingHours.Add(new XElement("end"+ i.ToString().ToUpper(), nanny.workingHours[i, 1].ToString(@"hh\:mm\:ss")));
                }
            }

            XElement id = new XElement("id", nanny.id);
            XElement lastName = new XElement("lastName", nanny.lastName);
            XElement firstName = new XElement("firstName", nanny.firstName);
            XElement dateOfBirth = new XElement("dateOfBirth", nanny.dateOfBirth.ToString(@"MM\/dd\/yyyy"));
            XElement phoneNumber = new XElement("phoneNumber", nanny.phoneNumber);
            XElement address = new XElement("address", nanny.address);
            XElement isElevator = new XElement("elevator", ToXMLstring(nanny.isElevator));
            XElement floor = new XElement("floor", nanny.floor);
            XElement experienceYears = new XElement("experienceYears", nanny.experienceYears);
            XElement maxChildren = new XElement("maxChildren", nanny.maxChildren);
            XElement minAgeChildren = new XElement("minimumAgeChildren", nanny.minAgeChildren);
            XElement maxAgeChildren = new XElement("maximumAgeChildren", nanny.maxAgeChildren);
            XElement hourlyRateAccepting = new XElement("hourlyRateAccepting", ToXMLstring(nanny.hourlyRateAccepting));
            XElement hourlyRate = new XElement("hourlyRate", nanny.hourlyRate);
            XElement monthlyRate = new XElement("monthlyRate", nanny.monthlyRate);
            XElement tamatHolidays = new XElement("tamatHolidays", ToXMLstring(nanny.tamatHolidays));
            XElement reviews = new XElement("reviews", nanny.reviews);

            nannyRoot.Add(new XElement("nanny", firstName, lastName, id, address, phoneNumber, isElevator, dateOfBirth,
                floor, experienceYears, maxChildren, maxAgeChildren, minAgeChildren, hourlyRateAccepting, hourlyRate,
                monthlyRate, tamatHolidays, reviews, isWorkingToday, workingHours));
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
            XElement firstName = new XElement("firstName", mother.firstName);
            XElement lastName = new XElement("lastName", mother.lastName);
            XElement id = new XElement("id", mother.id);
            XElement address = new XElement("address", mother.address);
            XElement phoneNumber = new XElement("phoneNumber", mother.phoneNumber);
            XElement nannyRequestedAddress = new XElement("nannyRequestedAddress", mother.nannyRequestedAddress);
            XElement isNeedNannyToday = new XElement("neededDays");
            XElement neededHours = new XElement("neededHours");
            XElement notes = new XElement("notes", mother.notes);

            for (int i = 0; i < 6; i++)
            {
                isNeedNannyToday.Add(new XElement("day"+i.ToString().ToUpper(), ToXMLstring(mother.isNeedNannyToday[i])));
                if (mother.isNeedNannyToday[i])
                {
                    neededHours.Add(new XElement("start"+i.ToString().ToUpper(), mother.neededHours[i, 0].ToString(@"hh\:mm\:ss")));
                    neededHours.Add(new XElement("end"+ i.ToString().ToUpper(), mother.neededHours[i, 1].ToString(@"hh\:mm\:ss")));
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
            XElement motherId = new XElement("motherId", child.motherId);
            XElement firstName = new XElement("firstName", child.firstName);
            XElement lastName = new XElement("lastName", child.lastName);
            XElement dateOfBirth = new XElement("dateOfBirth", child.dateOfBirth.ToString("MM/dd/yyyy"));
            XElement specialNeeds = new XElement("specialNeeds", ToXMLstring(child.specialNeeds));
            XElement specialNeedsDescrition = new XElement("specialNeedsDescrition", child.specialNeedsDescrition);

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
            int contractNumber = int.Parse((from num in number.Elements()
                where num.Name == "number"
                select num).FirstOrDefault().Value);
            number = new XElement("numbers", new XElement("number", ++contractNumber));
            number.Save(numberPath);

            XElement cNumber = new XElement("contractNumber", contractNumber);
            XElement nannyId = new XElement("nannyId", contract.nannyId);
            XElement motherId = new XElement("motherId", contract.motherId);
            XElement childId = new XElement("childId", contract.childId);
            XElement firstMeeting = new XElement("firstMeeting", ToXMLstring(contract.firstMeeting));
            XElement isContractSighed = new XElement("signed", ToXMLstring(contract.isContractSighed));
            XElement hourlyRate = new XElement("hourlyRate", contract.hourlyRate);
            XElement monthlyRate = new XElement("monthlyRate", contract.HourlyRate);
            XElement monthlyOrHourly = new XElement("monthlyOrHourly", ToXMLstring(contract.monthlyOrHourly));
            XElement contrcatBeggining = new XElement("begin", contract.contrcatBeggining.ToString(@"MM\/dd\/yyyy"));
            XElement contractFinshing = new XElement("end", contract.contractFinshing.ToString(@"MM\/dd\/yyyy"));

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
                                   where int.Parse(cont.Element("contractNumber").Value) == contract.contractNumber
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
            List<BE.Nanny> nannies;
            try
            {
                nannies = (from nu in nannyRoot.Elements()
                    select new BE.Nanny
                    {
                        id = int.Parse(nu.Element("id")?.Value),
                        firstName = nu.Element("firstName")?.Value,
                        lastName = nu.Element("lastName")?.Value,
                        dateOfBirth = DateTimeString(nu.Element("dateOfBirth")?.Value),
                        phoneNumber = int.Parse(nu.Element("phoneNumber")?.Value),
                        address = nu.Element("address")?.Value,
                        isElevator = ToObject<bool>(nu.Element("elevator")?.Value),
                        floor = int.Parse(nu.Element("floor")?.Value),
                        experienceYears = int.Parse(nu.Element("experienceYears")?.Value),
                        maxChildren = int.Parse(nu.Element("maxChildren")?.Value),
                        minAgeChildren = int.Parse(nu.Element("minimumAgeChildren")?.Value),
                        maxAgeChildren = int.Parse(nu.Element("maximumAgeChildren")?.Value),
                        hourlyRateAccepting = ToObject<bool>(nu.Element("hourlyRateAccepting")?.Value),
                        hourlyRate = int.Parse(nu.Element("hourlyRate").Value),
                        monthlyRate = int.Parse(nu.Element("monthlyRate").Value),
                        tamatHolidays = ToObject<bool>(nu.Element("tamatHolidays")?.Value),
                        reviews = nu.Element("reviews").Value
                    }).ToList();
                foreach (var nanny in nannies)
                {
                    XElement na = (from nannyX in nannyRoot.Elements()
                        where int.Parse(nannyX.Element("id").Value) == nanny.id
                        select nannyX).FirstOrDefault();

                    for (int i = 0; i < 6; i++)
                    {
                        XElement d = (from day in na.Elements()
                            where day.Name == "workingDays"
                            select day).FirstOrDefault();
                        nanny.isWorkingToday[i] = ToObject<bool>(d.Element("day"+i.ToString().ToUpper()).Value);

                        XElement h = (from hours in na.Elements()
                            where hours.Name == "workingHours"
                            select hours).FirstOrDefault();

                        if (nanny.isWorkingToday[i])
                        {
                            nanny.workingHours[i, 0] =
                                TimeSpanString(h.Element("start" + i.ToString().ToUpper())?.Value);
                            nanny.workingHours[i, 1] =
                                TimeSpanString(h.Element("end" + i.ToString().ToUpper())?.Value);
                        }
                    }
                }
            }
            catch
            {
                nannies = null;
            }

            return nannies;
        }

        private TimeSpan TimeSpanString(string str)
        {
            string[] ints = str.Split(':');
            int hours = int.Parse(ints[0]);
            int minuts = int.Parse(ints[1]);
            int seconds = int.Parse(ints[2]);
            return new TimeSpan(hours,minuts,seconds);
        }

        private DateTime DateTimeString(string str)
        {
            string[] date = str.Split('/');
            int year = int.Parse(date[2]);
            int month = int.Parse(date[0]);
            int day = int.Parse(date[1]);
            return new DateTime(year, month, day);
        }
        public List<BE.Mother> mothersList()
        {
            List<BE.Mother> mothers;
            try
            {
                mothers = (from mo in motherRoot.Elements()
                    select new BE.Mother
                    {
                        firstName = mo.Element("firstName").Value,
                        lastName = mo.Element("lastName").Value,
                        id = int.Parse(mo.Element("id").Value),
                        address = mo.Element("address").Value,
                        phoneNumber = int.Parse(mo.Element("phoneNumber").Value),
                        nannyRequestedAddress = mo.Element("nannyRequestedAddress").Value,
                    }
                ).ToList();

                foreach (var mother in mothers)
                {
                    XElement mo = (from motherX in motherRoot.Elements()
                        where int.Parse(motherX.Element("id").Value) == mother.id
                        select motherX).FirstOrDefault();
                    for (int i = 0; i < 6; i++)
                    {
                        XElement d = (from day in mo.Elements()
                            where day.Name == "neededDays"
                                  select day).FirstOrDefault();
                        mother.isNeedNannyToday[i] = ToObject<bool>(d.Element("day"+i.ToString().ToUpper()).Value);
                        XElement h = (from hours in mo.Elements()
                            where hours.Name == "neededHours"
                            select hours).FirstOrDefault();

                        if (mother.isNeedNannyToday[i])
                        {
                            mother.neededHours[i, 0] = TimeSpanString(h.Element("start" + i.ToString().ToUpper())?.Value);
                            mother.neededHours[i, 1] = TimeSpanString(h.Element("end" + i.ToString().ToUpper())?.Value);
                        }
                    }
                }
                {
                    
                }
            }
            catch
            {
                mothers = null;
            }

            return mothers;
        }

        public List<BE.Child> childrenList()
        {
            List<BE.Child> children;
            try
            {
                children = (from ch in childRoot.Elements()
                            select new Child
                            {
                                Id = int.Parse(ch.Element("id")?.Value),
                                motherId = int.Parse(ch.Element("motherId")?.Value),
                                dateOfBirth = DateTimeString(ch.Element("dateOfBirth")?.Value),
                                firstName = ch.Element("firstName")?.Value,
                                lastName = ch.Element("lastName")?.Value,
                                specialNeeds = ToObject<bool>(ch.Element("specialNeeds")?.Value),
                                specialNeedsDescrition = ch.Element("specialNeedsDescrition")?.Value
                            }).ToList();
            }
            catch
            {
                children = null;
            }

            return children;
        }

        public List<BE.Child> childrenByMother(BE.Mother mother)
        {
            return childrenList().Where(x => x.motherId == mother.id).ToList();
        }

        public List<BE.Contract> contractsList()
        {
            List<BE.Contract> contracts;
            try
            {
                contracts = (from con in contractRoot.Elements()
                             select new BE.Contract()
                             {
                                 motherId = int.Parse(con.Element("motherId")?.Value),
                                 contractNumber = int.Parse(con.Element("contractNumber")?.Value),
                                 nannyId = int.Parse(con.Element("nannyId")?.Value),
                                 childId = int.Parse(con.Element("childId")?.Value),
                                 firstMeeting = ToObject<bool>(con.Element("firstMeeting")?.Value),
                                 isContractSighed = ToObject<bool>(con.Element("signed")?.Value),
                                 hourlyRate = int.Parse(con.Element("hourlyRate")?.Value),
                                 monthlyRate = int.Parse(con.Element("monthlyRate")?.Value),
                                 monthlyOrHourly = ToObject<hourlyOrMonthly>(con.Element("monthlyOrHourly")?.Value),
                                 contrcatBeggining = DateTimeString(con.Element("begin")?.Value),
                                 contractFinshing = DateTimeString(con.Element("end")?.Value)
                             }).ToList();
            }
            catch
            {
                contracts = null;
            }

            return contracts;
        }

        public BE.Nanny getNannyById(int nannyId)
        {
            return nanniesList().FirstOrDefault(x => x.id == nannyId);
        }

        //BY given  id of child return his mother 
        public BE.Mother MotherOfTheChild(int childId)
        {
            int motherId = childrenList().FirstOrDefault(x => x.Id == childId).motherId;
            return mothersList().FirstOrDefault(x => x.id == motherId);
        }

        public BE.Mother getMotherById(int motherId)
        {
            return mothersList().FirstOrDefault(x => x.id == motherId);
        }

        public BE.Nanny GetNannyById(int nannyId)
        {
            return nanniesList().FirstOrDefault(x => x.id == nannyId);
        }



        public IEnumerable<BE.Contract> contrantsByCondition(Func<BE.Contract, bool> predicate = null)
        {
            if (predicate == null)
                return contractsList().AsEnumerable();
            return contractsList().Where(predicate);
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
                return (T)xmlSerializer.Deserialize(textReader);

            }
        }
    }
}
