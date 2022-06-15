class Company {

    constructor() {
        this.departments = [];
    }

    addEmployee(name, salary, position, department) {

        if (name == '' || name == undefined || name == null) {
            throw new Error('Invalid input!');
        }

        if (salary == '' || salary == undefined || salary == null || salary < 0) {
            throw new Error('Invalid input!');
        }

        if (position == '' || position == undefined || position == null) {
            throw new Error('Invalid input!');
        }

        if (department == '' || department == undefined || department == null) {
            throw new Error('Invalid input!');
        }

        let employee = {
            name,
            salary,
            position
        };

        if (this.departments.some(d => d.name == department)) {

            let currentDepartment = this.departments.find(d => d.name == department);
            currentDepartment.employees.push(employee);
            
        } else {
            let newDepartment = {
                name: department,
                employees: [employee]
            };

            this.departments.push(newDepartment);
        }

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {

        this.departments.sort((a, b) => {
            let firstCompanyAverageSalary = (a.employees.reduce((a, v) => a + v.salary, 0) / a.employees.length).toFixed(2);
            let secondCompantAverageSalary = (b.employees.reduce((a, v) => a + v.salary, 0) / b.employees.length).toFixed(2);
            return secondCompantAverageSalary - firstCompanyAverageSalary;
        });

        let bestDepartment = this.departments[0];
        bestDepartment.employees
            .sort((a, b) => {
                let result = b.salary - a.salary;

                if (result == 0) {
                    return a.name.localeCompare(b.name);
                }

                return result;
            });

        let result = '';
        result += `Best Department is: ${bestDepartment.name}\n`;
        result += `Average salary: ${(bestDepartment.employees.reduce((a, v) => a + v.salary, 0) / bestDepartment.employees.length).toFixed(2)}\n`;

        for (const employee of bestDepartment.employees) {
            result += `${employee.name} ${employee.salary} ${employee.position}\n`;
        }

        return result.trim();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
console.log(c);