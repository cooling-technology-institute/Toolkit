// Copyright Cooling Technology Institute 2019-2021

namespace Models
{
    public class TowerTestData
    {
        public string TestName { get; set; }

        public TowerSpecifications TowerSpecifications { set; get; }

        public TowerTestData(bool isInternationalSystemOfUnits_IS_)
        {
            TestName = string.Empty;
            TowerSpecifications = new TowerSpecifications();
            TowerSpecifications.IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
        }
    }
}