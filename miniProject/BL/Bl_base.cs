﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    class Bl_base : IBL
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
                dal.updateMother(mother);
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


            if (nanny.MaxChildren == (dal.contractsList().FindAll(x => x.nannyId == nanny.id).Count))
                throw new Exception("This nanny is full");

            if (nanny.hourlyRateAccepting && contract.monthlyOrHourly == BE.hourlyOrMonthly.hourly)
            {
                double sumHours = 0;
                for (int i = 0; i < 6; i++)
                    sumHours += mother.neededHours[1, i].Hour - mother.neededHours[0, i].Hour;
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
                        if (mother.neededHours[0, i].Hour < nanny.workingHours[0, i].Hour
                            || mother.neededHours[1, i].Hour > nanny.workingHours[1, i].Hour)
                            matching = false;
                    }
                }
                if (matching)
                    matchingNannies.Add(nanny);

            }
            return matchingNannies;
        }
        double overlapping(DateTime[,] nanny, DateTime[,] mother)
        {
            int sumOverlapping = 0;
            for (int i = 0; i < 6; i++)
            {
                sumOverlapping += Math.Min(nanny[1, i].Hour, mother[1, i].Hour) -
                    Math.Max(nanny[0, i].Hour, mother[0, i].Hour);
            }
            return sumOverlapping;
        }
        public List<BE.Nanny> bestDefaultsNannies(BE.Mother mother)
        {
            List<BE.Nanny> nannies = new List<BE.Nanny>();
            var overlappingHours = from nanny in nanniesList()
                                   select new { Nanny = nanny,
                                       matchingHours = 
                                       overlapping(nanny.workingHours, mother.neededHours) };

            var list = overlappingHours.ToList();

            for (int i = 0; i < 5; i++)
            {
                double max = list.Max(item => item.matchingHours);
                nannies.Add(list.First(t => max == t.matchingHours).Nanny);
                list.Remove(list.First(t => t.matchingHours == max));
            }
            return nannies;
        }
        
    }
}
