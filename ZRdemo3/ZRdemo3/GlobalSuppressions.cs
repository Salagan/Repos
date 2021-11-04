// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.Startup")]

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:File should have header", Justification = "Reviewed.")]

[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1200:Using directives should be placed correctly", Justification = "Reviewed.")]

[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "Reviewed.", Scope = "member", Target = "~M:ZRdemo3.Startup.#ctor(Microsoft.Extensions.Configuration.IConfiguration)")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.Program")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:Code analysis suppression should have justification", Justification = "Reviewed.")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "Reviewed.", Scope = "member", Target = "~M:ZRdemo3.Startup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1116:Split parameters should start on line after declaration", Justification = "Reviewed.", Scope = "member", Target = "~M:ZRdemo3.Startup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.WeatherForecast")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "Reviewed.", Scope = "member", Target = "~F:ZRdemo3.Controllers.CoachesController._unitOfWork")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.Controllers.CoachesController")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "member", Target = "~M:ZRdemo3.Controllers.TrainingsController.GetById(System.Int32)~Microsoft.AspNetCore.Mvc.ActionResult{ZRdemoData.Repositories.TrainingRepository}")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "member", Target = "~M:ZRdemo3.Controllers.TrainingsController.Add(ZRdemoData.Models.Training)~Microsoft.AspNetCore.Mvc.ActionResult{ZRdemoData.Repositories.TrainingRepository}")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "member", Target = "~M:ZRdemo3.Controllers.GuestsController.GetAll~Microsoft.AspNetCore.Mvc.ActionResult{System.Collections.Generic.IEnumerable{ZRdemoData.Repositories.GuestRepository}}")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.Controllers.GroupOfStudentsController")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "Reviewed.", Scope = "member", Target = "~F:ZRdemo3.Controllers.GroupOfStudentsController._unitOfWork")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "Reviewed.", Scope = "member", Target = "~F:ZRdemo3.Controllers.GuestsController._unitOfWork")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.Controllers.GuestsController")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "Reviewed.", Scope = "member", Target = "~F:ZRdemo3.Controllers.GymsController._unitOfWork")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.Controllers.GymsController")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "Reviewed.", Scope = "member", Target = "~F:ZRdemo3.Controllers.StudentsController._unitOfWork")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.Controllers.StudentsController")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "Reviewed.", Scope = "member", Target = "~F:ZRdemo3.Controllers.TrainingsController._unitOfWork")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.Controllers.TrainingsController")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Reviewed.", Scope = "type", Target = "~T:ZRdemo3.Controllers.WeatherForecastController")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "Reviewed.", Scope = "member", Target = "~F:ZRdemo3.Controllers.WeatherForecastController._logger")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "Reviewed.", Scope = "member", Target = "~F:ZRdemo3.Controllers.WeatherForecastController._logger")]
