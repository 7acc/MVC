using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webb4_DAL.Models;
using Webb4_DAL.Repositories.Interfaces;

namespace Webb4_DAL.Repositories
{
    class ApartmentRepository : IAppartmentRepository
    {
        public AppartmentDataModel GetAppartmentById(Guid apartmentId)
        {
            throw new NotImplementedException();
        }

        public FeaturesDataModel GetAppartmentFeatures(Guid apartmentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateApartmentFeatures()
        {
            throw new NotImplementedException();
        }

        public void AddFeaturesToApartment(FeaturesDataModel features)
        {
            throw new NotImplementedException();
        }

        public void AddNewAppartment(AppartmentDataModel newApartment)
        {
            throw new NotImplementedException();
        }
    }
}
