﻿using Civilians.Core.ViewModels.Passports;
using Civilians.Core.Models;

namespace Civilians.Core.Interfaces
{
    public interface IPassportsRepository
    {
        public Task<Passport?> GetByIdAsync(Guid id);
        public Task<Passport?> GetByPersonalInfo(SearchPassportViewModel passportViewModel);
        public Task UpdateAsync(UpdatePassportViewModel passportViewModel);
    }
}