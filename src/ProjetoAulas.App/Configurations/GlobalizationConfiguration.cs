﻿using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace ProjetoAulas.App.Configurations
{
    public static class GlobalizationConfiguration
    {
        public static IApplicationBuilder UseGlobalizationConfiguration(this IApplicationBuilder app)
        {
            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture },
            };
            app.UseRequestLocalization(localizationOptions);

            return app;
        }
    }
}
