<!-- TITLE -->
# UPS Hackathon 2020 - "Career Constructor"

![Image of Home Screen](https://github.com/rheidem/UPS-Hackathon-2020/blob/master/Portfolio_1.PNG)

<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
  * [Creating Questions](#creating-questions)
  * [Creating Quizzes](#creating-quizzes)
  * [Taking Quizzes](#taking-quizzes)
  * [Grading Quizzes](#grading-quizzes)
* [Contact](#contact)


<!-- ABOUT THE PROJECT -->
## About The Project

As you may have noticed by the title, this project was completed for the UPS IT Intern's 2020 Hackathon. Myself, the team leader and sole developer, led our team of 4 interns in creating this web application using ASP.NET Core. Not only did we win an award for this project, it was a lot of fun to work on. We were tasked with creating a software application with business value in a little under 48 hours and our team made the Career Constructor.

The Career Constructor is a quiz-making web tool for recruiters and talent acquisition specialists to screen applicants based on relevant knowledge. It allows users to create questions, group these questions into quizzes, and assign and grade these quizzes to and from applicants. The value of this project is two-fold. One, it allows HR specialists and managers an easy way to ensure their applicants have relevant knowledge, and two, it highlights candidates with this knowledge in the interview process. The application is aimed towards interns who don't have much real-world experience but have the technical skills. By taking these quizzes they show off what they know, essentially constructing their careers.



<!-- GETTING STARTED -->
## Getting Started

This project was written using ASP.NET Core with a local SQL database. Their were intentions to use Microsoft's Azure for the database, but we were inherently limited by time. 

### Prerequisites

To run this application, you will need two things: .NET Core and some type of SQL database, we used Sequel Server Management Studio.

The links for these tools can be found here:
* [.NET Core](https://dotnet.microsoft.com/download)
* [Sequel Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

### Installation

1. Clone the repo
```sh
git clone https://github.com/rheidem/UPS-Hackathon-2020.git
```
2. Create a database in SSMS called 'hackathon' (to interface with project)
3. Run the project
```sh
dotnet run
```


<!-- USAGE -->
## Usage

Aside from other minor details of this application, such as the home page, creating user accounts, and logging in, there are four main aspects to the site, which are detailed below.

### Creating Questions

The first and most important part of this project was making questions for the quizzes. Each question has an associated question type, number of points, and multiple tags which the user can search by to find other relevant questions. 
![Image of Creating Questions](https://github.com/rheidem/UPS-Hackathon-2020/blob/master/Portfolio_2.PNG)

Here we can see a list of the questions that have already been created, with the search bar searching by question tags.

### Creating Quizzes

Next is to create the quizzes. Each quiz has a name, the related job, and a list of questions.
![Image of Creating Quiz](https://github.com/rheidem/UPS-Hackathon-2020/blob/master/Portfolio_5.PNG)

Above, we can see that this quiz has three questions, which are shown in a list below for convenience.

![Image of Quiz List](https://github.com/rheidem/UPS-Hackathon-2020/blob/master/Portfolio_3.PNG)

There is also a page for all of the quizzes, where a user can then review or take the quiz.

### Taking Quizzes

Once an applicant takes a quiz, they will see a list of the quiz's corresponding questions, and will have multiple input fields to answer these questions.

![Image of Taking Quiz](https://github.com/rheidem/UPS-Hackathon-2020/blob/master/Portfolio_6.PNG)

### Grading Quizzes

Finally, after an applicant has taken a quiz, an admin (HR or hiring manager) can review the quiz and grade the questions (although in reality we wanted to make this autonomous).

First select a quiz to grade:
![Image of Pending Quizzes](https://github.com/rheidem/UPS-Hackathon-2020/blob/master/Portfolio_4.PNG)

Then assign each question points:
![Image of Grading Quiz](https://github.com/rheidem/UPS-Hackathon-2020/blob/master/Portfolio_7.PNG)

Applicants can then review the quizzes they have taken, where their score will appear in green at the top:
![Image of Graded Quiz](https://github.com/rheidem/UPS-Hackathon-2020/blob/master/Portfolio_8.PNG)



<!-- CONTACT -->
## Contact

Ryan Heidema - [@ryan-heidema](https://www.linkedin.com/in/ryan-heidema/) - rheidem@umich.edu

Project Link: [https://github.com/rheidem/UPS-Hackathon-2020](https://github.com/rheidem/UPS-Hackathon-2020)
