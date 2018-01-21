using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace BL
{
    public class Bl_base : IBL
    {

        DAL.Idal dal;
        public Bl_base()
        {
            dal = DAL.FactoryDal.GetDal();
        }
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
            List<BE.Child> children = childrenList().Where(x => x.motherId == mother.id).ToList();

            foreach (var child in children)//deleting her children
            {
                try
                {
                    removeChild(child);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

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
                throw new Exception("The child can't be under 3 months");
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


        public void addContract(BE.Child child, BE.Nanny nanny, bool isSigned)
        {
            BE.Mother mother = dal.getMotherById(child.motherId);
            BE.Contract contract = new BE.Contract();
            contract.motherId = mother.id;
            contract.nannyId = nanny.id;

            if ((contractsList().FindAll(x => x.childId == child.Id)).Count != 0)
                throw new Exception("This child  already has a nanny");
            int childAge = monthsOld(child.dateOfBirth);

            if (nanny.minAgeChildren > childAge || nanny.maxAgeChildren < childAge)
                throw new Exception("The age of the child not compatible with accepting ages of the nanny");

            if (nanny.maxChildren == (dal.contractsList().FindAll(x => x.nannyId == nanny.id).Count))
                throw new Exception("This nanny is full");

            if (nanny.hourlyRateAccepting)
            {
                contract.HourlyRate = nanny.hourlyRate;
                double sumHours = 0;
                for (int i = 0; i < 6; i++)
                    sumHours += mother.neededHours[i,1].Hours - mother.neededHours[i, 0].Hours;
                contract.MonthlyRate = Math.Min(nanny.monthlyRate, nanny.hourlyRate * ((sumHours * 52) / 12));
            }
            else
                contract.MonthlyRate = nanny.monthlyRate;

            int sumChild = (dal.contractsList()).FindAll(x => x.motherId == mother.id && x.nannyId == nanny.id).Count;
            contract.MonthlyRate -= sumChild * 0.02 * contract.monthlyRate;

            if (isSigned)
                contract.isContractSighed = true;
            else
                contract.isContractSighed = false;
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
                return dal.MotherOfTheChild(childId);
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

        /// <summary>
        /// <matching nannies by time/>
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        List<BE.Nanny> listOfMatchingNannies(BE.Mother mother)
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
                        if (mother.neededHours[i, 0].Hours < nanny.workingHours[i, 0].Hours
                            || mother.neededHours[i, 1].Hours > nanny.workingHours[i, 1].Hours)
                            matching = false;
                    }
                }
                if (matching)
                    matchingNannies.Add(nanny);

            }
            if (matchingNannies.Count == 0)
                return bestDefaultsNannies(mother);

            return matchingNannies;
        }
        double matchingHours(TimeSpan[,] nanny, TimeSpan[,] mother)
        {
            int sumMatchingHours = 0;
            for (int i = 0; i < 6; i++)
            {
                sumMatchingHours += Math.Min(nanny[i, 1].Hours, mother[i, 1].Hours) -
                    Math.Max(nanny[i, 0].Hours, mother[i, 0].Hours);
            }
            return sumMatchingHours;
        }
        List<BE.Nanny> bestDefaultsNannies(BE.Mother mother)
        {
            
            List<BE.Nanny> nannies = new List<BE.Nanny>();

            ///<object contain nanny with the matching hours of her and the mother/>
            var overlappingHours = from nanny in nanniesList()
                                   select new
                                   {
                                       Nanny = nanny,
                                       matchingHours =
                                       matchingHours(nanny.workingHours, mother.neededHours)
                                   };

            var list = overlappingHours.ToList();

            for (int i = 0; i < 5 && list.Count > 0; i++)
            {
                double max = list.Max(item => item.matchingHours);
                nannies.Add(list.First(t => max == t.matchingHours).Nanny);
                list.Remove(list.First(t => t.matchingHours == max));
            }
            return nannies;
        }
        public double distance(string source, string dest)
        {
            return GoogleApiFunc.CalcDistance(source, dest, TravelType.Walking);
        }

        public List<BE.Nanny> bestNannies(BE.Mother mother)
        {
            List<BE.Nanny> nannies = new List<BE.Nanny>();

            if (listOfMatchingNannies(mother).Count > 5)
                nannies = listOfMatchingNannies(mother);
            else
                nannies = bestDefaultsNannies(mother);

            double[] distances = new double[nannies.Count];
            int i = 0;
            Thread thread;
            
            ///<object contains nanny with her distance to mother/>
            foreach(var nanny in nannies)
            {
                double distance = 0;
                thread = new Thread(() => distance = GoogleApiFunc.CalcDistance(nanny.address, mother.address, TravelType.Walking));
                thread.Start();
                thread.Join();
                distances[i++] = distance;
            }
            i = 0;
            var nanniesDistance = from nanny in nannies
                                  select new
                                  {
                                      thisNanny = nanny,
                                      distance = distances[i++]
                                  };
            var nanniesdistance = nanniesDistance.ToList();
            nannies = new List<BE.Nanny>();

            nanniesdistance.Sort((x, y) => x.distance.CompareTo(y.distance));

            foreach (var item in nanniesdistance)
                nannies.Add(item.thisNanny);

            return nannies;
        }
        public List<BE.Nanny> bestNannies(BE.Child child)
        {
            List<BE.Nanny> nannies = bestNannies(motherOfTheChild(child.Id));
            
            nannies = nannies.Where(x => x.maxAgeChildren > monthsOld(child.dateOfBirth)
            && x.minAgeChildren < monthsOld(child.dateOfBirth)).ToList();

            nannies = nannies.Where(x => childrenByNanny(x).Count < x.maxChildren).ToList();
            return nannies;
        }

        public List<BE.Child> childWithoutNanny()
        {
            List<BE.Child> children = childrenList();

            List<BE.Contract> contracts = contractsList();

            foreach (var child in children)
            {
                if (contracts.Find(x => x.childId == child.Id) != null)
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
            if (predicate == null)
                return dal.contractsList();
            else
                return dal.contractsList().Where(predicate);
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
                        group nanny by nanny.maxChildren % 3;
            }
            return query;
        }

        public IEnumerable<IGrouping<double, BE.Contract>> contractsByDistance(bool sorting = false)
        {
            List<BE.Contract> contracts = contractsList();

            if (sorting)
                contracts.Sort((x, y) =>
                    GoogleApiFunc
                        .CalcDistance(dal.getMotherById(x.motherId).address, dal.GetNannyById(x.nannyId).address,
                            TravelType.Walking).CompareTo(GoogleApiFunc.CalcDistance(
                            dal.getMotherById(y.motherId).address, dal.GetNannyById(y.nannyId).address,
                            TravelType.Walking)));

            IEnumerable<IGrouping<double, BE.Contract>> query = from contract in contracts
                group contract by GoogleApiFunc.CalcDistance(dal.getMotherById(contract.motherId).address,
                                      dal.GetNannyById(contract.nannyId).address, TravelType.Walking) % 5;
            return query;

        }

        public List<BE.Child> childrenByNanny(BE.Nanny nanny)
        {
            int nannyId = nanny.id;
            List<BE.Contract> contracts = contractsList().Where(x => x.nannyId == nannyId).ToList();
            IEnumerable<BE.Child> children = from child in contracts
                           select childrenList().First(x => x.Id == child.childId);
            return children.ToList();
        }
        public BE.Nanny getNannyById(int nannyId)
        {
            return dal.getNannyById(nannyId);
        }
        public BE.Mother getMotherById(int motherId)
        {
            return mothersList().First(x => x.id == motherId);
        }
    }
}
