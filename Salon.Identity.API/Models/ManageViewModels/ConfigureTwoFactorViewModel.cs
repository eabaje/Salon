﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Salon.Identity.API.Models.ManageViewModels
{
    public record ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; init; }

        public ICollection<SelectListItem> Providers { get; init; }
    }
}
