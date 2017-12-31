using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class Bl_base : IBL
    {

        DAL.Dal_imp dal = new DAL.Dal_imp();
        
        public void addNanny(BE.Nanny nanny)
        {
            if (yearsOld(nanny.dateOfBirth) < 18)
                throw new Exception("Nanny can't be under 18 years old");
            try
            {
                dal.addNanny(nanny);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void removeNanny(BE.Nanny nanny)
        {
            try
            {
                dal.removeNanny(nanny);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void updateNanny(BE.Nanny nanny)
        {
            try
            {
                dal.updateNanny(nanny);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void addMother(BE.Mother mother)
        {
            try
            {
                dal.addMother(mother);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void removeMother(BE.Mother mother)
        {
            try
            {
                dal.removeMother(mother);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateMother(BE.Mother mother)
        {
            try
            {
                dal.updateMother(mother);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void addChild(BE.Child child)
        {
            if (monthsOld(child.dateOfBirth) < 3)
                throw new Exception("The child can't under 3 months");
            try
            {
                dal.addChild(child);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void removeChild(BE.Child child)
        {
            try
            {
                dal.removeChild(child);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateChild(BE.Child child)
        {
            try
            {
                dal.updateChild(child);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public void addContract(BE.Contract contract)
        {
            BE.Mother mother = dal.getMotherById(contract.motherId);
            BE.Nanny nanny = dal.GetNannyById(contract.nannyId);
            BE.Child child = dal.getChildByID(contract.childId);

            int childAge = monthsOld(child.dateOfBirth);

            if (nanny.minAgeChildren > childAge || nanny.maxAgeChildren < childAge)
                throw new Exception("The age of the child not compatible with accepting ages of the nanny");

            if (nanny.MaxChildren == (dal.contractsList().FindAll(x => x.nannyId == nanny.id).Count))
                throw new Exception("This nanny is full");

            if (nanny.hourlyRateAccepting && contract.monthlyOrHourly == BE.hourlyOrMonthly.hourly)
            {
                double sumHours = 0;
                for (int i = 0; i < 6; i++)
                    sumHours += mother.neededHours[1, i].Hours - mother.neededHours[0, i].Hours;
                contract.HourlyRate = nanny.HourlyRate;
                contract.MonthlyRate = (sumHours * 52) / 12;
            }
            else
                contract.MonthlyRate = nanny.MonthlyRate;

            int sumChild = (dal.contractsList()).FindAll(x => x.motherId == mother.id && x.nannyId == nanny.id).Count;
            contract.MonthlyRate -= sumChild * 0.02;
            try
            {
                dal.addContract(contract);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void removeContract(BE.Contract contract)
        {
            try
            {
                dal.removeContract(contract);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void updateContract(BE.Contract contract)
        {
            try
            {
                dal.updateContract(contract);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<BE.Nanny> nanniesList()
        {
            try
            {
                return dal.nanniesList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BE.Mother> mothersList()
        {
            try
            {
                return dal.mothersList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BE.Child> childrenList()
        {
            try
            {
                return dal.childrenList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BE.Child> childrenByMother(BE.Mother mother)
        {
            try
            {
                return dal.childrenByMother(mother);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BE.Contract> contractsList()
        {
            try
            {
                return dal.contractsList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //BY given  id of child return his mother 
        public BE.Mother motherOfTheChild(int childId)
        {
            try
            {
                return dal.motherOfTheChild(childId);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        int monthsOld(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Now;
            int years = now.Year - dateOfBirth.Year;
            int month = now.Month - dateOfBirth.Month;
            return (years * 12 + month);
        }
        int yearsOld(DateTime dateOfBirth)
        {
            return monthsOld(dateOfBirth) / 12;
        }

        public List<BE.Nanny> listOfMatchingNannies(BE.Mother mother)
        {
            List<BE.Nanny> matchingNannies = new List<BE.Nanny>();
            foreach (var nanny in nanniesList())
            {
                bool matching = true;
                for (int i = 0; i < 6; i++)
                {
                    //checking matching by days
                    if (mother.isNeedNannyToday[i] == true && nanny.isWorkingToday[i] != true)
                        matching = false;
                }
                if (matching)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        ////checking matching by enter and exit hour
                        if (mother.neededHours[0, i].Hours < nanny.workingHours[0, i].Hours
                            || mother.neededHours[1, i].Hours > nanny.workingHours[1, i].Hours)
                            matching = false;
                    }
                }
                if (matching)
                    matchingNannies.Add(nanny);

            }
            return matchingNannies;
        }
        double overlapping(TimeSpan[,] nanny, TimeSpan[,] mother)
        {
            int sumOverlapping = 0;
            for (int i = 0; i < 6; i++)
            {
                sumOverlapping += Math.Min(nanny[1, i].Hours, mother[1, i].Hours) -
                    Math.Max(nanny[0, i].Hours, mother[0, i].Hours);
            }
            return sumOverlapping;
        }
        public List<BE.Nanny> bestDefaultsNannies(BE.Mother mother)
        {
            List<BE.Nanny> nannies = new List<BE.Nanny>();
            var overlappingHours = from nanny in nanniesList()
                                   select new
                                   {
                                       Nanny = nanny,
                                       matchingHours =
                                       overlapping(nanny.workingHours, mother.neededHours)
                                   };

            var list = overlappingHours.ToList();

            for (int i = 0; i < 5; i++)
            {
                double max = list.Max(item => item.matchingHours);
                nannies.Add(list.First(t => max == t.matchingHours).Nanny);
                list.Remove(list.First(t => t.matchingHours == max));
            }
            return nannies;
        }

        //public List<BE.Nanny> bestNannies(BE.Mother mother)
        //{
        //    List<BE.Nanny> nannies = new List<BE.Nanny>();

        //    if (listOfMatchingNannies(mother).Count > 5)
        //        nannies = listOfMatchingNannies(mother);
        //    else
        //        nannies = bestDefaultsNannies(mother);

        //    var nanniesDistans = (from nanny in nannies
        //                          select new
        //                          {
        //                              thisNanny = nanny,
        //                              distance = Main.Distance.Getdistance(mother.address, nanny.address)
        //                          }).ToList();

        //    nannies = new List<BE.Nanny>();

        //    nanniesDistans.Sort((x, y) => x.distance.CompareTo(y.distance));

        //    foreach (var item in nanniesDistans)
        //        nannies.Add(item.thisNanny);

        //    return nannies;
        //}

        public List<BE.Child> childWithoutNanny()
        {
            List<BE.Child> children = childrenList();

            List<BE.Contract> contracts = contractsList();

            foreach (var child in children)
            {
                if (contracts.Find(x => x.childId == child.id) != null)
                    children.Remove(child);
            }

            return children;
        }

        public List<BE.Nanny> listOfNanniesByTamatHloidays()
        {
            List<BE.Nanny> nannies = nanniesList();
            nannies.RemoveAll(x => x.tamatHolidays == false);
            return nannies;
        }


        public IEnumerable<BE.Contract> contractsByCondition(Func<BE.Contract, bool> predicate = null)
        {
            return dal.contrantsByCondition(predicate);
        }

        public int contractsByConditionCount(Func<BE.Contract, bool> predicate = null)
        {
            return contractsByCondition(predicate).Count();
        }

        public IEnumerable<IGrouping<int, BE.Nanny>> nanniesByAges(bool minAge, bool sorting = false)
        {
            List<BE.Nanny> nannies = nanniesList();
            IEnumerable<IGrouping<int, BE.Nanny>> query;
            if (sorting)
            {
                if (minAge)
                    nannies.Sort((x, y) => x.minAgeChildren.CompareTo(y.minAgeChildren));
                else
                    nannies.Sort((x, y) => x.maxAgeChildren.CompareTo(y.maxAgeChildren));
            }
            if (minAge)
            {
                query = from nanny in nannies
                        group nanny by nanny.minAgeChildren % 3;
            }
            else
            {
                query = from nanny in nannies
                        group nanny by nanny.MaxChildren % 3;
            }
            return query;
        }

        //public IEnumerable<IGrouping<double, BE.Contract>> contractsByDistance(bool sorting = false)
        //{
        //    List<BE.Contract> contracts = contractsList();

        //    if (sorting)
        //        contracts.Sort((x, y) => Main.Distance.Getdistance(dal.getMotherById(x.motherId).address, dal.GetNannyById(x.nannyId).address).CompareTo(Main.Distance.Getdistance(dal.getMotherById(y.motherId).address, dal.GetNannyById(y.nannyId).address)));

        //    IEnumerable<IGrouping<double, BE.Contract>> query = from contract in contracts
        //                                                        group contract by Main.Distance.Getdistance(dal.getMotherById(contract.motherId).address, dal.GetNannyById(contract.nannyId).address) % 5;
        //    return query;

        //}



    }
}
