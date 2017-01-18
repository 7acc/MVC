using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webb4_DAL.Models;

namespace Webb4_DAL.Repositories.Interfaces
{
    interface IAppartmentRepository
    {
        AppartmentDataModel GetAppartmentById(Guid apartmentId);
        FeaturesDataModel GetAppartmentFeatures(Guid apartmentId);

        void UpdateApartmentFeatures();

        void AddFeaturesToApartment(FeaturesDataModel features);
        void AddNewAppartment(AppartmentDataModel newApartment);
    }
}
