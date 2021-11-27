using System;
using System.Globalization;
using System.Linq;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ExportDto;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask
{
    using AutoMapper;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TeisterMaskProfile()
        {
            CreateMap<ImportProjectDto, Project>()
                .ForMember(m => m.Tasks,
                    opt => opt.MapFrom(f => f.Tasks
                                .Select(t => new Task()
                                {
                                    Name = t.Name,
                                    OpenDate = DateTime.ParseExact(t.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    DueDate = DateTime.ParseExact(t.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    ExecutionType = Enum.Parse<ExecutionType>(t.ExecutionType),
                                    LabelType = Enum.Parse<LabelType>(t.LabelType)
                                })))
                .ForMember(m => m.OpenDate,
                    opt => opt.MapFrom(f => DateTime.ParseExact(f.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(m => m.DueDate,
                    opt => opt.MapFrom(f => f.DueDate != null ? DateTime.ParseExact(f.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null));

            CreateMap<ImportEmployeeDto, Employee>()
                .ForMember(m => m.EmployeesTasks,
                    opt => opt.MapFrom(f => f.Tasks
                                .Select(t => new EmployeeTask()
                                {
                                    TaskId = t
                                })));
        }
    }
}
