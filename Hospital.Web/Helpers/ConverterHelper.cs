using Hospital.Web.Data;
using Hospital.Web.Models;
using System.Threading.Tasks;

namespace Hospital.Web.Helpers
{
    public class ConverterHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly ICombosHelper _combosHelper;
        public ConverterHelper(ApplicationDbContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        //public async Task<Patient> ToPatientAsync(PatientViewModel model, bool isNew)
        //{
        //    return new Patient
        //    {
        //        //Category = await _context.Categories.FindAsync(model.CategoryId),
               
        //        Id = isNew ? 0 : model.Id,
        //        Name = model.Name,
        //        Age = model.Age,
        //        Diagnosis = model.Diagnosis,
        //        Entity = model.Entity,
        //        DateBirth = model.DateBirth,
        //        Record = model.Record,
        //        PatientImages = model.PatientImages
        //    };
        //}

        //public PatientViewModel ToPatientViewModel(Patient patient)
        //{
        //    return new PatientViewModel
        //    {
        //       // Categories = _combosHelper.GetComboCategories(),
        //        Name = patient.Name,
        //       // Id = patient.Category.Id,
        //        Document = patient.Document,
        //        Id = patient.Id,
        //        Age = patient.Age,
        //        Diagnosis = patient.Diagnosis,
        //        Entity = patient.Entity,
        //        DateBirth = patient.DateBirth,
        //        Record = patient.Record,
        //        PatientImages = patient.PatientImages
        //    };
        //}

    }
}
