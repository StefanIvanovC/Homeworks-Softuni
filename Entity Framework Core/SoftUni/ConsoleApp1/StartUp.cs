using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var softUniContex = new SoftUniContext();
            var result = GetEmployeesByFirstNameStartingWithSa(softUniContex);
            Console.WriteLine(result);
        }


        // TO DO 15 Exercise - time - 3:19
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .FirstOrDefault(x => x.Name == "Seattle")

        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeeSA = context.Employees
                .Where(x => EF.Functions. Like(x.FirstName, "sa%"))
                .Select(x => new
                {
                      x.FirstName,
                      x.LastName,
                      x.JobTitle,
                      x.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employeeSA)
            {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();

        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(x => departments.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var emp in employees)
            {
                emp.Salary *= 1.12m;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var deppartments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Include(x => x.Employees)
                .Select(x => new
                {
                    x.Name,
                    x.Manager.FirstName,
                    x.Manager.LastName,
                    Employees = x.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                     .OrderBy(x => x.FirstName)
                     .ThenBy(x => x.LastName)
                     .ToList()
                })
                .ToList();
        

            var sb = new StringBuilder();

            foreach (var dep in deppartments)
            {
                sb.AppendLine($"{dep.Name} – {dep.FirstName} {dep.LastName}");

                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var address = context.Addresses
                .Select(x => new
                {
                    x.AddressText,
                    x.Town.Name,
                    x.Employees.Count,
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(t => t.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var addresEmp in address)
            {
                sb.AppendLine($"{addresEmp.AddressText}, {addresEmp.Name} - {addresEmp.Count} employees");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employeeWithId147 = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects.OrderBy(x => x.Project.Name).Select(p => new
                    {
                        p.Project.Name
                    })
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employeeWithId147)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");

                foreach (var proj in emp.Projects)
                {
                    sb.AppendLine($"{proj.Name}");
                }

            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
                                                         p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFirstName = x.FirstName,
                    EmployeeLastName = x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        projectName = p.Project.Name,
                        projectStart = p.Project.StartDate,
                        ProjectEnd = p.Project.EndDate,
                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var endDate = project.ProjectEnd.HasValue ? project.ProjectEnd.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";

                    sb.AppendLine($"--{project.projectName} - {project.projectStart.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var nakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            nakov.AddressId = address.AddressId;
            context.SaveChanges();

            var addresses = context.Employees
                .Select(x => new
                {
                    x.Address.AddressText,
                    x.Address.AddressId,
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var curAddress in addresses)
            {
                sb.AppendLine($"{curAddress.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.MiddleName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary,
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

    }
}
