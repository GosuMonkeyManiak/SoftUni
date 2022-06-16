function people() {

    class Employee {

        constructor(name, age) {
            this.name = name;
            this.age = Number(age);
            this.salary = 0;
            this.tasks = [];
            this._taskIndex = 0;
        }

        work() {
            let task = this.tasks[this._taskIndex];

            task = task.replace('{employee name}', this.name);

            if (this.tasks[this._taskIndex + 1] == undefined) {
                this._taskIndex = 0;
            } else {
                this._taskIndex += 1;
            }

            console.log(task);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {

        constructor(name, age) {
            super(name, age);
            this.tasks.push('{employee name} is working on a simple task.');
        }
    }

    class Senior extends Employee {

        constructor(name, age) {
            super(name, age);
            this.tasks.push(
                    '{employee name} is working on a complicated task.',
                    '{employee name} is taking time off work.',
                    '{employee name} is supervising junior workers.');
        }
    }

    class Manager extends Employee {

        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
            this.tasks.push(
                    '{employee name} scheduled a meeting.',
                    '{employee name} is preparing a quarterly report.');
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager    
    };
}

const classes = people(); 
const junior = new classes.Junior('Ivan',25); 
 
junior.work();  
junior.work();  
 
junior.salary = 5811; 
junior.collectSalary();  
 
const sinior = new classes.Senior('Alex', 31); 
 
sinior.work();  
sinior.work();  
sinior.work();  
sinior.work();  
 
sinior.salary = 12050; 
sinior.collectSalary();  
 
const manager = new classes.Manager('Tom', 55); 
 
manager.salary = 15000; 
manager.collectSalary();  
manager.dividend = 2500; 
manager.collectSalary();  
