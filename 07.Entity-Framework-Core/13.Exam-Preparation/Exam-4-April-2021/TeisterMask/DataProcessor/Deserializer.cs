using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.Mappers;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectDto[]), xmlRoot);

            ImportProjectDto[] projectsDto = null;

            using (StringReader stringReader = new StringReader(xmlString))
            {
                projectsDto = (ImportProjectDto[]) serializer.Deserialize(stringReader);
            }

            HashSet<ImportProjectDto> validProjects = new HashSet<ImportProjectDto>();

            foreach (var projectDto in projectsDto)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDateTimeProject);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    bool isDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateTimeProject);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                }
                else
                {
                    projectDto.DueDate = null;
                }

                HashSet<ImportProjectTaskDto> validTasks = new HashSet<ImportProjectTaskDto>();

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isOpenDateTaskValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDateTimeTask);

                    if (!isOpenDateTaskValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDueDateTaskValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateTimeTask);

                    if (!isDueDateTaskValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //corner case
                    if (openDateTimeTask > dueDateTimeTask)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (openDateTimeProject > openDateTimeTask)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (projectDto.DueDate != null)
                    {
                        DateTime dueDateTimeProject = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                        if (openDateTimeTask > dueDateTimeProject)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (dueDateTimeTask > dueDateTimeProject)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (dueDateTimeTask < openDateTimeProject)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (openDateTimeProject > dueDateTimeProject)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    //valid date time

                    bool isExecutionTypeValid = Enum.TryParse(typeof(ExecutionType), taskDto.ExecutionType, out object executionType);

                    if (!isExecutionTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isLabelTypeValid = Enum.TryParse(typeof(LabelType), taskDto.LabelType, out object labelType);

                    if (!isLabelTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validTasks.Add(taskDto);
                }

                projectDto.Tasks = validTasks.ToArray();
                validProjects.Add(projectDto);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, projectDto.Name, projectDto.Tasks.Length));
            }

            HashSet<Project> projects = new HashSet<Project>();

            foreach (var projectDto in validProjects)
            {
                projects.Add(Mapper.Instance.Map<Project>(projectDto));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportEmployeeDto> employeesDto = JsonConvert.DeserializeObject<List<ImportEmployeeDto>>(jsonString);

            HashSet<int> taskIds = context.Tasks.Select(t => t.Id).ToHashSet();

            HashSet<Employee> employees = new HashSet<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                HashSet<int> validTasks = new HashSet<int>();

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    if (!taskIds.Contains(taskId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validTasks.Add(taskId);
                }

                employeeDto.Tasks = validTasks.ToArray();

                employees.Add(Mapper.Instance.Map<Employee>(employeeDto));

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employeeDto.Username,
                    employeeDto.Tasks.Length));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}